using CasaDoCodigo.Devices.Interfaces;
using Interfaces.Devices;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Capitulo06.Views.Atendimentos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FotoInFocoView : ContentPage
	{
        private Image imagemSelecionada;
        private Image image;

		public FotoInFocoView (Image imagemSelecionada)
        {
            InitializeComponent();
            Image image = new Image() { Source = imagemSelecionada.Source };
            this.image = image;
            this.imagemSelecionada = imagemSelecionada;
            image.Aspect = Aspect.AspectFit;
            containerFoto.Content = image;
            RegistrarTapGestureRecognizer();
            RegistrarPintchGestureRecognizer();
        }

        private void RegistrarPintchGestureRecognizer()
        {
            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += OnPinchUpdated;
            this.image.GestureRecognizers.Add(pinchGesture);
        }

        private double currentScale = 1;
        private double startScale = 1;
        private double xOffset = 0;
        private double yOffset = 0;

        void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Status == GestureStatus.Started)
            {
                // Store the current scale factor applied to the wrapped user interface element,
                // and zero the components for the center point of the translate transform.
                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }
            else if (e.Status == GestureStatus.Running)
            {
                // Calculate the scale factor to be applied.
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the X pixel coordinate.
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the Y pixel coordinate.
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                // Calculate the transformed element pixel coordinates.
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);

                var transX = targetX.Clamp(-Content.Width * (currentScale - 1), 0);
                var transY = targetY.Clamp(-Content.Height * (currentScale - 1), 0);

                Content.TranslateTo(transX, transY, 0, Easing.Linear);
                Content.Scale = currentScale;
            }
            else if (e.Status == GestureStatus.Completed)
            {
                xOffset = Content.TranslationX;
                yOffset = Content.TranslationY;

                //// center the image if the width of the image is smaller than the screen width
                //if (image.Width * currentScale < Width && Width> Height)
                //    xOffset = (Width - image.Width * currentScale) / 2 - Content.X;
                //else
                //    xOffset = System.Math.Max(System.Math.Min(0, xOffset), -System.Math.Abs(image.Width * currentScale - Width));

                //// center the image if the height of the image is smaller than the screen height
                //Debug.WriteLine("===> " + Height + ", " + Width);
                //if (image.Height * currentScale < Height && Height > Width) 
                //    yOffset = (Height - image.Height * currentScale) / 2 - Content.Y;
                //else
                //    yOffset = System.Math.Max(System.Math.Min((image.Height - Height) / 2, yOffset), -System.Math.Abs(image.Height * currentScale - Height- (image.Height- Height) / 2));

                // bounce the image back to inside the bounds
                Content.TranslateTo(xOffset, yOffset, 500, Easing.BounceOut);

            }
        }

        private void RegistrarTapGestureRecognizer()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.NumberOfTapsRequired = 2;
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Navigation.PopAsync(); ;
            };
            this.image.GestureRecognizers.Add(tapGestureRecognizer);
        }

        //private double width;
        //private double height;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IStatusBar>().Ocultar();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DependencyService.Get<IStatusBar>().Exibir();
        }
    }
}