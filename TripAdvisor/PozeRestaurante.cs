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
    
    public partial class PozeRestaurante
    {
        public int RestaurantID { get; set; }
        public int UserID { get; set; }
        public byte[] Poza { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
    
        public virtual Restaurante Restaurante { get; set; }
        public virtual Utilizatori Utilizatori { get; set; }
    }
}
