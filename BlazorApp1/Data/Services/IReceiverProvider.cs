using BlazorApp1.Data.Models;

namespace BlazorApp1.Data.Services
{
    public interface IReceiverProvider
    {
        Task<List<Receiver>?> GetAll();
        Task<Receiver?> GetOne(int id);
        Task<int> GetLast();
        Task<bool> Add(Receiver item);
        Task<Receiver?> Edit(Receiver item);
        Task<bool> Remove(int id);

    }
}