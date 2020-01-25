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

        //public ObservableCollection<AtendimentoFoto> FotosAtendimento { get; set; }

        public FotosListagemViewModel(Atendimento atendimento)
        {
            this.Atendimento = atendimento;
            //this.FotosAtendimento = new List<AtendimentoFoto>();
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

        //private List<AtendimentoFoto> fotosAtendimento;
        public List<AtendimentoFoto> FotosAtendimento
        {
            get { return Atendimento.Fotos; }
            //set { fotosAtendimento = value; }
        }

        private bool atualizarDados = true;

        //private ObservableCollection<AtendimentoFoto> fotos;

        //public ObservableCollection<AtendimentoFoto> Fotos
        //{
        //    get { return new ObservableCollection<AtendimentoFoto>(Atendimento.Fotos); }
        //    set { fotos = value; }
        //}

        public async Task AtualizarFotosAsync()
        {
            if (!atualizarDados)
                return;
            Atendimento.Fotos = await atendimentoFotoDAL.GetAllAsync();
            foreach (var foto in Atendimento.Fotos)
            {
                foto.JaExibidaNaListagem = false;
            }
            //FotosAtendimento.SincronizarColecoes(Atendimento.Fotos);
            atualizarDados = false;
        }

        //public async Task<bool> AtualizarFotos()
        //{
        //    if (!atualizarDados)
        //        return await Task.FromResult(true);
        //    var fotosDAL = new AtendimentoFotoDAL(this.Atendimento, DependencyService.Get<IDBPath>().GetDbPath());
        //    //this.Atendimento.Fotos = new ObservableCollection<AtendimentoFoto>(await fotosDAL.GetAllAsync());
        //    foreach (var foto in this.Atendimento.Fotos)
        //    {
        //        foto.JaExibidaNaListagem = false;
        //    }
        //    atualizarDados = false;
        //    return await Task.FromResult(true);
        //}

        public async Task EliminarFoto(AtendimentoFoto atendimentoFoto)
        {
            //var fotoDAL = new AtendimentoFotoDAL(this.Atendimento, DependencyService.Get<IDBPath>().GetDbPath());
            //if (await fotoDAL.DeleteAsync(atendimentoFoto))
            //    File.Delete(DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(atendimentoFoto.CaminhoFoto));
        }
    }
}
