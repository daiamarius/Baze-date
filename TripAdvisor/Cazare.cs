//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TripAdvisor
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cazare
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cazare()
        {
            this.Camere = new HashSet<Camere>();
            this.PozeHotel = new HashSet<PozeHotel>();
            this.RecenziiHoteluri = new HashSet<RecenziiHoteluri>();
        }
    
        public int CazareID { get; set; }
        public int OrasID { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public int Stele { get; set; }
        public string NrTelefon { get; set; }
        public string Email { get; set; }
        public byte[] Poza { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Camere> Camere { get; set; }
        public virtual Orase Orase { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PozeHotel> PozeHotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecenziiHoteluri> RecenziiHoteluri { get; set; }
    }
}
