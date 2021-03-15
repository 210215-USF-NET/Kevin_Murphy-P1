using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Controllers
{
    public class OrderlineController : Controller
    {

        private IPartsBL _partsBL;
        private IMapper _mapper;

        public OrderlineController(IPartsBL partsBL, IMapper mapper)
        {
            _partsBL = partsBL;
            _mapper = mapper;
        }
        // GET: OrderlineController
        public ActionResult Index()
        {
            return View(_partsBL.GetOrderline().Select(orderline => _mapper.cast2OrderlineIndexVM(orderline)).ToList());
        }

        // GET: OrderlineController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderlineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderlineController/Create
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

        // GET: OrderlineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderlineController/Edit/5
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

        // GET: OrderlineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderlineController/Delete/5
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
