using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AprendizadosLINQ.Entities
{
    public class CarrinhoProduto
    {

        public int Id { get; set; }
        public Carrinho Carrinho { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public CarrinhoProduto(int id, Carrinho carrinho, Produto produto, int quantidade)
        {
            Id = id;
            this.Carrinho = carrinho;
            this.Produto = produto;
            Quantidade = quantidade;
        }

        public CarrinhoProduto()
        {
        }

        public override string ToString()
        {
            return  $"{{\n" +
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
