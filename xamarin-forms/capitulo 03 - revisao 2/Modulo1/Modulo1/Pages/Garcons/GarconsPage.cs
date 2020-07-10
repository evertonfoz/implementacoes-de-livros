using Xamarin.Forms;

namespace Modulo1.Pages.Garcons
{
    public class GarconsPage : TabbedPage
    {
        public GarconsPage()
        {
            Children.Add(new GarconsListPage()
            {
                Title = "Listagem",
                IconImageSource = "icone_list.png"
            });
            Children.Add(new GarconsNewPage()
            {
                Title = "Inserir Novo",
                IconImageSource = "icone_new.png"
            });
        }
    }
}
