
using Xamarin.Forms;

namespace Modulo1.Pages.Garcons
{
    public class GarconsNewPage : ContentPage
    {
        public GarconsNewPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

