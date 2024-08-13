using FiapFase1.Domain.Entities.Models;
using FiapFase1.Domain.Entities.Requests;
using FiapFase1.UI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FiapFase1.Interface.Pages.Contatos
{
    public class EditModel : PageModel
    {
        private readonly IContatoService _contatoService;
        private readonly IDDDService _idDDService;

        public EditModel(IContatoService contatoService, IDDDService idDDService)
        {
            _contatoService = contatoService;
            _idDDService = idDDService;
        }

        [BindProperty]
        public AtualizarContatoRequest atualizarContatoRequest { get; set; } = default;
        public List<DDD> DDDList { get; set; } = [];
        public List<SelectListItem> DDDs { get; set; } = [];

        public async Task<IActionResult> OnGetAsync(long id)
        {
            var contato = await _contatoService.ObterContatoPorId(id);
            if (contato == null)
            {
                return NotFound();
            }

            await LoadContato(contato);
            await LoadDDDs();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await LoadDDDs();
                    return Page();
                }

                await _contatoService.AtualizarContato(new AtualizarContatoRequest
                {
                    Id = atualizarContatoRequest.Id,
                    Nome = atualizarContatoRequest.Nome,
                    NrTelefone = atualizarContatoRequest.NrTelefone,
                    Email = atualizarContatoRequest.Email,
                    NrDDD = atualizarContatoRequest.NrDDD
                });

                TempData["AlertSuccess"] = "Contato atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["AlertDanger"] = $"Ocorreu um erro, Erro: {ex.Message}";
            }           

            return RedirectToPage("./Index");
        }

        private async Task LoadDDDs()
        {
            DDDList = await _idDDService.ObterTodosDDDs();

            DDDs.Add(new SelectListItem { Value = "", Text = "" });

            if (DDDList != null && DDDList.Any())
            {
                DDDs.AddRange(DDDList.Select(d => new SelectListItem
                {
                    Value = d.NrDDD.ToString(),
                    Text = d.NrDDD.ToString()
                }));
            }

            ViewData["NrDDD"] = DDDs;
        }

        private async Task LoadContato(Contato contato)
        {
            atualizarContatoRequest = new AtualizarContatoRequest
            {
                Email = contato.Email,
                Id = contato.Id,
                Nome = contato.Nome,
                NrDDD = contato.DDD.NrDDD,
                NrTelefone = contato.NrTelefone
            };
        }
    }
}
