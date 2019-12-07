using Modulo1.Dal;
using Modulo1.Modelo;
using Plugin.Messaging;
using System;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Pages.Pedidos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidosPage : ContentPage
    {
        private PedidoDAL pedidoDAL = new PedidoDAL();

        public PedidosPage()
        {
            InitializeComponent();
            BtnNovoPedido.Clicked += BtnNovoPedidoClick;
        }

        // Captura do clique do botão de novo Pedido
        private async void BtnNovoPedidoClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PedidosNewPage());
        }

        // Captura do gesture da imagem de selecionar todos os pedidos
        private async void OnTappedTodos(object sender, EventArgs args)
        {
            lvClientes.ItemsSource = pedidoDAL.GetAllWithChildren();
            tituloConsulta.Text = "Todos os pedidos";
        }

        // Captura do gesture da imagem de selecionar todos os pedidos
        // ABERTOS. Como a chamada pode ocorrer em mais de um método,
        // foi implementado um específico para isso e aqui ele é chamado
        private async void OnTappedAbertos(object sender, EventArgs args)
        {
            SelecionarPedidosEmAberto();
        }

        // Captura do gesture da imagem de selecionar todos os pedidos
        // EM PRODUÇÃO
        private async void OnTappedEmProducao(object sender, EventArgs args)
        {
            lvClientes.ItemsSource = pedidoDAL.GetEmProducaoWithChildren();
            tituloConsulta.Text = "Pedidos em produção";
        }

        // Captura do gesture da imagem de selecionar todos os pedidos
        // EM ENTREGA
        private async void OnTappedEmEntrega(object sender, EventArgs args)
        {
            lvClientes.ItemsSource = pedidoDAL.GetEmEntregaWithChildren();
            tituloConsulta.Text = "Pedidos em entrega";
        }

        // Captura do gesture da imagem de selecionar todos os pedidos
        // JÁ ENTREGUES E FECHADOS
        private async void OnTappedFechados(object sender, EventArgs args)
        {
            lvClientes.ItemsSource = pedidoDAL.GetFechadosWithChildren();
            tituloConsulta.Text = "Pedidos fechados";
        }

        // Captura da Action Context para encaminhar pedido para PRODUÇÃO
        private async void OnProduzirClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var pedido = mi.CommandParameter as Pedido;
            if (!pedido.Situacao.Equals("Aberto"))
            {
                await DisplayAlert("Atenção", "Pedido precisa estar aberto", "Ok");
            }
            else
            {
                pedido.DataEHoraProducao = DateTime.Now;
                pedidoDAL.Update(pedido);
                var smsMessenger = CrossMessaging.Current.SmsMessenger;
                if (smsMessenger.CanSendSms)
                {
                    smsMessenger.SendSms(pedido.Cliente.Telefone, "Pedido " + pedido.PedidoId +
                        " enviado para a produção. CCFoods, obrigado pela preferência");
                }
                else
                {
                    await DisplayAlert("Atenção",
                        "O SMS não pôde ser enviado, mas o pedido foi enviado para a produção",
                        "Ok");
                    SelecionarPedidosEmAberto();
                }
            }
        }

        // Captura da Action Context para encaminhar pedido para ENTREGA
        private async void OnEntregarClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var pedido = mi.CommandParameter as Pedido;
            if (!pedido.Situacao.Equals("Produção"))
            {
                DisplayAlert("Atenção", "Pedido precisa estar em produção", "Ok");
            }
            else
            {
                pedido.DataEHoraEntrega = DateTime.Now;
                pedidoDAL.Update(pedido);
                DisplayAlert("Atualização", "Pedido enviado para a entrega", "Ok");
                SelecionarPedidosEmAberto();
            }
        }

        // Captura da Action Context para FECHAR Pedido
        private async void OnFecharClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var pedido = mi.CommandParameter as Pedido;
            if (!pedido.Situacao.Equals("Em entrega"))
            {
                DisplayAlert("Atenção", "Pedido precisa estar em entrega", "Ok");
            }
            else
            {
                pedido.DataEHoraEntregue = DateTime.Now;
                pedidoDAL.Update(pedido);
                DisplayAlert("Atualização", "Pedido finalizado com sucesso", "Ok");
                SelecionarPedidosEmAberto();
            }
        }

        // Sobrescrita de método
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SelecionarPedidosEmAberto();
        }

        // Método criado para selecionar todos os pedidos em aberto
        private void SelecionarPedidosEmAberto()
        {
            lvClientes.ItemsSource = pedidoDAL.GetAbertosWithChildren();
            tituloConsulta.Text = "Pedidos abertos";
        }

        // Método que captura o clique da action context para verificação de rota
        // de entrega
        private async void OnVerificarRotaClick(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var pedido = mi.CommandParameter as Pedido;
            var origem = "Av Jorge Schimmelpfeng 600 Centro Foz do Iguaçu Paraná";
            var endereco = pedido.Cliente.Endereco + " " + pedido.Cliente.Numero + " " +
                pedido.Cliente.Bairro + " " + pedido.Cliente.Cidade + " " + pedido.Cliente.Estado;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Device.OpenUri(
                        new Uri(string.Format("http://maps.apple.com/?saddr={0}&daddr={1}&dirflg=d",
                            WebUtility.UrlEncode(origem), WebUtility.UrlEncode(endereco))));
                    break;
                case Device.Android:
                    Device.OpenUri(
                        new Uri(string.Format("google.navigation:q={0}&mode=d", WebUtility.UrlEncode(endereco))));
                    break;
            }
        }

        // Método que captura a gesture no item da ListView
        private async void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new PedidosAcompanhamentoPage());
        }
    }
}