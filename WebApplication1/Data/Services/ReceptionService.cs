using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Services
{
    public class ReceptionService
    {
        private CSCoursContext _context;
        public ReceptionService(CSCoursContext context)
        {
            _context = context;
        }
        public async Task<Reception?> AddReception(ReceptionDTO reception)
        {
            Reception nreception = new Reception
            {
                ReceptionName = reception.ReceptionName,
                ReceptionAddress = reception.ReceptionAddress,
                ReceptionWeekdayStartTime = reception.ReceptionWeekdayStartTime,
                ReceptionWeekdayEndTime = reception.ReceptionWeekdayEndTime,
                ReceptionWeekendStartTime = reception.ReceptionWeekendStartTime,
                ReceptionWeekendEndTime = reception.ReceptionWeekendEndTime
            };
            var result = _context.Receptions.Add(nreception);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
        public async Task<Reception> GetReception(int id)
        {
            var result = _context.Receptions.Include(a => a.Parcels).FirstOrDefault(reception => reception.ReceptionId == id);
            return await Task.FromResult(result);

        }
        public async Task<List<Reception>> GetReceptions()
        {
            var result = await _context.Receptions.Include(a => a.Parcels).ToListAsync();
            return await Task.FromResult(result);
        }
        public async Task<List<IncompleteReceptionDTO>> GetReceptionsIncomplete()
        {
            var receptions = await _context.Receptions.ToListAsync();
            List<IncompleteReceptionDTO> result = new List<IncompleteReceptionDTO>();
            receptions.ForEach(au => result.Add(new IncompleteReceptionDTO { ReceptionId = au.ReceptionId, ReceptionName = au.ReceptionName, ReceptionAddress = au.ReceptionAddress }));
            return await Task.FromResult(result);
        }
        public async Task<Reception?> UpdateReception(int id, ReceptionDTO updatedReception)
        {
            var reception = await _context.Receptions.Include(a => a.Parcels).FirstOrDefaultAsync(au => au.ReceptionId == id);
            if (reception != null)
            {
                reception.ReceptionName = updatedReception.ReceptionName;
                reception.ReceptionAddress = updatedReception.ReceptionAddress;
                reception.ReceptionWeekdayStartTime = updatedReception.ReceptionWeekdayStartTime;
                reception.ReceptionWeekdayEndTime = updatedReception.ReceptionWeekdayEndTime;
                reception.ReceptionWeekendStartTime = updatedReception.ReceptionWeekendStartTime;
                reception.ReceptionWeekendEndTime = updatedReception.ReceptionWeekendEndTime;
                _context.Receptions.Update(reception);
                _context.Entry(reception).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return reception;
            }

            return null;

        }
        public async Task<bool> DeleteReception(int id)
        {
            var reception = await _context.Receptions.FirstOrDefaultAsync(au => au.ReceptionId == id);
            if (reception != null)
            {
                _context.Receptions.Remove(reception);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
    }
}
