using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BlazorApp1.Data.Models;


namespace BlazorApp1.Data.Services
{
    public class ReceptionsProvider : IReceptionProvider
    {
        private HttpClient _reception;
        public ReceptionsProvider(HttpClient reception)
        {
            _reception = reception;
        }

        public async Task<List<Reception>?> GetAll()
        {
            return await _reception.GetFromJsonAsync<List<Reception>>("/api/Reception");
        }

        public async Task<Reception?> GetOne(int id)
        {
            return await _reception.GetFromJsonAsync<Reception>($"/api/Reception/{id}");
        }

        public async Task<bool> Add(Reception item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _reception.PostAsync($"/api/Reception", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Reception?> Edit(Reception item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _reception.PutAsync($"/api/Reception", httpContent);
            Reception? Reception = JsonConvert.DeserializeObject<Reception>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(Reception);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _reception.DeleteAsync($"/api/Reception/${id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

    }
}
