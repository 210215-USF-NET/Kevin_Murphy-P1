using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModels;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Controllers
{
    public class OrderController : Controller
    {
        private IPartsBL _partsBL;
        private IMapper _mapper;

        public OrderController(IPartsBL partsBL, IMapper mapper)
        {
            _partsBL = partsBL;
            _mapper = mapper;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            return View(_partsBL.GetOrder().Select( order => _mapper.cast2OrderIndexVM(order)).ToList());
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            Order o = _partsBL.GetOrderById(id);
            OrderDetailVM od = new OrderDetailVM();
            od.CustomerName = _partsBL.GetCustomerById(o.CustomerId).CustomerName;
            od.LocationName = _partsBL.GetLocationById(o.LocationId).LocationName;
            od.ProductName = _partsBL.GetProductById(o.ProductId).ProductName;
            od.Quanity = o.Quantity;
            od.Total = o.Total;
            return View(od);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View("CreateOrder");
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCRVM newOrder)
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            Order p = new Order();
            p = _partsBL.GetOrderById(id);
            _partsBL.DeleteOrder(_partsBL.GetOrderById(id));
            
            return RedirectToAction(nameof(Index));
        }

        // POST: OrderController/Delete/5
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
