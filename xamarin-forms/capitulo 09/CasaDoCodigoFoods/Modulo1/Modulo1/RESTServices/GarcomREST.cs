using Modulo1.Dal;
using Modulo1.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Modulo1.RESTServices
{
    public class GarcomREST
    {
        private HttpClient client;

        public GarcomREST()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task UpdateGarconsToServerAsync(IEnumerable<Garcom> garcons)
        {
            var uri = new Uri(string.Format("https://ccfoods.azurewebsites.net/garcom/insert"));
            var garcomDAL = new GarcomDAL();

            foreach (var garcom in garcons)
            {
                //garcom.Foto = null;
                var json = JsonConvert.SerializeObject(garcom);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    garcom.OperacaoSincronismo = Modelo.Enums.OperacaoSincronismo.Sincronizado;
                    garcomDAL.Update(garcom);
                }
            }
        }

        public async Task<List<Garcom>> GetGarconsAsync()
        {
            var uri = new Uri(string.Format("https://ccfoods.azurewebsites.net/garcons/todos"));

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Garcom>>(content);
            }
            return null;
        }
    }
}
