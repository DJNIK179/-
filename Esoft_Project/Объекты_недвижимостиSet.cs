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
    
    public partial class Объекты_недвижимостиSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Объекты_недвижимостиSet()
        {
            this.ПредложенияSet = new HashSet<ПредложенияSet>();
        }
    
        public int Id { get; set; }
        public string Address_City { get; set; }
        public string Address_Street { get; set; }
        public string Address_House { get; set; }
        public string Address_Number { get; set; }
        public Nullable<double> Coordinate_latitude { get; set; }
        public Nullable<double> Coordinate_longitude { get; set; }
        public int Type { get; set; }
        public Nullable<double> TotalArea { get; set; }
        public Nullable<int> TotalFloors { get; set; }
        public Nullable<int> Rooms { get; set; }
        public Nullable<int> Floor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ПредложенияSet> ПредложенияSet { get; set; }
    }
}
