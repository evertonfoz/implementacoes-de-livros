using Capitulo05.Controls;
using Capitulo05.iOS.CustomRenderers;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginEntry), typeof(LoginEntryCustomRenderer))]
namespace Capitulo05.iOS.CustomRenderers
{
    public class LoginEntryCustomRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null && e.NewElement != null)
            {
                Control.LeftView = new UIView(new CGRect(0, 0, 15, 0));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIView(new CGRect(0, 0, 15, 0));
                Control.RightViewMode = UITextFieldViewMode.Always;
                Control.Layer.BorderColor = (Element as LoginEntry).BorderColorLostFocus.ToCGColor();

                e.NewElement.Unfocused += (sender, evt) =>
                {
                    Control.Layer.BorderColor = (Element as LoginEntry).BorderColorLostFocus.ToCGColor();
                };
                e.NewElement.Focused += (sender, evt) =>
                {
                    Control.Layer.BorderColor = (Element as LoginEntry).BorderColorOnFocus.ToCGColor();
                };

                Control.Layer.CornerRadius = 5;
                Control.Layer.BorderWidth = 1;
            }
        }
    }
}