using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RazorTeste.Model
{
    public class Order
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o cliente!")]
        [DisplayName("Cliente")]
        public int ClientId { get; set; } = 0;

        public Client? Client { get; set; }

        [Required(ErrorMessage = "Informe o produto!")]
        [DisplayName("Produto")]
        public int ProductId { get; set; } = 0;

        public Product? Product { get; set; }

        [Required(ErrorMessage = "Informe o endereço de entraga")]
        [DisplayName("Endereço de entraga")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a quantidade!")]
        [DisplayName("Quantidade")]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Valor Total")]
        public double Amount { get; set; } = 0;

        [DataType(DataType.DateTime)]
        [DisplayName("Data da compra")]
        public DateTime DateOrder { get; set; }
    }
}
