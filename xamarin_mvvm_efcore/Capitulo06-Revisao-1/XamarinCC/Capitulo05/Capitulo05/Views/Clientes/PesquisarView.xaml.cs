using Capitulo05.ViewModels.Clientes;
using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo05.Views.Clientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PesquisarView : ContentPage
    {
        private PesquisarViewModel viewModel;
        public static Cliente ClienteSelecionado { get; set; }
        public PesquisarView()
        {
            InitializeComponent();
            viewModel = new PesquisarViewModel();
            BindingContext = viewModel;
            ClienteSelecionado = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Cliente>(this, "ClienteSelecionado",
                (cliente) =>
                {
                    ClienteSelecionado = cliente;
                    Navigation.PopAsync();
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Cliente>(this, "ClienteSelecionado");
        }
    }
}