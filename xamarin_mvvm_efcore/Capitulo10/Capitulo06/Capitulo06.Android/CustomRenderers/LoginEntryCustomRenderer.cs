using Android.Content;
//using Android.Graphics.Drawables;
using Capitulo06.Controls;
using Capitulo06.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginEntry), typeof(LoginEntryCustomRenderer))]
namespace Capitulo06.Droid.CustomRenderers
{
    public class LoginEntryCustomRenderer: EntryRenderer
    {
        public LoginEntryCustomRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null && e.NewElement != null)
            {
                //GradientDrawable gd = new GradientDrawable();
                //gd.SetCornerRadius(10);
                //gd.SetStroke(2, (Element as LoginEntry).BorderColorLostFocus.ToAndroid());
                Control.Background = Context.GetDrawable(Resource.Drawable.loginentrycustomrenderer);
                //Control.SetPadding(10, 5, 10, 5);

                //e.NewElement.Unfocused += (sender, evt) =>
                //{
                //    gd.SetStroke(2, (Element as LoginEntry).BorderColorLostFocus.ToAndroid());
                //};
                //e.NewElement.Focused += (sender, evt) =>
                //{
                //    gd.SetStroke(2, (Element as LoginEntry).BorderColorOnFocus.ToAndroid());
                //};

                //Control.SetBackground(gd);
            }
        }
    }
}