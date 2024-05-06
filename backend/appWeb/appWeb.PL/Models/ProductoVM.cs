using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace appWeb.PL.Models
{
    public class ProductoVM
    {
        [Key]
        [JsonPropertyName("idproducto")]
        public int Idproducto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La descripción del producto es obligatorio.")]
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "La cantidad del producto es obligatorio.")]
        [JsonPropertyName("cantidad")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El Precio del producto debe tener hasta dos decimales.")]
        [JsonPropertyName("precio")]
        public string Precio { get; set; }
    }
}
