using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendizadosLINQ.Entities
{
    public class Produto
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public List<CarrinhoProduto> carrinhoProdutos { get; set; } = new List<CarrinhoProduto>();

        public ICollection<PedidoItem> ListPedidosItens { get; set; } = new List<PedidoItem>();

        public Produto(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public void AdicionarPedidoItem(PedidoItem pedido)
        {
            ListPedidosItens.Add(pedido);
        }

        public void AdicionarCarrinhoProduto(CarrinhoProduto carrinhoProduto)
        {
            carrinhoProdutos.Add(carrinhoProduto);
        }
        public override string ToString()
        {
            return $"{{\n" +
               $"  \"Id\": {Id},\n" +
               $"  \"Nome\": \"{Nome}\",\n" +
               $"  \"Descricao\": \"{Descricao}\"\n" +
               $"}}"; 
        }


    }
}
