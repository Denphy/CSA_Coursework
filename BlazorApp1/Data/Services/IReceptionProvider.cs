using BlazorApp1.Data.Models;

namespace BlazorApp1.Data.Services
{
    public interface IReceptionProvider
    {
        Task<List<Reception>?> GetAll();
        Task<Reception?> GetOne(int id);
        Task<bool> Add(Reception item);
        Task<Reception?> Edit(Reception item);
        Task<bool> Remove(int id);

    }
}