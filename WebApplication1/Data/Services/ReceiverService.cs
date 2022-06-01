using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Services
{
    public class ReceiverService
    {
        private CSCoursContext _context;
        public ReceiverService(CSCoursContext context)
        {
            _context = context;
        }
        public async Task<Receiver?> AddReceiver(ClientSplitDTO receiver)
        {
            Receiver nreceiver = new Receiver
            {
                ClientId = receiver.ClientId
            };
            var result = _context.Receivers.Add(nreceiver);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
        public async Task<Receiver> GetReceiver(int id)
        {
            var result = _context.Receivers.Include(a => a.Clients).FirstOrDefault(receiver => receiver.ReceiverId == id);
            return await Task.FromResult(result);

        }
        public async Task<List<Receiver>> GetReceivers()
        {
            var result = await _context.Receivers.Include(a => a.Clients).ToListAsync();
            return await Task.FromResult(result);
        }
        public async Task<Receiver?> UpdateReceiver(int id, ClientSplitDTO updatedReceiver)
        {
            var receiver = await _context.Receivers.Include(a => a.Clients).Include(a => a.Clients).FirstOrDefaultAsync(au => au.ReceiverId == id);
            if (receiver != null)
            {
                receiver.ClientId = updatedReceiver.ClientId;
                _context.Receivers.Update(receiver);
                _context.Entry(receiver).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return receiver;
            }

            return null;

        }

        public async Task<bool> DeleteReceiver(int id)
        {
            var receiver = await _context.Receivers.FirstOrDefaultAsync(au => au.ReceiverId == id);
            if (receiver != null)
            {
                _context.Receivers.Remove(receiver);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
    }
}
