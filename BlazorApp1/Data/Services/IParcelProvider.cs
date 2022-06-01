using BlazorApp1.Data.Models;

namespace BlazorApp1.Data.Services
{
    public interface IParcelProvider
    {
        Task<List<Parcel>?> GetAll();
        Task<Parcel?> GetOne(int id);
        Task<int> GetLast();
        Task<bool> Add(Parcel item);
        Task<Parcel?> Edit(Parcel item);
        Task<bool> Remove(int id);

    }
}