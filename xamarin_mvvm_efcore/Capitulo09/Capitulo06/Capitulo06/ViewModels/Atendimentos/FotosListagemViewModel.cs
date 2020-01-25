using Capitulo06.ExtensionMethods;
using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using Interfaces.Fotos;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo06.ViewModels.Atendimentos
{
    public class FotosListagemViewModel
    {
        private Atendimento Atendimento { get; set; }
        private AtendimentoFoto AtendimentoFoto { get; set; }
        public ICommand NovoCommand { get; set; }
        private IDAL<AtendimentoFoto> atendimentoFotoDAL;

        public FotosListagemViewModel(Atendimento atendimento)
        {
            this.Atendimento = atendimento;
            atendimentoFotoDAL = new AtendimentoFotoDAL(atendimento, DependencyService.Get<IDBPath>().GetDbPath());
            RegistrarCommands();
        }

        private void RegistrarCommands()
        {
            NovoCommand = new Command(() =>
            {
                var atendimentoFoto = new AtendimentoFoto() { Atendimento = this.Atendimento, AtendimentoID = this.Atendimento.AtendimentoID };
                MessagingCenter.Send<AtendimentoFoto>(atendimentoFoto, "Mostrar");
            }, () =>
            {
                return !this.Atendimento.EstaFinalizado;
            });
        }

        public List<AtendimentoFoto> FotosAtendimento
        {
            get { return Atendimento.Fotos; }
        }

        private bool atualizarDados = true;

        public async Task AtualizarFotosAsync()
        {
            if (!atualizarDados)
                return;
            Atendimento.Fotos = await atendimentoFotoDAL.GetAllAsync();
            foreach (var foto in Atendimento.Fotos)
            {
                foto.JaExibidaNaListagem = false;
            }
            atualizarDados = false;
        }

        public async Task EliminarFotoAsync(AtendimentoFoto atendimentoFoto)
        {
            await atendimentoFotoDAL.DeleteAsync(atendimentoFoto);
            File.Delete(DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(atendimentoFoto.CaminhoFoto));
        }
    }
}
