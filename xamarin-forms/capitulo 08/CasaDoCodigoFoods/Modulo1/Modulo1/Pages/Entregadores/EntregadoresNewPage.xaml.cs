using Modulo1.Dal;
using Modulo1.Modelo;
using System;
using System.Linq;
using Xamarin.Forms;

namespace Modulo1.Pages.Entregadores
{
    public partial class EntregadoresNewPage : ContentPage
    {
        private EntregadorDAL dalEntregadores = EntregadorDAL.GetInstance();

        public EntregadoresNewPage()
        {
            InitializeComponent();
            PreparaParaNovoEntregador();
        }

        public void BtnGravarClick(object sender, EventArgs e)
        {
            if (nome.Text.Trim() == string.Empty || telefone.Text == string.Empty)
            {
                this.DisplayAlert("Erro",
                    "Você precisa informar o nome e telefone para o novo entregador.",
                    "Ok");
            }
            else
            {
                dalEntregadores.Add(new Entregador()
                {
                    Id = Convert.ToUInt32(identregador.Text),
                    Nome = nome.Text,
                    Telefone = telefone.Text
                });
                PreparaParaNovoEntregador();
            }
        }

        private void PreparaParaNovoEntregador()
        {
            var novoId = dalEntregadores.GetAll().Max(x => x.Id) + 1;
            identregador.Text = novoId.ToString().Trim();
            nome.Text = string.Empty;
            telefone.Text = string.Empty;
        }
    }
}
