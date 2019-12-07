using System;

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
                Icon = "icone_list.png"
            });
            Children.Add(new GarconsNewPage()
            {
                Title = "Inserir Novo",
                Icon = "icone_new.png"
            });
        }
    }
}

