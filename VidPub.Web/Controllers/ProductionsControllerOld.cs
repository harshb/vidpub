using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidPub.Web.Model;


namespace VidPub.Web.Controllers
{
    public class ProductionsControllerOld : Controller
    {

        Productions _table;

        public ProductionsControllerOld()
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
            dynamic item = _table.CreateFrom(collection);
            try
            {
               
                _table.Insert(item);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["alert"] = "There was an error adding this item";
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
            var model = _table.CreateFrom(collection);
            try
            {
                _table.Update(model, id);
                return RedirectToAction("Index");

            }
            catch (Exception x)
            {

                TempData["alert"] = "There was an error adding this item";
                return View(model);
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
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _table.Delete(id);
              
            }
            catch
            {
                TempData["alert"] = "There was an error deleting this item";
                
            }
            return RedirectToAction("Index");
        }
    }
}
