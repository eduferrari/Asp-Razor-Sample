using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RazorTeste.Model
{
    public class Product
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        [StringLength(80, ErrorMessage = "O nome deve ser maior que 80 caracteres!")]
        [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres!")]
        [DisplayName("Nome")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o valor!")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [DisplayName("Preço")]
        public double Price { get; set; } = 0;

        public List<Order> Orders { get; set; } = new();
    }
}
