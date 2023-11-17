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
    
    public partial class Nefteproduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nefteproduct()
        {
            this.OstatkiFilial = new HashSet<OstatkiFilial>();
            this.OstatSklad = new HashSet<OstatSklad>();
            this.TableDog = new HashSet<TableDog>();
            this.TableZay = new HashSet<TableZay>();
            this.TableZayTotal = new HashSet<TableZayTotal>();
            this.MassDostTotal = new HashSet<MassDostTotal>();
            this.OstatkiDelete = new HashSet<OstatkiDelete>();
            this.TableZayDelete = new HashSet<TableZayDelete>();
        }
    
        public int IdNeft { get; set; }
        public string Naimenovanie { get; set; }
        public Nullable<decimal> P { get; set; }
        public string UserModific { get; set; }
        public Nullable<System.DateTime> DateModific { get; set; }
        public string Primech { get; set; }
        public Nullable<int> PriznakIsp { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OstatkiFilial> OstatkiFilial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OstatSklad> OstatSklad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableDog> TableDog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableZay> TableZay { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableZayTotal> TableZayTotal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MassDostTotal> MassDostTotal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OstatkiDelete> OstatkiDelete { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableZayDelete> TableZayDelete { get; set; }
    }
}