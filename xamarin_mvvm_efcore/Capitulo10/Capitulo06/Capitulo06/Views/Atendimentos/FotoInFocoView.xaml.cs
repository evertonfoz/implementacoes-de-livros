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
            //stackFoto.Children.Add(image);
            RegistrarTapGestureRecognizer();
            RegistrarPintchGestureRecognizer();

            //var panGesture = new PanGestureRecognizer();
            //panGesture.PanUpdated += (s, e) =>
            //{
            //    switch (e.StatusType)
            //    {
            //        case GestureStatus.Running:
            //            double xTrans = xOffset + e.TotalX, yTrans = yOffset + e.TotalY;
            //            //Content.TranslationX = xOffset +  e.TotalX;
            //            //Content.TranslationY = yOffset + e.TotalY;
            //            Content.TranslateTo(xTrans, yTrans, 0, Easing.Linear);
            //            //Content.TranslationX = e.TotalX;
            //            //Content.TranslationY = e.TotalY;
            //            break;

            //        case GestureStatus.Completed:
            //            // center the image if the width of the image is smaller than the screen width
            //            Debug.WriteLine(image.Width + ", " + width + ", " + image.Height + ", " + height);
            //            if (image.Width * currentScale < width && width > height)
            //                xOffset = (width - image.Width * currentScale) / 2 - Content.X;
            //            else
            //                xOffset = System.Math.Max(System.Math.Min(0, xOffset), -System.Math.Abs(image.Width * currentScale - width));

            //            // center the image if the height of the image is smaller than the screen height
            //            if (image.Height * currentScale < height && image.Height > width)
            //                yOffset = (height - image.Height * currentScale) / 2 - Content.Y;
            //            else
            //                yOffset = System.Math.Max(System.Math.Min((image.Height - (height)) / 2, yOffset), -System.Math.Abs((image.Height * currentScale - height - (image.Height - height) / 2)));
            //            //xOffset =  Content.TranslationX;
            //            //yOffset =  Content.TranslationY;
            //            //Content.TranslationX = 0;
            //            //Content.TranslationY = 0;
            //            // bounce the image back to inside the bounds
            //            Content.TranslateTo(xOffset, yOffset, 500, Easing.BounceOut);
            //            break;
            //    }
            //};

            //this.image.GestureRecognizers.Add(panGesture);
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
                // Apply translation based on the change in origin.
                //Content.TranslationX = targetX.Clamp(-Content.Width * (currentScale - 1), 0);
                //Content.TranslationY = targetY.Clamp(-Content.Height * (currentScale - 1), 0);

                // Apply scale factor.
                Content.Scale = currentScale;
            }
            else if (e.Status == GestureStatus.Completed)
            {
                xOffset = Content.TranslationX;
                yOffset = Content.TranslationY;

                // center the image if the width of the image is smaller than the screen width
                if (image.Width * currentScale < width && width> height)
                    xOffset = (width - image.Width * currentScale) / 2 - Content.X;
                else
                    xOffset = System.Math.Max(System.Math.Min(0, xOffset), -System.Math.Abs(image.Width * currentScale - width));
                //if (imagemSelecionada.Width * currentScale < width && width > height)
                //    xOffset = (width - imagemSelecionada.Width * currentScale) / 2 - Content.X;
                //else
                //    xOffset = System.Math.Max(System.Math.Min(0, xOffset), -System.Math.Abs(imagemSelecionada.Width * currentScale - width));

                // center the image if the height of the image is smaller than the screen height
                if (image.Height * currentScale < height && height > width)
                    yOffset = (height - image.Height * currentScale) / 2 - Content.Y;
                else
                    yOffset = System.Math.Max(System.Math.Min((image.Height - height) / 2, yOffset), -System.Math.Abs(image.Height * currentScale - height- (image.Height- height) / 2));

                // bounce the image back to inside the bounds
                Content.TranslateTo(xOffset, yOffset, 500, Easing.BounceOut);

                // Store the translation delta's of the wrapped user interface element.
                //xOffset = Content.TranslationX;
                //yOffset = Content.TranslationY;
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

        private double width;
        private double height;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            //if (width != this.width || height != this.height)
            //{
            //    this.width = width;
            //    this.height = height;

            //    if (image.Width > 0 && imagemSelecionada.Width < imagemSelecionada.Height)
            //        image.HeightRequest = height;
            //}
        }

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