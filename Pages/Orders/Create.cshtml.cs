using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorTeste.Data;
using RazorTeste.Model;

namespace RazorTeste.Pages_Orders
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Clients"] = new SelectList(_context.Clients, "Id", "Name");
            ViewData["Products"] = new SelectList(_context.Products, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Orders == null || Order == null)
            {
                return Page();
            }

            Order.Amount = AtualizaValorPedido(Order.ProductId, Order.Quantity);

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private double AtualizaValorPedido(int productId, int quantity)
        {
            var _produto = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (_produto == null) return 0;

            return _produto.Price * quantity;
        }
    }
}
