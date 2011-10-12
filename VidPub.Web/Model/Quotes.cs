using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidPub.Web.Model
{
    public class Quotes
    {
        public static dynamic FromUsers()
        {
            var quotes = new string[]
            {
                "Harsh Bhasin"
                ,"Ritu Bhasin"
                ,"Ria Bhasin"
                ,"Saanvi Bhasin"
            };

            Random rnd = new Random();

            return quotes.OrderBy(x=> rnd.Next()).ToList();
        }
    }//
}//