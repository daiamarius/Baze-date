﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TripAdvisorEntities : DbContext
    {
        public TripAdvisorEntities()
            : base("name=TripAdvisorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Camere> Camere { get; set; }
        public virtual DbSet<CategoriiObiective> CategoriiObiective { get; set; }
        public virtual DbSet<Cazare> Cazare { get; set; }
        public virtual DbSet<Obiective> Obiective { get; set; }
        public virtual DbSet<Orase> Orase { get; set; }
        public virtual DbSet<Preparate> Preparate { get; set; }
        public virtual DbSet<RecenziiActivitati> RecenziiActivitati { get; set; }
        public virtual DbSet<RecenziiHoteluri> RecenziiHoteluri { get; set; }
        public virtual DbSet<RecenziiRestaurante> RecenziiRestaurante { get; set; }
        public virtual DbSet<Restaurante> Restaurante { get; set; }
        public virtual DbSet<Tari> Tari { get; set; }
        public virtual DbSet<Utilizatori> Utilizatori { get; set; }
        public virtual DbSet<PozeActivitati> PozeActivitati { get; set; }
        public virtual DbSet<PozeHotel> PozeHotel { get; set; }
        public virtual DbSet<PozeRestaurante> PozeRestaurante { get; set; }
        public virtual DbSet<Rezervari> Rezervari { get; set; }
    
        public virtual ObjectResult<getPreparate_Result> getPreparate(string oras)
        {
            var orasParameter = oras != null ?
                new ObjectParameter("Oras", oras) :
                new ObjectParameter("Oras", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPreparate_Result>("getPreparate", orasParameter);
        }
    
        public virtual ObjectResult<getRestaurantDetails_Result> getRestaurantDetails(Nullable<int> restId)
        {
            var restIdParameter = restId.HasValue ?
                new ObjectParameter("restId", restId) :
                new ObjectParameter("restId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRestaurantDetails_Result>("getRestaurantDetails", restIdParameter);
        }
    
        public virtual ObjectResult<string> getRestaurantMenu(Nullable<int> restId)
        {
            var restIdParameter = restId.HasValue ?
                new ObjectParameter("restId", restId) :
                new ObjectParameter("restId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("getRestaurantMenu", restIdParameter);
        }
    
        public virtual ObjectResult<getRestaurantPhotos_Result> getRestaurantPhotos(Nullable<int> restaurantID)
        {
            var restaurantIDParameter = restaurantID.HasValue ?
                new ObjectParameter("restaurantID", restaurantID) :
                new ObjectParameter("restaurantID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRestaurantPhotos_Result>("getRestaurantPhotos", restaurantIDParameter);
        }
    
        public virtual ObjectResult<getRestaurantReviews_Result> getRestaurantReviews(Nullable<int> restId)
        {
            var restIdParameter = restId.HasValue ?
                new ObjectParameter("restId", restId) :
                new ObjectParameter("restId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRestaurantReviews_Result>("getRestaurantReviews", restIdParameter);
        }
    
        public virtual ObjectResult<getRestaurants_Result> getRestaurants(string oras)
        {
            var orasParameter = oras != null ?
                new ObjectParameter("Oras", oras) :
                new ObjectParameter("Oras", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRestaurants_Result>("getRestaurants", orasParameter);
        }
    
        public virtual ObjectResult<getRestaurantsByFood_Result> getRestaurantsByFood(string oras, Nullable<int> foodtype)
        {
            var orasParameter = oras != null ?
                new ObjectParameter("Oras", oras) :
                new ObjectParameter("Oras", typeof(string));
    
            var foodtypeParameter = foodtype.HasValue ?
                new ObjectParameter("Foodtype", foodtype) :
                new ObjectParameter("Foodtype", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRestaurantsByFood_Result>("getRestaurantsByFood", orasParameter, foodtypeParameter);
        }
    
        public virtual ObjectResult<getTop3Restaurants_Result> getTop3Restaurants(string oras)
        {
            var orasParameter = oras != null ?
                new ObjectParameter("Oras", oras) :
                new ObjectParameter("Oras", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getTop3Restaurants_Result>("getTop3Restaurants", orasParameter);
        }
    }
}
