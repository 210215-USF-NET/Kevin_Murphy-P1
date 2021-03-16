using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;


namespace StoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private IPartsBL _partsBL;
        private IMapper _mapper;
        public ProductController(IPartsBL partsBL, IMapper mapper)
        { 
            _partsBL = partsBL;
            _mapper = mapper;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_partsBL.GetProducts().Select(product => _mapper.cast2ProductIndexVM(product)));
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View("CreateProduct");
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCRVM newProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _partsBL.AddProduct(_mapper.cast2Product(newProduct));
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    Log.Warning("Unable to create Product");
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(string name)
        {
            _partsBL.DeleteProduct(_partsBL.GetProductByName(name));
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
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
