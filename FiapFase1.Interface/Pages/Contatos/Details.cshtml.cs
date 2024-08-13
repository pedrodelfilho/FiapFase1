using FiapFase1.Domain.Entities.Models;
using FiapFase1.UI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FiapFase1.Interface.Pages.Contatos
{
    public class DetailsModel : PageModel
    {
        private readonly IContatoService _contatoService;

        public DetailsModel(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public Contato Contato { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            try
            {
                Contato = await _contatoService.ObterContatoPorId(id);

                if (Contato == null)
                {
                    return NotFound();
                }
            }            
            catch (Exception ex)
            {
                TempData["AlertDanger"] = $"Ocorreu um erro, Erro: {ex.Message}";
            }

            return Page();
        }
    }

}
