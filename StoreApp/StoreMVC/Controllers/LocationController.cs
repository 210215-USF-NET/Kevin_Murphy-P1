﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreMVC.Models;
using System;
using StoreModels;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace StoreMVC.Controllers
{
    public class LocationController : Controller
    {
        private IPartsBL _partsBL;
        private IMapper _mapper;
        public LocationController(IPartsBL partsBL, IMapper mapper)
        {

            _partsBL = partsBL;
            _mapper = mapper;
        }
        // GET: LocationController
        /// <summary>
        /// Show all the locations that exist
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_partsBL.GetLocation().Select(location => _mapper.cast2LocationIndexVM(location)).ToList());
        }

        // GET: LocationController/Details/5
        /// <summary>
        /// view the details of the specific locations 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult Details(string name)
        {
            return View(_mapper.cast2LocationCRVM(_partsBL.GetLocationByName(name)));
        }

        //products view for a given location
        /// <summary>
        /// View the products of the locations 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Products(int Id)
        {
            List<Product> l = new List<Product>();
            l = _partsBL.GetproductByLocationId(Id).ToList();
            return View(l);
        }

        /// <summary>
        /// view the orders of the based on the specific location
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult ViewOrders(int Id)
        {
            List<Order> o = new List<Order>();
            o = _partsBL.GetOrderByLocationId(Id).ToList();
            return View(o);
        }
        /// <summary>
        /// view the details of the orders that have been placed at that specific location
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


        private void ToList()
        {
            throw new NotImplementedException();
        }

        // GET: LocationController/Create

        public ActionResult Create()
        {
         
                return View("CreateLocation");

        }


        /// <summary>
        /// Creation of new locations 
        /// log what the new locations that is being created
        /// </summary>
        /// <param name="newLocation"></param>
        /// <returns></returns>
        // POST: LocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCRVM newLocation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _partsBL.AddLocation(_mapper.cast2Location(newLocation));
                    Log.Information($"Creation of new location");
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    Log.Warning("Unable to create new Location");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: LocationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LocationController/Edit/5
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

        // GET: LocationController/Delete/5
        /// <summary>
        /// addition of the delete functions based on the name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult Delete(string name)
        {
            _partsBL.DeleteLocation(_partsBL.GetLocationByName(name));
            return RedirectToAction(nameof(Index));
        }

        // POST: LocationController/Delete/5
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
