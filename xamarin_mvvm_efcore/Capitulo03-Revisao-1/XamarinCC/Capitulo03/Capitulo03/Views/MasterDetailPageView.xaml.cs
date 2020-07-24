using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo03.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageView : MasterDetailPage
    {
        public MasterDetailPageView()
        {
            InitializeComponent();
            masterPage.ListView.ItemSelected += ListView_ItemSelected;
            IsPresented = true;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPageViewMasterMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            masterPage.ListView.SelectedItem = null;
        }
    }
}