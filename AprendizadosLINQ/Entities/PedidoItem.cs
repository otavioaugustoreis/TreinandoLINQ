using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendizadosLINQ.Entities
{
    public class PedidoItem
    {

        public int Id { get; set; }

        public int Quantidade { get; set; }

        public Produto Produto { get; set; }

        public Pedido Pedido { get; set; }

        public PedidoItem(int id, int quantidade, Produto produto, Pedido pedido)
        {
            Id = id;
            Quantidade = quantidade;
            Produto = produto;
            Pedido = pedido;
        }

        public PedidoItem()
        {
        }

        public override string ToString()
        {
            return $"{{\n" +
               $"  \"Id\": {Id},\n" +
               $"  \"Quantidade\": {Quantidade},\n" +
               $"  \"Produto\": {{\n" +
               $"    \"Id\": {Produto?.Id ?? 0},\n" +
               $"    \"Nome\": \"{Produto?.Nome ?? "N/A"}\"\n" +
               $"  }}\n" +
               $"}}";
        }
    }
}
