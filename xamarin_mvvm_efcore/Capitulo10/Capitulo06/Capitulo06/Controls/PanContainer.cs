using System.Diagnostics;
using Xamarin.Forms;

public class PanContainer : ContentView
{
    double x, y;

    public PanContainer()
    {
        Debug.WriteLine("OK");
        // Set PanGestureRecognizer.TouchPoints to control the
        // number of touch points needed to pan
        var panGesture = new PanGestureRecognizer();
        //panGesture.TouchPoints = 2;
        panGesture.PanUpdated += OnPanUpdated;
        GestureRecognizers.Add(panGesture);
    }

    void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        Debug.WriteLine("Dragged");
        switch (e.StatusType)
        {
            case GestureStatus.Running:
                Content.TranslationX = e.TotalX;
                Content.TranslationY = e.TotalY;
                x = e.TotalX;
                y = e.TotalY;
                // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                //Content.TranslationX =
                //  Math.Max(Math.Min(0, x + e.TotalX), -Math.Abs(Content.Width - width));
                //Content.TranslationY =
                //  Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(Content.Height - height));
                Debug.WriteLine("Running " + e.TotalX + ", " + e.TotalY);
                break;

            case GestureStatus.Completed:
                // Store the translation applied during the pan
                Content.TranslationX = x;
                Content.TranslationY = y;
                Debug.WriteLine("Completed");
                Debug.WriteLine(Parent);
                var p = Parent;
                Debug.WriteLine(p.Parent);
                var v = p.Parent;
                Debug.WriteLine(v.Parent);
                FlexLayout flexLayout = (FlexLayout) v.Parent;
                //MessagingCenter.Send<Frame>(v as Frame, "Remover");
                ((Frame)v).IsVisible = false;
//                flexLayout.Children.Remove((Frame) v);
                break;
        }
    }
}
