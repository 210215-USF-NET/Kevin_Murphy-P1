using Microsoft.AspNetCore.Http;
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
        public ActionResult Index()
        {
            return View(_partsBL.GetLocation().Select(location => _mapper.cast2LocationIndexVM(location)).ToList());
        }

        // GET: LocationController/Details/5
        public ActionResult Details(string name)
        {
            return View(_mapper.cast2LocationCRVM(_partsBL.GetLocationByName(name)));
        }

        //products view for a given location
        public ActionResult Products(int Id)
        {
            List<Product> l = new List<Product>();
            l = _partsBL.GetproductByLocationId(Id).ToList();
            return View(l);
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
