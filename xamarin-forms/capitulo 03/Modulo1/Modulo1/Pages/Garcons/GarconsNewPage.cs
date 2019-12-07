using System;

using Xamarin.Forms;

namespace Modulo1
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