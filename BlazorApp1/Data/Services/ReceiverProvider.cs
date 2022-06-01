using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BlazorApp1.Data.Models;


namespace BlazorApp1.Data.Services
{
    public class ReceiversProvider : IReceiverProvider
    {
        private HttpClient _receiver;
        public ReceiversProvider(HttpClient receiver)
        {
            _receiver = receiver;
        }

        public async Task<List<Receiver>?> GetAll()
        {
            return await _receiver.GetFromJsonAsync<List<Receiver>>("/api/Receiver");
        }

        public async Task<Receiver?> GetOne(int id)
        {
            return await _receiver.GetFromJsonAsync<Receiver>($"/api/Receiver/{id}");
        }
        public async Task<int> GetLast()
        {
            var responce = await _receiver.GetFromJsonAsync<List<Receiver>>("/api/Receiver");
            return await Task.FromResult(responce.Select(receiver => receiver.ReceiverId).LastOrDefault());
        }

        public async Task<bool> Add(Receiver item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _receiver.PostAsync($"/api/Receiver", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Receiver?> Edit(Receiver item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _receiver.PutAsync($"/api/Receiver", httpContent);
            Receiver? Receiver = JsonConvert.DeserializeObject<Receiver>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(Receiver);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _receiver.DeleteAsync($"/api/Receiver/${id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

    }
}
