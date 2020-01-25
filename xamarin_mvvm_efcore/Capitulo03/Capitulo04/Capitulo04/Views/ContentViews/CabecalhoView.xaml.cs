using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Capitulo04.Views.ContentViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CabecalhoView : ContentView
	{
		public CabecalhoView ()
		{
			InitializeComponent ();
		}
	}
}