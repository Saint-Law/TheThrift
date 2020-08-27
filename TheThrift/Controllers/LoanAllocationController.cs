using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TheThrift.Contracts;
using TheThrift.Data;
using TheThrift.Models;

namespace TheThrift.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class LoanAllocationController : Controller
    {
        private readonly ILoanTypeRepository _loanrepo;
        private readonly ILoanAllocationRepository _loanAllocrepo;
        private readonly IMapper _Mapper;
        private readonly UserManager<Employee> _userManager;

        public LoanAllocationController(ILoanTypeRepository loanrepo, ILoanAllocationRepository loanAllocrepo, IMapper Mapper, UserManager<Employee> userManager)
        {
            _loanAllocrepo = loanAllocrepo;
            _loanrepo = loanrepo;
            _Mapper = Mapper;
            _userManager = userManager;
        }

        // GET: LoanAllocationController
        public ActionResult Index()
        {
            var allocations = _loanrepo.FindAll().ToList();
            var MappedLoanTpyes = _Mapper.Map<List<LoanType>, List<LoanTypeVM>>(allocations);
            var collection = new CreateLoanAllocationVM
            {
                LoanTypes = MappedLoanTpyes,
                NumberUpdated = 0
            };
            return View(collection);
        }

        public ActionResult SetLoan(int id)
        {
            var loantypes = _loanrepo.FindById(id);
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
            foreach (var emp in employees)
            {
                if (_loanAllocrepo.CheckAllocation(id, emp.Id))
                    continue;
                var allocation = new LoanAllocaitionVM
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = emp.Id,
                    LoanTypeId = id,
                    NumberOfDays = loantypes.DefaultDays,
                    Period = DateTime.Now.Year
                };
                var loanallocation = _Mapper.Map<LoanAllocation>(allocation);
                _loanAllocrepo.Create(loanallocation);
            }
            return RedirectToAction(nameof(Index));
        }

        //getting all the employee record from the db
        public ActionResult ListEmployees()
        {
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
            var collection = _Mapper.Map<List<EmployeeVM>>(employees);
            return View(collection);
        }

        // GET: LoanAllocationController/Details/5
        public ActionResult Details(string id)
        {
            //retrieving Employee record from the db
            var employee = _Mapper.Map <EmployeeVM>(_userManager.FindByIdAsync(id).Result);
            var allocation = _Mapper.Map<List<LoanAllocaitionVM>>(_loanAllocrepo.GetLoanAllocationByEmployee(id));
            var collection = new ViewLoanAllocationVM
            {
                Employee = employee,
                LoanAllocations = allocation
            };
            return View(collection);
        }

        // GET: LoanAllocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanAllocationController/Edit/5
        public ActionResult Edit(int id)
        {
            var allocation = _loanAllocrepo.FindById(id);
            var collection = _Mapper.Map<EditLoanAllocationVM>(allocation);
            return View(collection);
        }

        // POST: LoanAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditLoanAllocationVM collection)
        {
            try
            {
                //TODO: adding update logic here
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var record = _loanAllocrepo.FindById(collection.Id);
                record.NumberOfDays = collection.NumberofDays;                
                var isSuccess = _loanAllocrepo.Update(record);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error While Saving...");
                    return View(collection);
                }
                return RedirectToAction(nameof(Details), new { id = collection.EmployeeId});
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanAllocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoanAllocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
