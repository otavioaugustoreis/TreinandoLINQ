using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendizadosLINQ.Entities
{
    public class Carrinho
    {

        public int Id { get; set; }

        public Usuario usuario { get; set; }

        public List<CarrinhoProduto> carrinhoProdutos { get; set; }

        public Carrinho(int id, Usuario usuario)
        {
            Id = id;
            this.usuario = usuario;
            this.carrinhoProdutos = new List<CarrinhoProduto>();
        }

        public void AdicionarCarrinhoProduto(CarrinhoProduto carrinhoProduto)
        {
            carrinhoProdutos.Add(carrinhoProduto);
        }
        public Carrinho()
        {
        }

        public override string ToString()
        {
            var carrinhoProdutosStr = new StringBuilder("[\n");

            foreach (var item in carrinhoProdutos)
            {
                carrinhoProdutosStr.Append(
                    $"    {{\n" +
                    $"      \"Id\": {item.Id},\n" +
                    $"      \"Quantidade\": {item.Quantidade},\n" +
                    $"      \"Produto\": {{\n" +
                    $"        \"Id\": {item.Produto?.Id ?? 0},\n" +
                    $"        \"Nome\": \"{item.Produto?.Nome ?? "N/A"}\",\n" +
                    $"      }}\n" +
                    $"    }},\n"
                );
            }

            // Remove a vírgula extra no final do JSON
            if (carrinhoProdutos.Count > 0)
            {
                carrinhoProdutosStr.Remove(carrinhoProdutosStr.Length - 2, 1);
            }
            carrinhoProdutosStr.Append("  ]");

            return $"{{\n" +
                   $"  \"Id\": {Id},\n" +
                   $"  \"Usuario\": {{\n" +
                   $"    \"Id\": {usuario?.Id ?? 0},\n" +
                   $"    \"Nome\": \"{usuario?.Nome ?? "N/A"}\"\n" +
                   $"  }},\n" +
                   $"  \"CarrinhoProdutos\": {carrinhoProdutosStr}\n" +
                   $"}}";
        }

    }
}
