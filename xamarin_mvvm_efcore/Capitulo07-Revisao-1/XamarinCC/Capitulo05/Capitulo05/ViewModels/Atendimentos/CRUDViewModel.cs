using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using SQLiteEF.DAL;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo05.ViewModels.Atendimentos
{
    public class CRUDViewModel : BaseViewModel
    {
        private IDAL<Atendimento> atendimentoDAL;
        private Atendimento Atendimento { get; set; }
        public ICommand PesquisarCommand { get; set; }
        public ICommand GravarCommand { get; set; }
        public ICommand ServicosCommand { get; set; }
        public ICommand FotosCommand { get; set; }

        public CRUDViewModel(Atendimento atendimento)
        {
            atendimentoDAL = new AtendimentoDAL(DependencyService.Get<IDBPath>().GetDbPath());
            this.Atendimento = atendimento;
            RegistrarCommands();
        }
        public string ClienteNome
        {
            get { return this.Atendimento.Cliente == null ? "Localize o cliente" : this.Atendimento.Cliente.Nome; }
        }
        private void RegistrarCommands()
        {
            PesquisarCommand = new Command(() =>
            {
                MessagingCenter.Send<Atendimento>(Atendimento, "MostrarPesquisarCliente");
            });
            GravarCommand = new Command(async () =>
            {
                if (Atendimento.AtendimentoID != null)
                    Atendimento.NotificarListView = true;
                Atendimento = await atendimentoDAL.UpdateAsync(Atendimento, Atendimento.AtendimentoID, Atendimento.Cliente);
                MessagingCenter.Send<string>("Atualização realizada com sucesso.", "InformacaoCRUD");
                OnPropertyChanged("HabilitarBotoes");
            }, () =>
            {
                return ((this.Atendimento.Cliente != null) && !string.IsNullOrEmpty(this.Atendimento.Cliente.Nome) && !string.IsNullOrEmpty(this.Atendimento.Veiculo) && (this.Atendimento.DataHoraPrometida > this.Atendimento.DataHoraChegada));
            });
            ServicosCommand = new Command(() =>
            {
                MessagingCenter.Send<Atendimento>(Atendimento, "MostrarServicos");
            });

            FotosCommand = new Command(() =>
            {
                MessagingCenter.Send<Atendimento>(Atendimento, "MostrarFotos");
            });
        }
        public Cliente Cliente
        {
            get { return this.Atendimento.Cliente; }
            set
            {
                this.Atendimento.Cliente = value;
                OnPropertyChanged(nameof(ClienteNome));
                ((Command)GravarCommand).ChangeCanExecute();
            }
        }
        public string Veiculo
        {
            get { return this.Atendimento.Veiculo; }
            set
            {
                this.Atendimento.Veiculo = value;
                OnPropertyChanged();
                ((Command)GravarCommand).ChangeCanExecute();
            }
        }
        public DateTime DataChegada
        {
            get { return this.Atendimento.DataHoraChegada; }
            set
            {
                this.Atendimento.DataHoraChegada = new DateTime(value.Year, value.Month, value.Day, HoraChegada.Hours, HoraChegada.Minutes, 0);
                OnPropertyChanged();
                ((Command)GravarCommand).ChangeCanExecute();
            }
        }
        public TimeSpan HoraChegada
        {
            get { return new TimeSpan(this.Atendimento.DataHoraChegada.Hour, this.Atendimento.DataHoraChegada.Minute, 0); }
            set
            {
                this.Atendimento.DataHoraChegada = new DateTime(DataChegada.Year, DataChegada.Month, DataChegada.Day, value.Hours, value.Minutes, 0);
                OnPropertyChanged();
                ((Command)GravarCommand).ChangeCanExecute();
            }
        }
        public DateTime DataPrometida
        {
            get { return this.Atendimento.DataHoraPrometida; }
            set
            {
                this.Atendimento.DataHoraPrometida = new DateTime(value.Year, value.Month, value.Day, HoraPrometida.Hours, HoraPrometida.Minutes, 0);
                OnPropertyChanged();
                ((Command)GravarCommand).ChangeCanExecute();
            }
        }

        public TimeSpan HoraPrometida
        {
            get { return new TimeSpan(this.Atendimento.DataHoraPrometida.Hour, this.Atendimento.DataHoraPrometida.Minute, 0); }
            set
            {
                this.Atendimento.DataHoraPrometida = new DateTime(DataPrometida.Year, DataPrometida.Month, DataPrometida.Day, value.Hours, value.Minutes, 0);
                OnPropertyChanged();
                ((Command)GravarCommand).ChangeCanExecute();
            }
        }

        public bool HabilitaAlteracao
        {
            get { return !Atendimento.EstaFinalizado; }
        }
        public string EntregaVeiculo
        {
            get
            {
                return (HabilitaAlteracao)
                    ? "" : "Entregue em " + ((DateTime)this.Atendimento.DataHoraEntrega).ToString("dd/MM/yyyy HH:mm:ss");
            }
        }
        public bool HabilitarBotoes
        {
            get { return this.Atendimento.AtendimentoID != null; }
        }
    }
}
