using CasaDoCodigo.Models;
using Interfaces.Fotos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Capitulo06.Services
{
    public class PecaService
    {
        private void RegistrarContentsParaMultiPartForm(Peca peca, MultipartFormDataContent form)
        {
            if (!(string.IsNullOrEmpty(peca.CaminhoImagem) || peca.CaminhoImagem.StartsWith("http")))
            {
                peca.CaminhoImagem = DependencyService.Get<IFotoLoadMediaPlugin>().GetPathToPhoto(peca.CaminhoImagem);
                var fileStream = new FileStream(peca.CaminhoImagem, FileMode.Open);
                var streamContent = new StreamContent(fileStream);
                var imagemContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
                imagemContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(imagemContent, "arquivo", Path.GetFileName(peca.CaminhoImagem));

                var caminhoImagemContent = new StringContent(peca.CaminhoImagem);
                caminhoImagemContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(caminhoImagemContent, "caminhoImagem");
            }

            var pecaIDContent = new StringContent(peca.PecaID.ToString());
            pecaIDContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            form.Add(pecaIDContent, "pecaID");
            Debug.WriteLine(peca.PecaID);

            var nomeContent = new StringContent(peca.Nome);
            nomeContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            form.Add(nomeContent, "nome");

            var valorContent = new StringContent(string.Format("{0:N}", peca.Valor).Replace(',', '.'));
            valorContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            form.Add(valorContent, "valor");
        }

        public async Task<string> PostComArquivo(Peca peca)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            RegistrarContentsParaMultiPartForm(peca, form);

            using (var client = ServicesPrepare.GetHttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync("pecas/saveimagemembytes", form);
                    //HttpResponseMessage response = await client.PostAsync("pecas/savecomimagem", form);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    return await Task.FromResult("false");
                }
                catch (Exception e)
                {
                    return await Task.FromResult(e.Message);
                }
            }
        }

        public async Task<List<Peca>> GetAllAsync()
        {
            using (var client = ServicesPrepare.GetHttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("pecas/findAll");
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<List<Peca>>(await response.Content.ReadAsStringAsync());
                    }
                    throw new Exception("Erro ao recuperar peças do servidor " + response);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task Remove(Guid PecaID)
        {
            using (var client = ServicesPrepare.GetHttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(PecaID);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("pecas/removebyid", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task<Peca> GetById(Guid PecaID)
        {
            using (var client = ServicesPrepare.GetHttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("pecas/findbyid?id=" + PecaID);
                    var content = new StringContent(PecaID.ToString(), Encoding.UTF8, "application/json");
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<Peca>(await response.Content.ReadAsStringAsync());
                    }
                    throw new Exception("Erro ao recuperar peça do servidor " + response);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task<Byte[]> GetImagemById(Guid PecaID)
        {
            using (var client = ServicesPrepare.GetHttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync("pecas/getimagem/" + PecaID.ToString()).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsByteArrayAsync();
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public async Task<string> PostSemArquivo(Peca peca)
        {
            var json = JsonConvert.SerializeObject(new
            {
                pecaID = peca.PecaID,
                nome = peca.Nome,
                valor = peca.Valor
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = ServicesPrepare.GetHttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync("pecas/savesemimagem", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    return await Task.FromResult("false");
                }
                catch (Exception e)
                {
                    return await Task.FromResult(e.Message);
                }
            }
        }
    }
}
