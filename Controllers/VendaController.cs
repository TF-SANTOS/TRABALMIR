using CadastroDeContatos.Data;
using Microsoft.AspNetCore.Mvc;

public class PivotDataViewModel
{
    public DateTime Data { get; set; }
    public List<ProdutoViewModel> Produtos { get; set; }
}

public class ProdutoViewModel
{
    public string Produto { get; set; }
    public decimal ValorTotal { get; set; }
}

public class VendaController : Controller
{
    private readonly BancoContext _context;

    public VendaController(BancoContext context)
    {
        _context = context;
    }

    // Ação para exibir a tabela PIVOT
    public IActionResult Index()
    {
        var pivotData = _context.Vendas
            .GroupBy(v => v.Data)
            .OrderBy(g => g.Key)
            .Select(g => new PivotDataViewModel
            {
                Data = g.Key,
                Produtos = g.GroupBy(v => v.Produto)
                             .Select(pg => new ProdutoViewModel
                             {
                                 Produto = pg.Key,
                                 ValorTotal = pg.Sum(v => v.Valor)
                             })
                             .OrderBy(pg => pg.Produto)
                             .ToList()
            })
            .ToList();

        return View(pivotData);
    }


    //AGRUPAMENTO
    public IActionResult Index50()
    {
        var pivotData50 = _context.Vendas
            .OrderBy(v => v.Data)
            .GroupBy(v => v.Data)
            .Select(g => new PivotDataViewModel
            {
                Data = g.Key,
                Produtos = g.GroupBy(v => v.Produto)
                             .Select(pg => new ProdutoViewModel
                             {
                                 Produto = pg.Key,
                                 ValorTotal = pg.Sum(v => v.Valor)
                             })
                             .OrderBy(pg => pg.Produto)
                             .ToList()
            })
            .ToList();

        return View(pivotData50);
    }

}
