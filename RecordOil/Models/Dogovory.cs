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
    
    public partial class Dogovory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dogovory()
        {
            this.TableDog = new HashSet<TableDog>();
        }
    
        public int IdDog { get; set; }
        public string NumberDog { get; set; }
        public Nullable<System.DateTime> DateDog { get; set; }
        public Nullable<int> IdOrg { get; set; }
        public string UserModific { get; set; }
        public Nullable<System.DateTime> DateModific { get; set; }
        public string Primech { get; set; }
    
        public virtual Organization Organization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableDog> TableDog { get; set; }
    }
}
