using CadastroDeContatos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Controllers
{
    public class TelefoneController : Controller
    {
        private readonly BancoContext _context;

        public TelefoneController(BancoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var telefones = _context.Telefones.ToList();
            return View(telefones);
        }

        [HttpPost]
        public IActionResult Create(Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                _context.Telefones.Add(telefone);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(telefone);
        }

        public IActionResult Details(int id)
        {
            var telefone = _context.Telefones.Find(id);

            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        [HttpPost]
        public IActionResult Edit(Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(telefone).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(telefone);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var telefone = _context.Telefones.Find(id);

            if (telefone == null)
            {
                return NotFound();
            }

            _context.Telefones.Remove(telefone);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Comprar(int id)
        {
            var telefone = _context.Telefones.Find(id);

            if (telefone == null)
            {
                return NotFound();
            }

            // Verifica se há telefones disponíveis para comprar
            if (telefone.QuantidadeDisponivel > 0)
            {
                telefone.QuantidadeDisponivel -= 1;
                _context.SaveChanges();

                // Registre o histórico de compra
                var historicoCompra = new HistoricoCompra
                {
                    IdUsuario = /* Id do usuário logado ou alguma forma de identificação */,
                    IdTelefone = id,
                    DataCompra = DateTime.Now
                };
            }
            else
            {
                // Adicione uma lógica para lidar com a situação em que não há telefones disponíveis
                // Pode ser uma mensagem de erro ou redirecionamento para uma página específica
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var telefone = _context.Telefones.Find(id);

            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        public IActionResult Delete(int id)
        {
            var telefone = _context.Telefones.Find(id);

            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

    }

}
