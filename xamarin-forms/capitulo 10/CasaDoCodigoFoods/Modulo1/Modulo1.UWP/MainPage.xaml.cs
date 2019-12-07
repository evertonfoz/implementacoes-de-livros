using Syncfusion.SfChart.XForms.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Modulo1.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            Xamarin.FormsMaps.Init("jjJhG6qA91yyXviczVsB~Xv5J-AKvo9UmBcs8ee0P9w~ArelipOg7W-421ZKH454bZYrZbc2oSlcdJkZHzyIyG8WwdxRzs8o2bVsQvwQQwAh");
            // Xamarin.FormsMaps.Init("INSERT_MAP_KEY_HERE");

            new SfChartRenderer();

            LoadApplication(new Modulo1.App());
        }
    }
}
