using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;
using System.Dynamic;
//using System.Data.SqlServerCe;

namespace VidPub.Web.Model
{
    public class Customers : DynamicModel
    {
        //ConnStr,Table,Primary
        public Customers() 
            : base("VidPub", "Customers", "ID","Email")
        {
        }

        public dynamic FuzzySearch(string query)
        {
            return this.Query(@"select ID, email as Title from customers
                            where email LIKE('%'+@0+'%')", query);
        }
    }
}