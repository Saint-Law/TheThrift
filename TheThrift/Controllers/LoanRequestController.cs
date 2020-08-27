using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using TheThrift.Contracts;
using TheThrift.Data;
using TheThrift.Models;

namespace TheThrift.Controllers
{
    [Authorize]
    public class LoanRequestController : Controller
    {
        private readonly ILoanRequestRepository _loanRequestRepo;
        private readonly ILoanTypeRepository _loanTypeRepo; 
        private readonly ILoanAllocationRepository _loanAllocRepo; 
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public LoanRequestController(
            ILoanRequestRepository loanRequestRepo, 
            ILoanTypeRepository loanTypeRepo,
            ILoanAllocationRepository loanAlloRepo,
            IMapper mapper, UserManager<Employee> userManager)
        {
            _loanRequestRepo = loanRequestRepo;
            _loanTypeRepo = loanTypeRepo;
            _loanAllocRepo = loanAlloRepo; 
            _mapper = mapper;
            _userManager = userManager;
        }

        [Authorize(Roles = "Administrator")]
        // GET: LoanRequestController
        public ActionResult Index()
        {
            var loanRequests = _loanRequestRepo.FindAll();
            var loanRequestModel = _mapper.Map<List<LoanRequestVM>>(loanRequests);
            var collection = new AdminLoanRequestViewVM
            {
                TotalRequests = loanRequestModel.Count,
                ApprovedRequests = loanRequestModel.Count(q => q.Approved == true),
                PendingRequests = loanRequestModel.Count(q => q.Approved == null),
                RejectedRequests = loanRequestModel.Count(q => q.Approved == false),
                LoanRequests = loanRequestModel
            };
            return View(collection);
        }

        // GET: LoanRequestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoanRequestController/Create
        public ActionResult Create()
        {
            var loanTpyes =  _loanTypeRepo.FindAll();
            var loanTypeItems = loanTpyes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });
            var model = new CreateLoanRequestVM
            {
                LoanTypes = loanTypeItems
            };
            return View(model); 
        }

        // POST: LoanRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLoanRequestVM collection)
        {
            //TODO: Add insert loggic here          
            try
            {
                var startDate = Convert.ToDateTime(collection.StartDate);
                var endDate = Convert.ToDateTime(collection.EndDate);
                var loanList = _loanTypeRepo.FindAll();
                var loanTypeItems = loanList.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });
                collection.LoanTypes = loanTypeItems;

                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                //validing that the start date is not more than the end date
                if(DateTime.Compare(startDate, endDate) > 1)
                {
                    ModelState.AddModelError("", "Start Date cannot be further in the future than the End Date");
                    return View(collection);
                }

                //getting the user who log in at a time of requesting for loan
                //retriving the current user
                var employee = _userManager.GetUserAsync(User).Result;
                var allocation = _loanAllocRepo.GetLoanAllocationByEmployeeAndType(employee.Id,collection.LoanTypeId);

                //getting back the number of days requested and checking it the number of day
                //requested exceed the corresponding allocation
                int dateRequested = (int)(endDate - startDate).TotalDays;
                if(dateRequested > allocation.NumberOfDays)
                {
                    ModelState.AddModelError("", "You do not have Sufficeint Days for this Request");
                    return View(collection);
                }

                //saving to db and implementing deduction of allocation
                var loanRequestModel = new LoanRequestVM
                {
                    RequestingEmployeeId = employee.Id,
                    StartDate = startDate,
                    EndDate = endDate,
                    DateRequested = DateTime.Now,
                    DateActioned = DateTime.Now,
                    LoanTypeId = collection.LoanTypeId                  
                };

                var loanRequest = _mapper.Map<LoanRequest>(loanRequestModel);
                var isSuccess = _loanRequestRepo.Create(loanRequest); 
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong with submitting your Record...");
                    return View();
                }
                return RedirectToAction(nameof(Index),"Home"); 
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View();
            }
        }

        // GET: LoanRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoanRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LoanRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoanRequestController/Delete/5
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
