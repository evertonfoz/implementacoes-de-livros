using Capitulo04.Models;
using Capitulo04.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo04.ViewModels.Servicos
{
    public class CRUDViewModel : BaseViewModel
    {
        private IDataStore<Servico> DataStore = new ServicoDataStore();
        private Servico Servico { get; set; }
        public ICommand GravarCommand { get; set; }
        private ObservableCollection<Servico> Servicos;

        public CRUDViewModel(Servico servico, ObservableCollection<Servico> servicos)
        {
            this.Servico = servico;
            RegistrarCommands();
            this.valor = string.Format("{0:N}", servico.Valor);
            this.Servicos = servicos;
        }

        private void RegistrarCommands()
        {
            GravarCommand = new Command(() =>
            {
                Gravar();
                MessagingCenter.Send<string>("Atualização realizada com sucesso.", "InformacaoCRUD");
            }, () =>
            {
                return !string.IsNullOrEmpty(this.Servico.Nome) && this.Servico.Valor > 0;
            });
        }

        private void Gravar()
        {
            var ehNovoServico = (this.Servico.ServicoID == null ? true : false);
            DataStore.Update(this.Servico);
            AtualizarPropriedadesParaVisao(ehNovoServico);
        }
        private void AtualizarPropriedadesParaVisao(bool ehNovoServico)
        {
            if (ehNovoServico)
            {
                this.Servicos.Add(Servico);
                this.Servico = new Servico();
                this.Nome = string.Empty;
                this.Valor = string.Empty;
            }
            else
            {
                var servico = this.Servicos.FirstOrDefault(s => s.ServicoID == Servico.ServicoID);
                int indexOfServico = this.Servicos.IndexOf(servico);
                this.Servicos[indexOfServico] = servico;
            }
        }

        public string Nome
        {
            get { return this.Servico.Nome; }
            set
            {
                this.Servico.Nome = value;
                OnPropertyChanged();
                ((Command)GravarCommand).ChangeCanExecute();
            }
        }

        private string valor;
        public string Valor
        {
            get { return valor; }
            set
            {
                this.valor = value;
                this.Servico.Valor = string.IsNullOrEmpty(value) ? 0 : Convert.ToDouble(valor);
                OnPropertyChanged();
                ((Command)GravarCommand).ChangeCanExecute();
            }
        }
    }
}
