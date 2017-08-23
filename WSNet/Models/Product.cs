using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSNet.Models
{
    public class Product
    {
        public int      ID         { get; set; }
        public String   Name       { get; set; }
        public int      CategoryID { get; set; }
        public decimal? UnitPrice  { get; set; }
        public int      UnitsStock { get; set; }

        public virtual Category Category { get; set; }
    }
}