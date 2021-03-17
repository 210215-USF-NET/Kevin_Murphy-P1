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
using Serilog;

namespace StoreMVC.Controllers
{
    /// <summary>
    ///  Customer Controller that allows for the passing of data to Customer views
    ///  Allows for the creation of Customers 
    ///  Login as as different customers
    /// </summary>
    public class CustomerController : Controller
    {
        private IPartsBL _partsBL;
        private IMapper _mapper;
        private Customer _customer;
        public Customer c;
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
        /// <summary>
        /// This Action allows the user to see the orders based on the customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult OrderDetails(int id)
        {
            
            Order o = _partsBL.GetOrderById(id);
            OrderDetailVM od = new OrderDetailVM();
            od.CustomerName = _partsBL.GetCustomerById(o.CustomerId).CustomerName;
            od.LocationName = _partsBL.GetLocationById(o.LocationId).LocationName;
            od.ProductName = _partsBL.GetProductById(o.ProductId).ProductName;
            od.Quanity = o.Quantity;
            od.Total = o.Total;
            Log.Information($"getting{od}");
            return View(od);
        }

        /// <summary>
        /// Allows the user to see the Customer details based on the user number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public ActionResult Details(string number)
        {
            return View(_mapper.cast2CustomerCRVM(_partsBL.GetCustomerByNumber(number)));
        }

        // GET: CustomerController/Create
       /* public ActionResult AddOrder(string number)
        {
            _customer = (_partsBL.GetCustomerByNumber(number));

            return View();
        }*/

        /// <summary>
        /// allows for the log in of the potential customer
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public ActionResult Login(string number)
        {
            _customer = _partsBL.GetCustomerByNumber(number);
            HttpContext.Session.SetString("customer", JsonSerializer.Serialize(_customer));
            Log.Information($"{_customer} logged in");
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
        public ActionResult AddOrder(string number)
        {
            c = _partsBL.GetCustomerByNumber(number);
            HttpContext.Session.SetString("OrderingCustomer", JsonSerializer.Serialize(c));
            return View("PlaceOrder");
        }
        /// <summary>
        /// allows for the placing of new orders from the customer profile
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public ActionResult PlaceOrder(OrderCRVM newOrder)
        {
          
            if (ModelState.IsValid)
            {
                
                newOrder.CustomerId = _partsBL.GetCustomerByNumber(newOrder.CustomerNumber).Id;
                newOrder.LocaitonId = _partsBL.GetLocationByName(newOrder.LocationName).Id;
                Product p = new Product();
                p = _partsBL.GetProductByName(newOrder.ProductName);
                newOrder.Total = p.Price * newOrder.Quantitiy;
                newOrder.ProductId = p.Id;
                try
                {
                    _partsBL.AddOrder(_mapper.cast2Order(newOrder));
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

        // POST: CustomerController/Create

        /// <summary>
        /// allows for the creation of the newCustomer
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// allows for the ability of deletion of custoemrs
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>

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
