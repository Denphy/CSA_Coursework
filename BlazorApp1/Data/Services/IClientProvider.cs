using BlazorApp1.Data.Models;

namespace BlazorApp1.Data.Services
{
    public interface IClientProvider
    {
        Task<List<Client>?> GetAll();
        Task<Client?> GetOne(int id);
        Task<int> GetLast();
        Task<bool> Add(Client item);
        Task<Client?> Edit(Client item);
        Task<bool> Remove(int id);

    }
}