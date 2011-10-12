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
                @"Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia
                Curae; Cras ornare mattis nunc. Mauris venenatis, pede sed aliquet vehicula, lectus
                tellus pulvinar neque, non cursus sem nisi vel augue. </br><b>--John Smith </b>"
                ,"Ritu Bhasin"
                ,"Ria Bhasin"
                ,"Saanvi Bhasin"
            };

            Random rnd = new Random();

            return quotes.OrderBy(x=> rnd.Next()).ToList();
        }
    }//
}//