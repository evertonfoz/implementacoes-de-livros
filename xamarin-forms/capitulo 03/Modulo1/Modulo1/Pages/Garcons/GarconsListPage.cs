using System;
using System.Collections;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Modulo1
{
	public class GarconsListPage : ContentPage
	{
		public GarconsListPage()
		{
			Content = GetGarcons();
		}

		private ListView GetGarcons()
		{
			var garcons = new ListView() ;
			garcons.ItemsSource = new string[] {
				"Brauzio", "Asdrugio", "Entencius", "Gesfredio", "Cartucious",
				"Gesfrundio", "Adoliterio", "Kentencio", "Castrogildo", "Gesifrelio"
			};
			return garcons;
		}
	}
}