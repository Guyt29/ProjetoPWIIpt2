using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimo.GerenciaArquivos;
using ProjetoEmprestimo.Models;
using ProjetoEmprestimo.Repository.Contract;

namespace ProjetoEmprestimo.Controllers
{
    public class LivroController : Controller
    {
        private ILivroRepository _livroRepository;
        

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Livro livro, IFormFile file)
        {
            var Caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

            livro.imagemLivro = Caminho;

            _livroRepository.Cadastrar(livro);

            ViewBag.msg = "Cadastro realizado";
            return View();
        }
    }
}
