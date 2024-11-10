using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendizadosLINQ.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<PedidoItem> ListPedidosItens { get; set; } = new List<PedidoItem>();


        public void AdicionarPedidoItem(PedidoItem pedido)
        {
            ListPedidosItens.Add(pedido);
        }

        public Pedido(int id, Usuario usuario)
        {
            Id = id;
            Usuario = usuario;
        }

        public Pedido()
        {
        }

        public override string ToString()
        {
            var pedidoItensStr = new StringBuilder("[\n");

            foreach (var item in ListPedidosItens)
            {
                pedidoItensStr.Append(
                    $"    {{\n" +
                    $"      \"Id\": {item.Id},\n" +
                    $"      \"Quantidade\": {item.Quantidade},\n" +
                    $"      \"Produto\": {{\n" +
                    $"        \"Id\": {item.Produto?.Id ?? 0},\n" +
                    $"        \"Nome\": \"{item.Produto?.Nome ?? "N/A"}\"\n" +
                    $"      }}\n" +
                    $"    }},\n"
                );
            }

     
            if (ListPedidosItens.Count > 0)
            {
                pedidoItensStr.Remove(pedidoItensStr.Length - 2, 1);
            }
            pedidoItensStr.Append("  ]");

            return $"{{\n" +
                   $"  \"Id\": {Id},\n" +
                   $"  \"Usuario\": {{\n" +
                   $"    \"Id\": {Usuario?.Id ?? 0},\n" +
                   $"    \"Nome\": \"{Usuario?.Nome ?? "N/A"}\"\n" +
                   $"    \"Idade\": \"{Usuario?.Idade ?? 0}\"\n" +
                   $"  }},\n" +
                   $"  \"ListPedidosItens\": {pedidoItensStr}\n" +
                   $"}}";
        }
    }
}
