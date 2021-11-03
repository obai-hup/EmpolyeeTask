using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmpolyeeTask.Helper
{
    public class CountryApi
    {
        HttpClientHandler _ClientHandler = new HttpClientHandler();
        public CountryApi()
        {
            _ClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        }
        public HttpClient Initial()
        {
            var Client = new HttpClient(_ClientHandler);
            Client.BaseAddress = new Uri("http://localhost:5000");
            return Client;
        }
    }
}
