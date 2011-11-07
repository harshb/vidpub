using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidPub.Web.Model;
using VidPub.Web.Infrastructure;
using VidPub.Web.Controllers;
using Massive;
using System.Dynamic;
namespace VidPub.Web.Areas.Api.Controllers
{
    public class ProductionsController : ApplicationController
    {
        DynamicModel _productions;
        public ProductionsController(ITokenHandler tokenStore)
            : base(tokenStore)
        {
            _productions = new Productions();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return VidpubJSON(_productions.All());
        }

        [HttpPut]
        public ActionResult Edit()
        {
            var model = SqueezeJson();
            _productions.Update(model, model.ID);
            return VidpubJSON(model);
        }

        [HttpPost]
        public ActionResult Create()
        {
            var model = SqueezeJson();
            _productions.Insert(model);
            return VidpubJSON(model);
        }

        ///api/productions/authors
        //to test combo box
        [HttpGet]
        public ActionResult authors()
        {
            dynamic authors = new List<dynamic>();
            authors.Add(new ExpandoObject());
            authors[0].Text = "hb";
            authors[0].Value = "1";

            authors.Add(new ExpandoObject());
            authors[1].Text = "Joe Blow";
            authors[1].Value = "2";

            return VidpubJSON(authors);

        }
    }//
}//

