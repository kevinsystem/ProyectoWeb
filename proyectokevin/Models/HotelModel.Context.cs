﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyectokevin.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hotel_vangohEntities : DbContext
    {
        public hotel_vangohEntities()
            : base("name=hotel_vangohEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<comprobante> comprobante { get; set; }
        public virtual DbSet<comprobante_detalle> comprobante_detalle { get; set; }
        public virtual DbSet<habitacion> habitacion { get; set; }
        public virtual DbSet<reserva> reserva { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<tipo_cliente> tipo_cliente { get; set; }
        public virtual DbSet<tipo_habitacion> tipo_habitacion { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
