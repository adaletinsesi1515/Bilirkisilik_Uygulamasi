//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bilirkisilik_Uygulamasi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_BIRIMLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_BIRIMLER()
        {
            this.TBL_BILIRKISILIK = new HashSet<TBL_BILIRKISILIK>();
        }
    
        public int ID { get; set; }
        public string BIRIMAD { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_BILIRKISILIK> TBL_BILIRKISILIK { get; set; }
    }
}
