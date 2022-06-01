using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BlazorApp1.Data.Models;


namespace BlazorApp1.Data.Services
{
    public class SendersProvider : ISenderProvider
    {
        private HttpClient _sender;
        public SendersProvider(HttpClient sender)
        {
            _sender = sender;
        }

        public async Task<List<Sender>?> GetAll()
        {
            return await _sender.GetFromJsonAsync<List<Sender>>("/api/Sender");
        }

        public async Task<Sender?> GetOne(int id)
        {
            return await _sender.GetFromJsonAsync<Sender>($"/api/Sender/{id}");
        }
        public async Task<int> GetLast()
        {
            var responce = await _sender.GetFromJsonAsync<List<Sender>>("/api/Sender");
            return await Task.FromResult(responce.Select(sender => sender.SenderId).LastOrDefault());
        }

        public async Task<bool> Add(Sender item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _sender.PostAsync($"/api/Sender", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Sender?> Edit(Sender item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _sender.PutAsync($"/api/Sender", httpContent);
            Sender? Sender = JsonConvert.DeserializeObject<Sender>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(Sender);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _sender.DeleteAsync($"/api/Sender/${id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

    }
}
