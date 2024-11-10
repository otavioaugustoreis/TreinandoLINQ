// See https://aka.ms/new-console-template for more information


using AprendizadosLINQ.Entities;
using System.ComponentModel;

List<Produto> listaProduto = new List<Produto>()
{
    new Produto(1, "Pizza", "Pizza de muzzarela"),
    new Produto(2, "Hamburguer", "Pizza de muzzarela"),
    new Produto(3, "Tapioca", "Pizza de muzzarela"),
};

Usuario u1 = new Usuario(1, "Otavio");

Carrinho c1 = new Carrinho(1, u1);

CarrinhoProduto carrinhoProduto = GerarCarrinhoProduto(c1, listaProduto);

Pedido pedido = new Pedido(1, u1);

List<Produto> produtos = ConsultarProdutosDoCarrinho(c1);

GerarPedidoItem(pedido, c1);

Console.WriteLine(pedido);


#region LINQ

//var pedidoEspecifico = pedido.ListPedidosItens
//    .Where(p => p.Produto.Id == 2 && p.Pedido.Usuario.Id == 1)
//    .ToList();

//pedidoEspecifico.ForEach(p =>
//{
//    // Console.WriteLine(p);
//});

//var x = listaProduto
//    .Where(p => p.Id > 1)
//    .OrderBy(p => p.Nome)
//    .ToList();

//x.ForEach(p =>
//{
//   // Console.WriteLine(p);
//});

//var nsei = pedido.ListPedidosItens
//    .Where(p => p.Id == 3)
//    .Select(p => p.Produto.Id * 2)
//    .ToList();

//nsei.ForEach(p =>
//{
//    // Console.WriteLine(p);
//});

//PedidoItem pedidoEspecifico2 = pedido.ListPedidosItens.FirstOrDefault(p => p.Produto.Id == 1);
////Console.WriteLine(pedidoEspecifico2);
#endregion

#region ForEach

//List<PedidoItem> listaPedidoItem = new List<PedidoItem>()
//{
//    new PedidoItem(1, 2, listaProduto[0], pedido),
//    new PedidoItem(2, 3, listaProduto[1], pedido),
//    new PedidoItem(3, 1, listaProduto[2], pedido),
//};

//int x = 0;
//listaProduto.ForEach(p =>
//{
//    if (x < listaPedidoItem.Count)
//    {
//        p.AdicionarPedidoItem(listaPedidoItem[x]);
//        pedido.AdicionarPedidoItem(listaPedidoItem[x]);
//        x++;
//    }
//});
#endregion

#region Functions
CarrinhoProduto GerarCarrinhoProduto(Carrinho carrinho, List<Produto> produtos)
{
    CarrinhoProduto x = null;
    int id = 1;
    int qtd = 2;
    produtos.ForEach(p =>
    {
        x = new CarrinhoProduto(id, carrinho, p, qtd);
        p.AdicionarCarrinhoProduto(x);
        carrinho.AdicionarCarrinhoProduto(x);
        id++;
        qtd++;
    });

    return x;
}
PedidoItem GerarPedidoItem(Pedido pedido, Carrinho carrinho)
{
    PedidoItem pedidoItem = null;
    int id = 1;

    foreach (var item in carrinho.carrinhoProdutos)
    {
        pedidoItem = new PedidoItem(id, item.Quantidade, item.Produto, pedido);
        pedido.AdicionarPedidoItem(pedidoItem);
        item.Produto.AdicionarPedidoItem(pedidoItem);
        id++;
    }
    return pedidoItem;
}

List<Produto> ConsultarProdutosDoPedido(Pedido pedido) => pedido.ListPedidosItens.Select(item => item.Produto).ToList();
List<Produto> ConsultarProdutosDoCarrinho(Carrinho carrinho) => carrinho.carrinhoProdutos.Select(p => p.Produto).ToList();
#endregion


