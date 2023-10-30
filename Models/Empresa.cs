using System.ComponentModel.DataAnnotations;
namespace apiBodega.Models
{
    public class Empresa
    {
        [Key]
        public int EmpresaID { get; set; }
        [Required]
        public string NombreEmpresa {  get; set; }
        [Required]
        public string Resumen { get; set; }
    }
}
