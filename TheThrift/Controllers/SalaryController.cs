using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheThrift.Contracts;
using TheThrift.Data;
using TheThrift.Models;

namespace TheThrift.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ISalaryRepository _repo;
        private readonly IMapper _mapper;

        public SalaryController(ISalaryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: SalaryController
        public ActionResult Index()
        {
            var salaries = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Salary>, List<SalaryVM>>(salaries);
            return View(model);
        }

        // GET: SalaryController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var customers = _repo.FindById(id);
            var collection = _mapper.Map<SalaryVM>(customers);
            return View(collection);
        }

        // GET: SalaryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalaryVM collection)
        {
            try
            {
                //TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                var salary = _mapper.Map<Salary>(collection);
                salary.DateCreated = DateTime.Now;

                var isSuccess = _repo.Create(salary);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(collection);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(collection);
            }
        }

        // GET: SalaryController/Edit/5
        public ActionResult Edit(int id)
        {
            //checking if there is any record for that particular Id
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var salary = _repo.FindById(id);
            var collection = _mapper.Map<SalaryVM>(salary);
            return View(collection);
        }

        // POST: SalaryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalaryVM collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var salary = _mapper.Map<Salary>(collection);
                var isSuccess = _repo.Update(salary);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...");
                    return View(collection);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(collection);
            }
        }

        // GET: SalaryController/Delete/5
        public ActionResult Delete(int id)
        {
            //checking if there is any record for that particular Id
            var salary = _repo.FindById(id);
            if (salary == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(salary);
            if (!isSuccess)
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: SalaryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SalaryVM collection)
        {
            try
            {
                //TODO: Add delete logic here 
                var salary = _repo.FindById(id);
                if (salary == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(salary);
                if (!isSuccess)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
