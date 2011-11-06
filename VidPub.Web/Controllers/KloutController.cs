using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidPub.Web.Model;
using VidPub.Web.Infrastructure;
using System.Dynamic;
using System.Web.Script.Serialization;
namespace VidPub.Web.Controllers{
    public class KloutController : Controller
    {
        public ActionResult Index()
        {
            dynamic users = new List<dynamic>();

            users.Add(new ExpandoObject());
            users[0].Name = "Patrick Hines";

            return VidpubJSON(users);
        }
        public ActionResult VidpubJSON(dynamic content)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new JavaScriptConverter[] { new ExpandoObjectConverter() });
            var json = serializer.Serialize(content);
            Response.ContentType = "application/json";
            return Content(json);
        }
    }
}

