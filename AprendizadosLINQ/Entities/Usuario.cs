using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendizadosLINQ.Entities
{
    public class Usuario
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }
        public List<Pedido> ListPedidos { get; set; } = new List<Pedido>();

        public void AdicionarPedidoItem(Pedido pedido)
        {
            ListPedidos.Add(pedido);
        }

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }


        public Usuario()
        {
        }

        public override string ToString()
        {
            return $"{{\n" +
                   $"  \"Id\": {Id},\n" +
                   $"  \"Nome\": \"{Nome}\"\n" +
                   $"  \"Idade\": \"{Idade}\"\n" +
                   $"}}";
        }
    }
}
