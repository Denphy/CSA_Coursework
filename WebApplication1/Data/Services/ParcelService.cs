using WebApplication1.Data.Models;
using WebApplication1.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Services
{
    public class ParcelService
    {
        private CSCoursContext _context;
        public ParcelService(CSCoursContext context)
        {
            _context = context;
        }
        public async Task<Parcel?> AddParcel(ParcelDTO parcel)
        {
            Parcel nparcel = new Parcel
            {
                SenderId = parcel.SenderId,
                ReceiverId = parcel.ReceiverId,
                ReceptionId = parcel.ReceptionId,
                ParcelRate = parcel.ParcelRate,
                ParcelSize = parcel.ParcelSize,
                ParcelWeight = parcel.ParcelWeight,
                ParcelAddress = parcel.ParcelAddress,
                ParcelStatus = parcel.ParcelStatus
            };
            var result = _context.Parcels.Add(nparcel);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
        public async Task<Parcel> GetParcel(int id)
        {
            var result = _context.Parcels.Include(a => a.Senders).Include(b => b.Receivers).Include(c => c.Receptions).FirstOrDefault(parcel => parcel.ParcelId == id);
            return await Task.FromResult(result);

        }
        public async Task<List<Parcel>> GetParcels()
        {
            var result = await _context.Parcels.Include(a => a.Senders).Include(b => b.Receivers).Include(c => c.Receptions).ToListAsync();
            return await Task.FromResult(result);
        }
        public async Task<List<IncompleteParcelDTO>> GetParcelsIncomplete()
        {
            var parcels = await _context.Parcels.ToListAsync();
            List<IncompleteParcelDTO> result = new List<IncompleteParcelDTO>();
            parcels.ForEach(au => result.Add(new IncompleteParcelDTO { ParcelId = au.ParcelId, ParcelStatus = au.ParcelStatus}));
            return await Task.FromResult(result);
        }
        public async Task<Parcel?> UpdateParcel(int id, ParcelDTO updatedParcel)
        {
            var parcel = await _context.Parcels.Include(a => a.Senders).Include(b => b.Receivers).Include(c => c.Receptions).FirstOrDefaultAsync(au => au.ParcelId == id);
            if (parcel != null)
            {
                parcel.SenderId = updatedParcel.SenderId;
                parcel.ReceiverId = updatedParcel.ReceiverId;
                parcel.ReceptionId = updatedParcel.ReceptionId;
                parcel.ParcelRate = updatedParcel.ParcelRate;
                parcel.ParcelSize = updatedParcel.ParcelSize;
                parcel.ParcelWeight = updatedParcel.ParcelWeight;
                parcel.ParcelAddress = updatedParcel.ParcelAddress;
                parcel.ParcelStatus = updatedParcel.ParcelStatus;
                _context.Parcels.Update(parcel);
                _context.Entry(parcel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return parcel;
            }

            return null;

        }

        public async Task<bool> DeleteParcel(int id)
        {
            var parcel = await _context.Parcels.FirstOrDefaultAsync(au => au.ParcelId == id);
            if (parcel != null)
            {
                _context.Parcels.Remove(parcel);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
    }
}
