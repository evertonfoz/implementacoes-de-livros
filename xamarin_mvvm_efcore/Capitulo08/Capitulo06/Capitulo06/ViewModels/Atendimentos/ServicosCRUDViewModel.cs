using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.DataAcess.Interfaces;
using CasaDoCodigo.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo06.ViewModels.Atendimentos
{
    public class ServicosCRUDViewModel : BaseViewModel
    {
        private IDAL<AtendimentoItem> itemDAL;
        private Atendimento Atendimento { get; set; }
        private AtendimentoItem AtendimentoItem { get; set; }
        public ICommand PesquisarCommand { get; set; }

        public ServicosCRUDViewModel(AtendimentoItem atendimentoItem)
        {
            itemDAL = new AtendimentoItemDAL(atendimentoItem.Atendimento, DependencyService.Get<IDBPath>().GetDbPath());
            this.Atendimento = atendimentoItem.Atendimento;
            this.AtendimentoItem = atendimentoItem;
            this.valor = string.Format("{0:N}", atendimentoItem.Valor);
            this.quantidade = string.Format("{0}", atendimentoItem.Quantidade);
            RegistrarCommands();
        }

        public string ServicoNome
        {
            get { return this.AtendimentoItem.Servico == null ? "Localize o serviço" : this.AtendimentoItem.Servico.Nome; }
            set
            {
                OnPropertyChanged();
            }
        }

        public bool HabilitaAlteracao
        {
            get { return Atendimento == null || !Atendimento.EstaFinalizado; }
        }

        public Servico Servico
        {
            get { return this.AtendimentoItem.Servico; }
            set
            {
                this.AtendimentoItem.Servico = value;
                this.AtendimentoItem.ServicoID = (value != null) ? value.ServicoID : null; // EF não precisa
                Quantidade = (value != null) ? "1" : "0";
                Valor = (value != null) ? Convert.ToString(value.Valor) : "0";
                OnPropertyChanged(nameof(ServicoNome));
            }
        }

        private string quantidade;
        public string Quantidade
        {
            get { return quantidade; }
            set
            {
                this.quantidade = value;
                this.AtendimentoItem.Quantidade = string.IsNullOrEmpty(value) ? 0 : Convert.ToInt16(value); ;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SubTotal));
            }
        }

        private string valor;
        public string Valor
        {
            get { return valor; }
            set
            {
                this.valor = value;
                this.AtendimentoItem.Valor = string.IsNullOrEmpty(value) ? 0 : Convert.ToDouble(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(SubTotal));
            }
        }

        public double SubTotal
        {
            get { return AtendimentoItem.Valor * AtendimentoItem.Quantidade; }
            set
            {
                OnPropertyChanged();
                ((Command)GravarItemCommand).ChangeCanExecute();
            }
        }

        private void RegistrarCommands()
        {
            PesquisarCommand = new Command(() =>
            {
                MessagingCenter.Send<AtendimentoItem>(AtendimentoItem, "MostrarPesquisarServico");
            });

            GravarItemCommand = new Command(async () =>
            {
                AtendimentoItem.Atendimento = this.Atendimento;
                AtendimentoItem.AtendimentoID = Atendimento.AtendimentoID;

                if (AtendimentoItem.AtendimentoItemID != null)
                    AtendimentoItem.NotificarListView = true;

                var countServicosItem = this.Atendimento.Servicos.Where(s => s.ServicoID == AtendimentoItem.ServicoID).Count();

                if (countServicosItem > 1)
                {
                    MessagingCenter.Send<string>("Serviço já existe no atendimento.", "InformacaoCRUD");
                    return;
                }

                await itemDAL.UpdateAsync(AtendimentoItem, AtendimentoItem.AtendimentoItemID);
                MessagingCenter.Send<string>("Atualização realizada com sucesso.", "InformacaoCRUD");
                this.AtendimentoItem = new AtendimentoItem();
                this.Servico = null;
            }, () =>
            {
                return (this.AtendimentoItem.Servico != null && this.AtendimentoItem.Quantidade > 0 && this.AtendimentoItem.Valor > 0);
            });

        }

        public ICommand GravarItemCommand { get; set; }
    }
}
