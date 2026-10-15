using pract7.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pract7
{
    public class API
    {
        public HttpClient httpClient { get; set; }

        public ObservableCollection<Device> devices { get; set; } = new();
        public API()
        {
            httpClient = new();
            httpClient.BaseAddress = new Uri("http://localhost:5092/");
           
        }


        public async Task<HttpResponseMessage> Get()
        {
            return await httpClient.GetAsync("api/v1/Devices");
        }
    }
}
