//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Esoft_Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class ПредложенияSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ПредложенияSet()
        {
            this.СделкиSet = new HashSet<СделкиSet>();
        }
    
        public int Id { get; set; }
        public int IdAgent { get; set; }
        public int IdClient { get; set; }
        public int IdRealEstate { get; set; }
        public long Price { get; set; }
    
        public virtual КлиентыSet КлиентыSet { get; set; }
        public virtual Объекты_недвижимостиSet Объекты_недвижимостиSet { get; set; }
        public virtual РиэлторSet РиэлторSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<СделкиSet> СделкиSet { get; set; }
    }
}
