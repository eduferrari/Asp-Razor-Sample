using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorTeste.Data;
using RazorTeste.Model;

namespace RazorTeste.Pages_Orders
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);
            if (order == null) return NotFound();

            Order = order;
            ViewData["Clients"] = new SelectList(_context.Clients, "Id", "Name", order.ClientId); ;
            ViewData["Products"] = new SelectList(_context.Products, "Id", "Name", order.ProductId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                Order.Amount = AtualizaValorPedido(Order.ProductId, Order.Quantity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private double AtualizaValorPedido(int productId, int quantity)
        {
            var _produto = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (_produto == null) return 0;

            return _produto.Price * quantity;
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
