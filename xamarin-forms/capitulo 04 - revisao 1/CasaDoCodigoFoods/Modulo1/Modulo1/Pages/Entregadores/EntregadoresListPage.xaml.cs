using Modulo1.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Pages.Entregadores
{
	[XamlCompilation(
        XamlCompilationOptions.Compile)]
	public partial class EntregadoresListPage : 
        ContentPage
    {
        private EntregadorDAL dalEntregador = 
            EntregadorDAL.GetInstance();

        public EntregadoresListPage()
        {
            InitializeComponent();
            lvEntregadores.ItemsSource = 
                dalEntregador.GetAll();
        }
    }
}