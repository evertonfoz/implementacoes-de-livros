using System;
using Modulo1.Pages.Garcons;
using Xamarin.Forms;

namespace Modulo1.Pages
{
	public class MenuPage : ContentPage
	{
		public MenuPage()
		{
			Title = "Menu de opções";
			Content = new StackLayout
			{
				//Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new Button() {
						Text = "Garçons",
						Image = "icone_garcons.png",
						Command = new Command(() => Navigation.PushAsync(new GarconsPage()))
					}
				}
			};
		}
	}
}


