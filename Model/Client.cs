using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorTeste.Model
{
    public class Client
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        [StringLength(100, ErrorMessage = "O nome deve ser maior que 100 caracteres!")]
        [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres!")]
        [DisplayName("Nome Completo")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o e-mail!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        [DisplayName("E-mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o celular!")]
        [DisplayFormat(DataFormatString = "{0:(##) #####-####}")]
        [DisplayName("Celular")]
        public string CellPhone { get; set; } = string.Empty;

        public List<Order> Orders { get; set; } = new();
    }
}
