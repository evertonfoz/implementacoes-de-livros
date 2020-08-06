using Android.Content;
using Android.Graphics.Drawables;
using Capitulo05.Controls;
using Capitulo05.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginEntry), typeof(LoginEntryCustomRenderer))]
namespace Capitulo05.Droid.CustomRenderers
{
    public class LoginEntryCustomRenderer : EntryRenderer
    {
        public LoginEntryCustomRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null && e.NewElement != null)
            {
                Control.Background = Context.GetDrawable(Resource.Drawable.loginentrycustomrenderer);
            }
        }
    }
}