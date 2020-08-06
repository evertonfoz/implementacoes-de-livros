using Xamarin.Forms;

namespace Capitulo05.Controls
{
    public class LoginEntry : Entry
    {
        public static readonly BindableProperty BorderColorOnFocusProperty = BindableProperty.Create(nameof(BorderColorOnFocus), typeof(Color), typeof(LoginEntry), Color.Red);

        public static readonly BindableProperty BorderColorLostFocusProperty = BindableProperty.Create(nameof(BorderColorLostFocus), typeof(Color), typeof(LoginEntry), Color.Black);
        public Color BorderColorOnFocus
        {
            get { return (Color)GetValue(BorderColorOnFocusProperty); }
            set { SetValue(BorderColorOnFocusProperty, value); }
        }

        public Color BorderColorLostFocus
        {
            get { return (Color)GetValue(BorderColorLostFocusProperty); }
            set { SetValue(BorderColorLostFocusProperty, value); }
        }
    }
}
