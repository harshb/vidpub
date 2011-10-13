using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidPub.Web.Model;

namespace VidPub.Web.Controllers
{
    public class ProductionsController : Controller
    {

        Productions _table;

        public ProductionsController()
        {
            _table = new Productions();
        }

        public ActionResult Index()
        {
            return View(_table.All());
        }

        //
        // GET: /Productions/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Productions/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Productions/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Productions/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Productions/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Productions/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Productions/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
