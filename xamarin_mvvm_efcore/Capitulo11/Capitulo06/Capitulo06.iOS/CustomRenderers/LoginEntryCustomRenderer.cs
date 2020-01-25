using Capitulo06.Controls;
using Capitulo06.iOS.CustomRenderers;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginEntry), typeof(LoginEntryCustomRenderer))]
namespace Capitulo06.iOS.CustomRenderers
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

                e.NewElement.Unfocused += (sender, evt) =>
                {
                    Control.Layer.BorderColor = UIColor.Black.CGColor;
                    Control.Layer.BorderColor = (Element as LoginEntry).BorderColorLostFocus.ToCGColor();
                };
                e.NewElement.Focused += (sender, evt) =>
                {
                    Control.Layer.BorderColor = (Element as LoginEntry).BorderColorOnFocus.ToCGColor();
                    Control.Layer.BorderColor = UIColor.Red.CGColor;
                };

                Control.Layer.CornerRadius = 5;
                //Control.BackgroundColor = UIColor.FromRGB(250, 248, 205);
                Control.Layer.BorderWidth = 1;
            }
        }
    }
}