using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Services
{
    public class SenderService
    {
        private CSCoursContext _context;
        public SenderService(CSCoursContext context)
        {
            _context = context;
        }
        public async Task<Sender?> AddSender(ClientSplitDTO sender)
        {
            Sender nsender = new Sender
            {
                ClientId = sender.ClientId
            };
            var result = _context.Senders.Add(nsender);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
        public async Task<Sender> GetSender(int id)
        {
            var result = _context.Senders.Include(a => a.Clients).FirstOrDefault(sender => sender.SenderId == id);
            return await Task.FromResult(result);

        }
        public async Task<List<Sender>> GetSenders()
        {
            var result = await _context.Senders.Include(a => a.Clients).Include(a => a.Parcels).ToListAsync();
            return await Task.FromResult(result);
        }
        public async Task<Sender?> UpdateSender(int id, ClientSplitDTO updatedSender)
        {
            var sender = await _context.Senders.Include(a => a.Clients).FirstOrDefaultAsync(au => au.SenderId == id);
            if (sender != null)
            {
                sender.ClientId = updatedSender.ClientId;
                _context.Senders.Update(sender);
                _context.Entry(sender).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return sender;
            }

            return null;

        }

        public async Task<bool> DeleteSender(int id)
        {
            var sender = await _context.Senders.FirstOrDefaultAsync(au => au.SenderId == id);
            if (sender != null)
            {
                _context.Senders.Remove(sender);
                await _context.SaveChangesAsync();
                return true;
            }


            return false;

        }
    }
}
