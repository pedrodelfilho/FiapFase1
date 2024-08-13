using FiapFase1.Domain.Entities.Models;
using FiapFase1.UI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FiapFase1.Interface.Pages.Contatos
{
    public class DeleteModel : PageModel
    {
        private readonly IContatoService _contatoService;

        public DeleteModel(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public Contato Contato { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            Contato = await _contatoService.ObterContatoPorId(id);

            if (Contato == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            try
            {
                await _contatoService.RemoverContato(id);
                TempData["AlertSuccess"] = "Contato removido com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["AlertDanger"] = $"Ocorreu um erro, Erro: {ex.Message}";
            }

            return RedirectToPage("/Contatos/Index");
        }
    }

}
