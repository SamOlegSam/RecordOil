using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordOil.Models
{
    public class TabOst
    {        
        public DateTime Date { get; set; }        
        public Decimal Mass { get; set; }
        public string IdNeft { get; set; }
        public int IdSklad { get; set; }
        public string Prim { get; set; }
        public string UserM { get; set; }
        public DateTime DateM { get; set; }
    }
}