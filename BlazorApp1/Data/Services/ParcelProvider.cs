using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BlazorApp1.Data.Models;


namespace BlazorApp1.Data.Services
{
    public class ParcelsProvider : IParcelProvider
    {
        private HttpClient _parcel;
        public ParcelsProvider(HttpClient parcel)
        {
            _parcel = parcel;
        }

        public async Task<List<Parcel>?> GetAll()
        {
            return await _parcel.GetFromJsonAsync<List<Parcel>>("/api/Parcel");
        }
        public async Task<int> GetLast()
        {
            var responce = await _parcel.GetFromJsonAsync<List<Parcel>>("/api/Parcel");
            return await Task.FromResult(responce.Select(parcel => parcel.ParcelId).LastOrDefault());
        }
        public async Task<Parcel?> GetOne(int id)
        {
            return await _parcel.GetFromJsonAsync<Parcel>($"/api/Parcel/{id}");
        }

        public async Task<bool> Add(Parcel item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _parcel.PostAsync($"/api/Parcel", httpContent);
            return await Task.FromResult(responce.IsSuccessStatusCode);
        }

        public async Task<Parcel?> Edit(Parcel item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var responce = await _parcel.PutAsync($"/api/Parcel", httpContent);
            Parcel? Parcel = JsonConvert.DeserializeObject<Parcel>(responce.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(Parcel);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = await _parcel.DeleteAsync($"/api/Parcel/${id}");

            return await Task.FromResult(delete.IsSuccessStatusCode);
        }

    }
}
