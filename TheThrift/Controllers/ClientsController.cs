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
    public class ClientsController : Controller
    {
        private readonly IClientRepository _repo;
        private readonly IMapper _mapper;

        public ClientsController(IClientRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: CustomersController
        public ActionResult Index()
        {
            var customers = _repo.FindAll().ToList();
            var collection = _mapper.Map<List<Client>, List<ClientVM>>(customers);
            return View(collection);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var customers = _repo.FindById(id);
            var collections = _mapper.Map<ClientVM>(customers);
            return View(collections);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientVM collection)
        {
            try
            {
                //TODO: Add insert logic here

                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var customers = _mapper.Map<Client>(collection);
                customers.DateCreated = DateTime.Now;

                var isSuccess = _repo.Create(customers);
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

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExist(id))
            {
                return NotFound();
            }
            var customers = _repo.FindById(id);
            var collection = _mapper.Map<ClientVM>(customers);
            return View(collection);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientVM collection)
        {
            try
            {
                //TODO: Added some update logic here
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                var customer = _mapper.Map<Client>(collection);
                var isSuccess = _repo.Update(customer);

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

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            //checking if there is any record for that particular Id
            var custoers = _repo.FindById(id);
            if (custoers == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(custoers);
            if (!isSuccess)
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ClientVM collection)
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
