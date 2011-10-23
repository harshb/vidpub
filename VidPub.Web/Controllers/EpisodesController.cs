using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidPub.Web.Model;
using VidPub.Web.Infrastructure;
namespace VidPub.Web.Controllers{
    public class EpisodesController : CruddyController {
        public EpisodesController(ITokenHandler tokenStore):base(tokenStore) {
            _table = new Episodes();
            ViewBag.Table = _table;
        }
    }
}

