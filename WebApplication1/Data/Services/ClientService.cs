using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Services
{
    public class ClientService
    {
        private CSCoursContext _context;
        public ClientService(CSCoursContext context)
        {
            _context = context;
        }

        public async Task<Client?> AddClient(ClientDTO client)
        {
            Client nclient = new Client
            {
                ClientFullname = client.ClientFullname,
                ClientPhone = client.ClientPhone
            };
            var result = _context.Clients.Add(nclient);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
        public async Task<Client> GetClient(int id)
        {
            var result = _context.Clients.Include(a => a.Senders).Include(b => b.Receivers).FirstOrDefault(client => client.ClientId == id);
            return await Task.FromResult(result);

        }
        public async Task<List<Client>> GetClients()
        {
            var result = await _context.Clients.Include(a => a.Senders).Include(b => b.Receivers).OrderBy(c => c.ClientId).ToListAsync();
            return await Task.FromResult(result);
        }
        public async Task<List<IncompleteClientDTO>> GetClientsIncomplete()
        {
            var clients = await _context.Clients.ToListAsync();
            List<IncompleteClientDTO> result = new List<IncompleteClientDTO>();
            clients.ForEach(au => result.Add(new IncompleteClientDTO { ClientId = au.ClientId, ClientFullname = au.ClientFullname }));
            return await Task.FromResult(result);
        }

        public async Task<Client?> UpdateClient(int id, ClientDTO updatedClient)
        {
            var client = await _context.Clients.Include(a => a.Senders).Include(b => b.Receivers).FirstOrDefaultAsync(au => au.ClientId == id);
            if (client != null)
            {
                client.ClientFullname = updatedClient.ClientFullname;
                client.ClientPhone = updatedClient.ClientPhone;
                _context.Clients.Update(client);
                _context.Entry(client).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return client;
            }

            return null;

        }
        public async Task<bool> DeleteClient(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(au => au.ClientId == id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

    }

}
