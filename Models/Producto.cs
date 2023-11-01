using System.ComponentModel.DataAnnotations;

namespace apiBodega.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public int CtdenStock { get; set; }
        [Required]
        public int ProveedorId { get; set; }
    }
}
