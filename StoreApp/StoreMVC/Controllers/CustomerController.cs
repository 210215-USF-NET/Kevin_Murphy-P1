using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreDL;
using StoreMVC.Models;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace StoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        private IPartsBL _partsBL;
        private IMapper _mapper;
        private Customer _customer;
        public CustomerController(IPartsBL partsBL,IMapper mapper)
        {

            _partsBL = partsBL;
            _mapper = mapper;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
              
            return View(_partsBL.GetCustomer().Select(customer => _mapper.cast2CustomerIndexVM(customer)).ToList());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(string number)
        {
            return View(_mapper.cast2CustomerCRVM(_partsBL.GetCustomerByNumber(number)));
        }

        // GET: CustomerController/Create
        public ActionResult AddOrder(string number)
        {
            _customer = (_partsBL.GetCustomerByNumber(number));

            return View();
        }


        public ActionResult Login(string number)
        {
            _customer = _partsBL.GetCustomerByNumber(number);
            HttpContext.Session.SetString("customer", JsonSerializer.Serialize(_customer));
            return RedirectToAction(nameof(Index));
           
        }
        public ActionResult Create()
        {
            return View("CreateCustomer");
        }

        public ActionResult ViewOrders(int Id)
        {
            List<Order> o = new List<Order>();
            o = _partsBL.GetOrderByCustomerId(Id).ToList();
            return View(o);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCRVM newCustomer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _partsBL.AddCustomer(_mapper.cast2Customer(newCustomer));
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
