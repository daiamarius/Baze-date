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
    
    public partial class getHotelPhotos_Result
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public byte[] Poza { get; set; }
        public System.DateTime Data { get; set; }
        getHotelPhotos_Result()
        {

        }

        public getHotelPhotos_Result(string nume, string prenume, byte[] poza)
        {
            Nume = nume;
            Prenume = prenume;
            Poza = poza;

        }
    }
}