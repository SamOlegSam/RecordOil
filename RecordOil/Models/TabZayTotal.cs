using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordOil.Models
{
    public class TabZayTotal
    {
        public int ID { get; set; }
        public string neftTotal { get; set; }
        public string filialTotal { get; set; }
        public Decimal OstTotal { get; set; }
        public Decimal PotrebTotal { get; set; }
        public Decimal DostavkaTotal { get; set; }
        public Decimal NalSkladTotal { get; set; }
        public Decimal PlanVITOG { get; set; }
    }
}