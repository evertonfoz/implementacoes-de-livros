using Capitulo05.Views.Atendimentos;
using CasaDoCodigo.Devices.Interfaces;
using CasaDoCodigo.Models;
using Interfaces.Fotos;
using Xamarin.Forms;

namespace Capitulo05.Controls
{
    public class FotoListContainerControl : ContentView
    {
        public AtendimentoFoto Foto { get; set; }
        private double newXPosition, newYPosition;

        public FotoListContainerControl(AtendimentoFoto foto)
        {
            Content = new Image() { Source = DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(foto.CaminhoFoto) };
            this.Foto = foto;
            RegistrarTapGestureRecognizer();
            RegistrarPanGestureRecognizer();
        }
        private void RegistrarTapGestureRecognizer()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.NumberOfTapsRequired = 2;
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                DependencyService.Get<IOrientation>().Portrait();
                Navigation.PushAsync(new FotoInFocoView(Content as Image));
            };
            GestureRecognizers.Add(tapGestureRecognizer);
        }
        private void RegistrarPanGestureRecognizer()
        {
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
        }
        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    newXPosition = Content.TranslationX = e.TotalX;
                    newYPosition = Content.TranslationY = e.TotalY;
                    break;

                case GestureStatus.Completed:
                    Content.TranslationX = newXPosition;
                    Content.TranslationY = newYPosition;
                    MessagingCenter.Send<FotoListContainerControl>(this, "Remover");
                    break;
            }
        }
    }
}
