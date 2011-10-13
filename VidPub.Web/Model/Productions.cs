using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;
using System.Dynamic;
//using System.Data.SqlServerCe;

namespace VidPub.Web.Model
{
    public class Productions:DynamicModel
    {
        //ConnStr,Table,Primary
        public Productions() : base("VidPub", "Productions", "ID") { }
    }
}