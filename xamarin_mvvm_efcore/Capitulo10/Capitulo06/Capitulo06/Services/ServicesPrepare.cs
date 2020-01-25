using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xamarin.Essentials;

namespace Capitulo06.Services
{
    public class ServicesPrepare
    {
        public static HttpClient GetHttpClient()
        {
            var proxy = WebRequest.DefaultWebProxy;
            HttpClientHandler clientHandler = new HttpClientHandler()
            {
                Proxy = proxy,
                //Proxy = new WebProxy("http://200.134.18.53:3128"),
                //UseProxy = (proxy != null)
            };

            HttpClient client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri("https://meucalhambeque02.herokuapp.com/");

            //if (!Connectivity.Profiles.Contains(ConnectionProfile.WiFi))
            //    throw new Exception("Sem acesso à WIFI");

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                throw new Exception("Sem acesso à internet");

            return client;
        }
    }
}