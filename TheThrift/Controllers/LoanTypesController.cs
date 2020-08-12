using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheThrift.Contracts;
using TheThrift.Data;
using TheThrift.Models;

namespace TheThrift.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class LoanTypesController : Controller
    {
        private readonly ILoanTypeRepository _repo;
        private readonly IMapper _mapper;

        public LoanTypesController(ILoanTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: LoanTypesController
        public ActionResult Index()
        {
            var leaveTypes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LoanType>, List<LoanTypeVM>>(leaveTypes);
            return View(model);
        }

        // GET: LoanTypesController/Details/5
        public ActionResult Details(int id)
        {
            //checking if the record exist, then show details
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var loanTypes = _repo.FindById(id);
            var collection = _mapper.Map<LoanTypeVM>(loanTypes);
            return View(collection);
        }

        // GET: LoanTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoanTypeVM collection)
        {
            try
            {
                //TODO: Add insert logic here 
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                var loanTypes = _mapper.Map<LoanType>(collection);
                loanTypes.DateCreated = DateTime.Now;

                var isSuccess = _repo.Create(loanTypes);
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

        // GET: LoanTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }

            var loanTypes = _repo.FindById(id);
            var collection = _mapper.Map<LoanTypeVM>(loanTypes);
            return View(collection);
        }

        // POST: LoanTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoanTypeVM collection)
        {
            try
            {
                //TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                var loanTypes = _mapper.Map<LoanType>(collection);
                var isSuccess = _repo.Update(loanTypes);
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

        // GET: LoanTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            //checking if there is any record for that particular Id
            var loanTypes = _repo.FindById(id);
            if (loanTypes == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(loanTypes);
            if (!isSuccess)
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: LoanTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LoanTypeVM collection)
        {
            try
            {
                //TODO: Add delete logic here 
                var loanTypes = _repo.FindById(id);
                if (loanTypes == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(loanTypes);
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
