//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace miPrimerProyecto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class cliente
    {
        internal object id_compra;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            this.compra = new HashSet<compra>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage ="El campo Nombre No puede ir vacio")]
        [StringLength(20, ErrorMessage ="supero el limite de 20 caracteres del campo Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage ="El campo Documento No puede ir vacio")]
        public string documento { get; set; }
        [Required(ErrorMessage = "El campo Email NO puede ir vacio")]
        public string email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compra> compra { get; set; }
    }
}
