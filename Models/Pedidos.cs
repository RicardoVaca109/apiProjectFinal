using System.ComponentModel.DataAnnotations;

namespace apiBodega.Models
{
    public class Pedidos
    {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        public int CtdProducto { get; set; }
        [Required]
        public int ProveedorId { get; set; }
    }
}
