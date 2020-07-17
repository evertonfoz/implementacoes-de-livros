using Modulo1.Dal;
using Modulo1.Modelo;
using Modulo1.Paginas.Clientes;
using Modulo1.Paginas.ItensCardapio;
using System;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.Pedidos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidosNewPage : ContentPage
    {
        private DateTime DataEHoraAbertura;
        private ObservableCollection<ItemPedido> itensPedido = new ObservableCollection<ItemPedido>();
        private ItemCardapioDAL itemCardapioDAL = new ItemCardapioDAL();
        private PedidoDAL pedidoDAL = new PedidoDAL();
        private ClienteDAL clienteDAL = new ClienteDAL();
        private Pedido pedido = null;

        public PedidosNewPage()
        {
            InitializeComponent();
            DataEHoraAbertura = DateTime.Now;
            lblDataEHoraAbertura.Text = "Abertura: " + DataEHoraAbertura.ToString();
            BtnInserirItem.Clicked += BtnInserirItemClicked;
            BtnRegistrarPedido.Clicked += BtnRegistrarPedidoClicked;
            lvItens.ItemsSource = itensPedido;
        }

        private async void BtnRegistrarPedidoClicked(object sender, EventArgs e)
        {
            if (itensPedido.Count == 0)
            {
                await DisplayAlert("Sem itens", "Informe ao menos um item para o pedido", "Ok");
            }
            else
            {
                PreparePedidoToPersist();
                ClearControls();
                await DisplayAlert("Pedido inserido", "Pedido foi registrado com sucesso", "Ok");
            }
        }

        private void ClearControls()
        {
            itensPedido.Clear();
            nomeCliente.Text = "Selecione o Cliente";
            nomeItem.Text = "Selecione o item";
            idCliente.Text = "";
            idItem.Text = "";
        }

        private void PreparePedidoToPersist()
        {
            pedido.Itens = itensPedido.ToList();
            pedido.DataEHoraPedido = DateTime.Now;
            pedido.Cliente = clienteDAL.GetClienteById(Convert.ToUInt32(idCliente.Text));
            pedido.ClienteId = pedido.Cliente.ClienteId;
            pedidoDAL.Add(pedido);
        }

        private async void BtnInserirItemClicked(object sender, EventArgs e)
        {
            if (idCliente.Text.Trim() == string.Empty || idItem.Text.Trim() == string.Empty)
            {
                await DisplayAlert("Dados incompletos", "Informe um cliente e um item de cardápio", "Ok");
            }
            else
            {
                if (pedido == null)
                {
                    this.pedido = new Pedido();
                }
                var itemCardapio = itemCardapioDAL.GetItemById(Convert.ToInt32(idItem.Text));
                itensPedido.Add(new ItemPedido()
                {
                    ItemCardapio = itemCardapio,
                    ItemCardapioId = itemCardapio.ItemCardapioId,
                    ValorUnitario = itemCardapio.Preco,
                    Quantidade = Convert.ToInt32(quantidadeItem.Text),
                    Pedido = this.pedido
                });

                lblTotalPedido.Text = "Total: R$ " + itensPedido.Sum(i => (i.Quantidade * i.ValorUnitario)).ToString("N2");
                nomeItem.Text = "Selecione o item";
                idItem.Text = "";
            }
        }

        private async void OnTapLookForClientes(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ClientesSearchPage(idCliente, nomeCliente));
        }

        private async void OnTapLookForItens(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ItensCardapioSearchPage(idItem, nomeItem));
        }
    }
}