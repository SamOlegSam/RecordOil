//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecordOil.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TableZay
    {
        public int IdTable { get; set; }
        public Nullable<int> IdNeftep { get; set; }
        public Nullable<decimal> Massa { get; set; }
        public string PlanJob { get; set; }
        public string Prim { get; set; }
        public string UserModific { get; set; }
        public Nullable<System.DateTime> DateModific { get; set; }
        public Nullable<int> IdZay { get; set; }
        public int IdSklad { get; set; }
    
        public virtual Nefteproduct Nefteproduct { get; set; }
        public virtual Sklad Sklad { get; set; }
        public virtual Sklad Sklad1 { get; set; }
        public virtual Zayavka Zayavka { get; set; }
    }
}
