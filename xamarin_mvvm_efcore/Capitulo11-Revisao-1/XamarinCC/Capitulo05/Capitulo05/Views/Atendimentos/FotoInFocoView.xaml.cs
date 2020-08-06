using Interfaces.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Capitulo05.Views.Atendimentos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FotoInFocoView : ContentPage
    {
        private Image imagemSelecionada;
        private Image image;
        private double currentScale = 1;
        private double startScale = 1;
        private double xOffset = 0;
        private double yOffset = 0;
        public FotoInFocoView(Image imagemSelecionada)
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
        private void RegistrarPintchGestureRecognizer()
        {
            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += OnPinchUpdated;
            this.image.GestureRecognizers.Add(pinchGesture);
        }
        void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Status == GestureStatus.Started)
            {
                // Armazena o fator de escala atual aplicado à imagem e zera o ponto central da transformação de conversão.
                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }
            else if (e.Status == GestureStatus.Running)
            {
                // Calcula o fator de escala a ser aplicado
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);

                // O ScaleOrigin é uma coordenada relativa à imagem para obter o pixel X da coordenada
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                // O ScaleOrigin é uma coordenada relativa à imagem para obter o pixel Y da coordenada
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                // Calcular as coordenadas de pixel do elemento transformado
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);

                var transX = targetX.Clamp(-Content.Width * (currentScale - 1), 0);
                var transY = targetY.Clamp(-Content.Height * (currentScale - 1), 0);

                // Aplica a conversão com base na mudança da origem
                Content.TranslateTo(transX, transY, 0, Easing.Linear);

                // Aplica o fator na imagem
                Content.Scale = currentScale;
            }
            else if (e.Status == GestureStatus.Completed)
            {
                xOffset = Content.TranslationX;
                yOffset = Content.TranslationY;

                // Coloca a imagem de novo, dentro dos limites
                Content.TranslateTo(xOffset, yOffset, 500, Easing.BounceOut);
            }
        }
    }
}