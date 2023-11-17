using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordOil.Models
{
    public class TabZay
    {
        public int IdZay { get; set; }
        public string NeftZay { get; set; }
        public Decimal Massa { get; set; }
        public string Plan { get; set; }
        public string Prich { get; set; }
       public int IdSklad { get; set; }
    }
}