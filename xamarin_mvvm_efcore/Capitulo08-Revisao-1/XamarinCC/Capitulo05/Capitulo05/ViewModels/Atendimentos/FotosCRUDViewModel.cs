using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo05.ViewModels.Atendimentos
{
    public class FotosCRUDViewModel: BaseViewModel
    {
        public ICommand CameraCommand { get; set; }
        public AtendimentoFoto AtendimentoFoto { get; set; }
        public ICommand AlbumCommand { get; set; }
        public ICommand GravarFotoCommand { get; set; }
        public FotosCRUDViewModel(AtendimentoFoto atendimentoFoto)
        {
            this.AtendimentoFoto = atendimentoFoto;
            RegistrarCommands();
        }

        private void RegistrarCommands()
        {
            CameraCommand = new Command(() =>
            {
                MessagingCenter.Send<AtendimentoFoto>(this.AtendimentoFoto, "Camera");
            });
            AlbumCommand = new Command(() =>
            {
                MessagingCenter.Send<AtendimentoFoto>(this.AtendimentoFoto, "Album");
            });
            GravarFotoCommand = new Command(async () =>
            {
                AtendimentoFoto.Atendimento = AtendimentoFoto.Atendimento;
                AtendimentoFoto.AtendimentoID = AtendimentoFoto.Atendimento.AtendimentoID;

                var dal = new AtendimentoFotoDAL(AtendimentoFoto.Atendimento, DependencyService.Get<IDBPath>().GetDbPath());
                await dal.UpdateAsync(AtendimentoFoto, AtendimentoFoto.AtendimentoFotoID);
                MessagingCenter.Send<string>("Atualização realizada com sucesso.", "InformacaoCRUD");
                MessagingCenter.Send<string>("consultar.png", "AtualizarFoto");
                AtendimentoFoto = new AtendimentoFoto();
                OnPropertyChanged(nameof(Observacoes));
            }, () =>
            {
                return (!string.IsNullOrEmpty(Observacoes) && !string.IsNullOrEmpty(CaminhoFoto));
            });
        }
    
        public string CaminhoFoto
        {
            get { return this.AtendimentoFoto.CaminhoFoto; }
            set
            {
                this.AtendimentoFoto.CaminhoFoto = value;
                OnPropertyChanged();
                ((Command)GravarFotoCommand).ChangeCanExecute();
            }
        }
        public string Observacoes
        {
            get { return this.AtendimentoFoto.Observacoes; }
            set
            {
                this.AtendimentoFoto.Observacoes = value;
                OnPropertyChanged();
                ((Command)GravarFotoCommand).ChangeCanExecute();
            }
        }
    }
}
