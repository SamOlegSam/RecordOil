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
    
    public partial class Rezervuary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rezervuary()
        {
            this.OstatkiFilial = new HashSet<OstatkiFilial>();
        }
    
        public int IdRez { get; set; }
        public string Naimenovanie { get; set; }
        public Nullable<decimal> Vpolezn { get; set; }
        public string UserModific { get; set; }
        public Nullable<System.DateTime> DateModific { get; set; }
        public Nullable<decimal> Vitog { get; set; }
        public Nullable<int> idSklad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OstatkiFilial> OstatkiFilial { get; set; }
        public virtual Sklad Sklad { get; set; }
    }
}