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

        public async Task<List<Device>> Get()
        {
            return await httpClient.GetFromJsonAsync<List<Device>>("api/v1/Devices");
        }
        public async Task<List<Device>> GetFiltered(string filterManufacture, decimal filterMinPrice)
        {
            try
            {
                var response = await httpClient.GetFromJsonAsync<List<Device>>($"api/v1/Devices?manufacture={filterManufacture}&minPrice={filterMinPrice}");
                if (response != null)
                {
                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<HttpResponseMessage> Remove(int index)
        {
            return await httpClient.DeleteAsync($"api/v1/Devices/{index}");
        }
        public async Task<HttpResponseMessage> Post(Device device)
        {
            return await httpClient.PostAsJsonAsync(
                "api/v1/Devices",
                device
                );
        }
        public async Task<HttpResponseMessage> Put(Device device, int index)
        {
            return await httpClient.PutAsJsonAsync(
                $"api/v1/Devices/{index}",
                device
                );
        }
        public async Task<HttpResponseMessage> Patch(Device device, int index)
        {
            return await httpClient.PatchAsJsonAsync(
                $"api/v1/Devices/{index}",
                device
                );
        }
    }
}
