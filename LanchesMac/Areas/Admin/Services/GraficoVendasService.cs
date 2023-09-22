using LanchesMac.Context;
using LanchesMac.Models;

namespace LanchesMac.Areas.Admin.Services
{
    public class GraficoVendasService
    {
        private readonly AppDbContext _appDbContext;

        public GraficoVendasService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<LancheGrafico> GetVendasLanches(int dias=360)
        {
            var data = DateTime.Now.AddDays(-360);
            var lanches = (from pd in _appDbContext.PedidoDetalhes
                           join l in _appDbContext.Lanches on pd.LancheId equals l.LancheId
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LancheId, l.Nome, pd.Quantidade }
                           into g
                           select new 
                           {
                               LancheNome = g.Key.Nome,
                               LanchesQuantidade = g.Sum(q => q.Quantidade),
                               LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           });

            var lista = new List<LancheGrafico>();
            foreach(var item in lanches)
            {
                var lanche = new LancheGrafico();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQuantidade = item.LanchesQuantidade;
                lanche.LanchesValorTotal = item.LanchesValorTotal;
                lista.Add(lanche);
            }

            return lista;
        }
    }
}
