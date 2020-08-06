using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xamarin.Essentials;

namespace Capitulo05.Services
{
    public class ServicesPrepare
    {
        public static HttpClient GetHttpClient()
        {
            var proxy = WebRequest.DefaultWebProxy;
            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                Proxy = proxy,
                //                Proxy = new WebProxy("http://200.124.29.64:4239"),
                UseProxy = (proxy != null)
            };

            HttpClient client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri("https://meucalhambeque02.herokuapp.com/");

            if (!Connectivity.ConnectionProfiles.Contains(ConnectionProfile.WiFi))
                throw new Exception("Sem acesso à WIFI");

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                throw new Exception("Sem acesso à internet");

            return client;
        }
    }
}
