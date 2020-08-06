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
    public class ExpensesController : Controller
    {
        private readonly IExpensesRepository _repo;
        private readonly IMapper _mapper;

        public ExpensesController(IExpensesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: ExpensesController
        public ActionResult Index()
        {
            var expenses = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Expenses>, List<ExpensesVM>>(expenses);
            return View(model);
        }

        // GET: ExpensesController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var expenses = _repo.FindById(id);
            var collection = _mapper.Map<ExpensesVM>(expenses);
            return View(collection);
        }

        // GET: ExpensesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpensesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpensesVM collection)
        {
            try
            {
                //TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var expenses = _mapper.Map<Expenses>(collection);
                expenses.DateCreated = DateTime.Now;

                var isSuccess = _repo.Create(expenses);
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

        // GET: ExpensesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var expenses = _repo.FindById(id);
            var collection = _mapper.Map<ExpensesVM>(expenses);
            return View(collection);
        }

        // POST: ExpensesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpensesVM collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var salary = _mapper.Map<Expenses>(collection);
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

        // GET: ExpensesController/Delete/5
        public ActionResult Delete(int id)
        {
            //checking if there is any record for that particular Id
            var expenses = _repo.FindById(id);
            if (expenses == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(expenses);
            if (!isSuccess)
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ExpensesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ExpensesVM collection)
        {
            try
            {
                //TODO: Add delete logic here 
                var expenses = _repo.FindById(id);
                if (expenses == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(expenses);
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
