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

        public dynamic FuzzySearch(string query)
        {
            return this.Query(@"select ID, Title from productions
                            where title LIKE('%'+@0+'%')
                            or description LIKE('%'+@0+'%')
                            or slug LIKE('%'+@0+'%')
                            ", query);
        }
    }

}