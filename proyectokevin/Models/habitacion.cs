//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class habitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public habitacion()
        {
            this.reserva = new HashSet<reserva>();
        }
    
        public int id { get; set; }
        public string hab_codigo { get; set; }
        public string hab_descripcion { get; set; }
        public string hab_fotop { get; set; }
        public Nullable<decimal> hab_precio { get; set; }
        public int tih_id { get; set; }
    
        public virtual tipo_habitacion tipo_habitacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserva> reserva { get; set; }
    }
}
