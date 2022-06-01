using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BlazorApp1.Data.Models;


namespace BlazorApp1.Data.Services
{
    public class ClientsProvider : IClientProvider
    {
        private HttpClient _client;
        public ClientsProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Client>?> GetAll()
        {
            return await _client.GetFromJsonAsync<List<Client>>("/api/Client");
        }

        public async Task<int> GetLast()
        {
            var responce =  await _client.GetFromJsonAsync<List<Client>>("/api/Client");
            return await Task.FromResult(responce.Select(client => client.ClientId).LastOrDefault());
        }

        public async Task<Client?> GetOne(int id)
        {
            return await _client.GetFromJsonAsync<Client>($"/api/Client/{id}");
        }

        public async Task<bool> Add(Client item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"/api/Client", httpContent);
            
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Client?> Edit(Client item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync($"/api/Client", httpContent);
            Client? Client = JsonConvert.DeserializeObject<Client>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(Client);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _client.DeleteAsync($"/api/Client/${id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

    }
}
