using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidPub.Web.Infrastructure;
using VidPub.Web.Model;

namespace VidPub.Web.Controllers
{
    public class ApplicationController : Controller
    {
       public  ITokenHandler TokenStore;

        public ApplicationController()
        {

        }
        public ApplicationController(ITokenHandler tokenStore)
        {
            TokenStore = tokenStore;

            //initialize this
            ViewBag.CurrentUser = CurrentUser ?? new { Email = "" };
        }

        public bool IsLoggedIn
        {
            get
            {
               
                return CurrentUser != null;
            }
        }

        dynamic _currentUser;
        public dynamic CurrentUser
        {
            get
            {
                var token = TokenStore.GetToken();
                if  (!String.IsNullOrEmpty(token))
                {
                    _currentUser = Users.FindByToken(token);

                    if (_currentUser == null)
                    {
                        //another user logged in
                        //force the current user to be logged out...
                        TokenStore.RemoveClientAccess();
                    }
                }

               

                //Hip to be null...
                return _currentUser;
            }



        }//








    }
}
