using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.DataAcess.Interfaces;
using CasaDoCodigo.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo06.ViewModels.Servicos
{
    public class CRUDViewModel : BaseViewModel
    {
        private IDAL<Servico> servicosDAL;
        private Servico Servico { get; set; }
        public ICommand GravarCommand { get; set; }

        public CRUDViewModel(Servico servico)
        {
            servicosDAL = new ServicoDAL(DependencyService.Get<IDBPath>().GetDbPath());
            this.Servico = servico;
            RegistrarCommands();
            this.valor = string.Format("{0:N}", servico.Valor);
        }

        public string Nome
        {
            get { return this.Servico.Nome; }
            set
            {
                this.Servico.Nome = value;
                ((Command)GravarCommand).ChangeCanExecute();
                OnPropertyChanged();
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

        private void RegistrarCommands()
        {
            GravarCommand = new Command(async () =>
            {
                await Gravar();
                MessagingCenter.Send<string>("Atualização realizada com sucesso.", "InformacaoCRUD");
            }, () =>
            {
                return !string.IsNullOrEmpty(this.Servico.Nome) && this.Servico.Valor > 0;
            });
        }

        private async Task Gravar()
        {
            var ehNovoServico = (this.Servico.ServicoID == null ? true : false);
            Servico = await servicosDAL.UpdateAsync(Servico, Servico.ServicoID);
            AtualizarPropriedadesParaVisao(ehNovoServico);
        }

        private void AtualizarPropriedadesParaVisao(bool ehNovoObjeto)
        {
            if (ehNovoObjeto)
            {
                this.Servico = new Servico();
                this.Nome = string.Empty;
                this.Valor = string.Empty;
            }
            else
            {
                this.Servico.NotificarListView = true;
            }
        }
    }
}
