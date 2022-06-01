using BlazorApp1.Data.Models;

namespace BlazorApp1.Data.Services
{
    public interface ISenderProvider
    {
        Task<List<Sender>?> GetAll();
        Task<Sender?> GetOne(int id);
        Task<int> GetLast();
        Task<bool> Add(Sender item);
        Task<Sender?> Edit(Sender item);
        Task<bool> Remove(int id);

    }
}