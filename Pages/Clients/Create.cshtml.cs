using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTeste.Data;
using RazorTeste.Model;

namespace RazorTeste.Pages_Clients
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
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Clients == null || Client == null)
            {
                return Page();
            }

            if (ValidaSeCadastroExiste(Client.Email))
            {
                ModelState.AddModelError("", "Já existe um cliente cadastrado com esse e-mail!");
                return Page();
            }

            _context.Clients.Add(Client);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private bool ValidaSeCadastroExiste(string email) =>
            _context.Clients.Where(x => x.Email == email).Any();
    }
}
