using Capitulo06.ExtensionMethods;
using Capitulo06.Services;
using CasaDoCodigo.DAL;
using CasaDoCodigo.DataAccess;
using CasaDoCodigo.DataAccess.Interfaces;
using CasaDoCodigo.Models;
using Interfaces.Fotos;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo06.ViewModels.Pecas
{
    public class ListagemViewModel : BaseViewModel
    {
        private IDAL<Peca> pecasDAL;
        public ObservableCollection<Peca> Pecas { get; set; }

        public ICommand NovoCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SincronizarCommand { get; set; }
        public bool AtualizandoImagens = false;
        private PecaService service;

        public ListagemViewModel()
        {
            pecasDAL = new PecaDAL(DependencyService.Get<IDBPath>().GetDbPath());
            Pecas = new ObservableCollection<Peca>();
            service = new PecaService();
            RegistrarCommands();
        }

        private Peca pecaSelecionada;
        public Peca PecaSelecionada
        {
            get { return pecaSelecionada; }
            set
            {
                if (value != null)
                {
                    pecaSelecionada = value;
                    if (pecaSelecionada.ImagemEmBytes == null)
                        AtualizarImagem(pecaSelecionada);
                    MessagingCenter.Send<Peca>(pecaSelecionada, "Mostrar");
                }
            }
        }

        private void AtualizarImagem(Peca peca)
        {
            Task.Run(async () => {
                if (peca.ImagemEmBytes == null)
                {
                    var i = Pecas.IndexOf(peca);
                    peca.ImagemEmBytes = await GetBytesFromImageAsync(peca.PecaID);
                    if (peca.ImagemEmBytes == null && string.IsNullOrEmpty(peca.CaminhoImagem))
                        peca.CaminhoImagem = "consultar.png";
                    this.Pecas.RemoveAt(i);
                    this.Pecas.Insert(i, peca);
                }
            });
        }

        public async Task AtualizarPecasAsync()
        {
            var pecas = await ((PecaDAL)pecasDAL).GetAllAsync();
            Pecas.SincronizarColecoes(pecas);
        }

        public void AtualizarImagens()
        {
            AtualizandoImagens = true;
            for (int i = 0; i < Pecas.Count; i++)
            {
                AtualizarImagem(Pecas[i]);
            }
            AtualizandoImagens = false;
        }

        public async Task<Byte[]> GetBytesFromImageAsync(Guid pecaID)
        {
            return await service.GetImagemByIdAsync(pecaID);
        }

        private bool sincronizando;
        public bool Sincronizando
        {
            get { return this.sincronizando; }
            set
            {
                this.sincronizando = value;
                OnPropertyChanged();
            }
        }


        private void RegistrarCommands()
        {
            NovoCommand = new Command(() =>
            {
                MessagingCenter.Send<Peca>(new Peca(), "Mostrar");
            });

            EliminarCommand = new Command<Peca>((peca) =>
            {
                MessagingCenter.Send<Peca>(peca, "Confirmação");
            });

            RefreshCommand = new Command(async () =>
            {
                try
                {
                    Sincronizando = true;
                    var pecasREST = await service.GetAllAsync();
                    await (pecasDAL as PecaDAL).SincronizaBaseLocal(pecasREST);
                    AtualizandoImagens = true;
                    await AtualizarPecasAsync();
                    AtualizarImagens();
                    MessagingCenter.Send<string>("Sincronização realizada com sucesso.", "Informação");
                }
                catch (Exception e)
                {
                    MessagingCenter.Send<string>(e.Message, "Informação");
                } finally
                {
                    Sincronizando = false;
                }
            });

            SincronizarCommand = new Command<Peca>(async (peca) =>
            {
                Sincronizando = true;
                peca.CaminhoImagem = peca.CaminhoImagem.Equals("consultar.png") ? null : peca.CaminhoImagem;
                var result = await service.PostComArquivo(peca);
                Sincronizando = false;
                if (result.ToLower().Equals("true"))
                {
                    MessagingCenter.Send<string>("Atualização realizada com sucesso.", "Informação");
                    if (!string.IsNullOrEmpty(peca.CaminhoImagem) && File.Exists(DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(peca.CaminhoImagem)))
                        File.Delete(DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(peca.CaminhoImagem));
                    peca.CaminhoImagem = string.Empty;
                    await pecasDAL.UpdateAsync(peca, peca.PecaID, nameof(Peca.PecaID), true);
                    AtualizarImagem(peca);
                    this.Pecas[this.Pecas.IndexOf(peca)] = peca;
                }
                else
                {
                    MessagingCenter.Send<string>(result.ToLower().Equals("false") ? "Erro na comunicação" : result, "Informação");
                }
            });

        }

        public async Task EliminarPecaAsync(Peca peca)
        {
            Sincronizando = true;
            await service.Remove(peca.PecaID);
            await pecasDAL.DeleteAsync(peca);
            Pecas.Remove(peca);
            Sincronizando = false;
        }
    }
}
