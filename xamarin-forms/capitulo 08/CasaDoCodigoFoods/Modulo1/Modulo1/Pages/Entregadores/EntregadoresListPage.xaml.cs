using Modulo1.Dal;
using Xamarin.Forms;

namespace Modulo1.Pages.Entregadores
{
    public partial class EntregadoresListPage : ContentPage
    {
        private EntregadorDAL dalEntregador = EntregadorDAL.GetInstance();

        public EntregadoresListPage()
        {
            InitializeComponent();
            lvEntregadores.ItemsSource = dalEntregador.GetAll();
        }
    }
}
