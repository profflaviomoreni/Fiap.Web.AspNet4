using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet4.ViewModel
{
    public class ProdutoNovoViewModel
    {

        public string ProdutoNome { get; set; } // Nome digitado pelo usuário

        public SelectList Lojas { get; set; } // Exibição de todas as lojas no combo

        public ICollection<int> LojaId { get; set; } // Lojas selecionados pelo usuário

    }
}
