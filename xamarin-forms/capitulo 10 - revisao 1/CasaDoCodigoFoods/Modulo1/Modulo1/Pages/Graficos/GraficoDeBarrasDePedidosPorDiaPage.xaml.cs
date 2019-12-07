using Modulo1.Dal;
using Syncfusion.SfChart.XForms;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Pages.Graficos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraficoDeBarrasDePedidosPorDiaPage : ContentPage
    {
        public PedidoDAL pedidoDAL = new PedidoDAL();
        public ObservableCollection<ChartDataPoint> Dados = new ObservableCollection<ChartDataPoint>();

        public GraficoDeBarrasDePedidosPorDiaPage()
        {
            InitializeComponent();
            foreach (var dado in pedidoDAL.GetFechadosGroupedByDayWithChildren())
            {
                Dados.Add(new ChartDataPoint(dado.DiaDoMes.ToString(), dado.Total));
            }
            Dados.Add(new ChartDataPoint("3", 90));
            Dados.Add(new ChartDataPoint("2", 100));

            grafico.Series.Add(new ColumnSeries()
            {
                ItemsSource = Dados,
                Label = "Vendas",
                YAxis = new NumericalAxis()
                {
                    OpposedPosition = false,
                    ShowMajorGridLines = false
                }
            });
        }
    }
}