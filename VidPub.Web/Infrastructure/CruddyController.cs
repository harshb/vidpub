﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidPub.Web.Controllers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace VidPub.Web.Infrastructure {
    public class CruddyController:ApplicationController {

        public CruddyController(ITokenHandler tokenStore):base(tokenStore) {}

        protected dynamic _table;

        [HttpGet]
        public virtual ActionResult Index(string query)
        {
            IEnumerable<dynamic> results = null;
            if (!string.IsNullOrEmpty(query))
            {
                results = _table.FuzzySearch(query);
            }
            else
            {
                //returns IEnumerable<dynamic>
                results = _table.All();
            }
            if (Request.IsAjaxRequest())
            {
                //returns Distionary<string,object>
                return VidpubJSON(results);
            }
            return View(results);
        }
        [HttpGet]
        public virtual ActionResult Details(int id) {
           var result = View(_table.FindBy(ID: id, schema: true));
           if (Request.IsAjaxRequest())
           {
               return VidpubJSON(result);
           }
           return View(result);
        }

       [HttpGet]
        public ActionResult Create() {
            return View(_table.Prototype);
        }

        [HttpPost]
       // [RequireAdmin]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(FormCollection collection) {
            var model = _table.CreateFrom(collection);
            try {
                // TODO: Add insert logic here
                _table.Insert(model);
                return RedirectToAction("Index");
            } catch (Exception x) {
                TempData["Error"] = "There was a problem adding this record";
                return View();
            }
        }

        //[RequireAdmin]
        [HttpGet]
        public virtual ActionResult Edit(int id) {
            var model = _table.Get(ID: id);
            model._Table = _table;
            return View(model);
        }

      //  [RequireAdmin]
        [HttpPut]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(int id, FormCollection collection) {
            var model = _table.CreateFrom(collection);
            try {
                // TODO: Add update logic here
                _table.Update(model, id);
                return RedirectToAction("Index");
            } catch (Exception x) {
                TempData["Error"] = "There was a problem editing this record";
                return View(model);
            }
        }

        //[RequireAdmin]
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(int id) {
            try {
                // TODO: Add delete logic here
                _table.Delete(id);
                return RedirectToAction("Index");
            } catch {
                TempData["Error"] = "There was a problem deleting this record";
            }
            return RedirectToAction("Index");
        }

      
    }//class

    
}//ns