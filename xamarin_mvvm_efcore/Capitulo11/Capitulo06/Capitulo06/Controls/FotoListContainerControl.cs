using Capitulo06.Views.Atendimentos;
using CasaDoCodigo.Devices.Interfaces;
using CasaDoCodigo.Models;
using Interfaces.Fotos;
using System.Diagnostics;
using Xamarin.Forms;

namespace Capitulo06.Controls
{
    public class FotoListContainerControl : ContentView
    {
        public AtendimentoFoto Foto { get; set; }
        public long FotoID { get; set; }

        public FotoListContainerControl(AtendimentoFoto foto)
        {
            Content = new Image() { Source = DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(foto.CaminhoFoto) };
            this.Foto = foto;

            RegistrarPanGestureRecognizer();
            RegistrarTapGestureRecognizer();
        }

        private void RegistrarPanGestureRecognizer()
        {
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
        }

        private double newXPosition, newYPosition;

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
    }
}