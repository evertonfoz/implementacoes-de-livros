using CasaDoCodigo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo05.Views.Atendimentos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FotosListagemView : ContentPage
    {
        public FotosListagemView(Atendimento atendimento)
        {
            InitializeComponent();
        }
    }
}