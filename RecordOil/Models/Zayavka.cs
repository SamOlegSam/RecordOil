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
    
    public partial class Zayavka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zayavka()
        {
            this.TableZay = new HashSet<TableZay>();
        }
    
        public int IdZay { get; set; }
        public Nullable<System.DateTime> DateZay { get; set; }
        public Nullable<System.DateTime> DatePlan { get; set; }
        public Nullable<int> IdOrg { get; set; }
        public string UserModific { get; set; }
        public Nullable<System.DateTime> DateModific { get; set; }
        public Nullable<int> Priznak { get; set; }
        public string Number { get; set; }
        public Nullable<int> IdSk { get; set; }
        public string UserSoglas { get; set; }
        public Nullable<System.DateTime> DateSoglas { get; set; }
        public Nullable<int> NumberSch { get; set; }
    
        public virtual Organization Organization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableZay> TableZay { get; set; }
    }
}
