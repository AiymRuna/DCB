//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ZayavkaStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ZayavkaStatus()
        {
            this.ZayavkaOtvet = new HashSet<ZayavkaOtvet>();
        }
    
        public int Id { get; set; }
        public string NmZStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZayavkaOtvet> ZayavkaOtvet { get; set; }
    }
}