using hotel_api.Models;
using hotel_api.Repository.RepositoryInterfaces;
using hotel_api.Utilities;
using Microsoft.EntityFrameworkCore;

namespace hotel_api.Repository.RepositoryConcrete
{
    public class FacilityRepository : IFacilityRepository, IDisposable
    {
        private DataContext _dbContext;
        public FacilityRepository(DataContext context)
        {
            _dbContext = context;
        }

        public void AddFacility(Facility facility)
        {
            _dbContext.Facilities.Add(facility);
        }

        public void DeleteFacility(Facility facility)
        {
            Facility facilityToRemove = _dbContext.Facilities.Find(facility.Id);
            if (facilityToRemove == null)
                throw new KeyNotFoundException("Facility not found");
            _dbContext.Facilities.Remove(facilityToRemove);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IEnumerable<Facility> GetAllFacilities()
        {
            return _dbContext.Facilities.ToList();
        }

        public IEnumerable<Facility> GetFacilitiesByHotelId(int hotelId)
        {
            IEnumerable<Facility> facilities = _dbContext.Facilities.Include(x => x.Hotels.Where(y => y.Id == hotelId).ToList());
            if (facilities == null)
                throw new KeyNotFoundException("No facilities found");
            return facilities;
        }

        public Facility GetFacilityById(int id)
        {
            Facility facility = _dbContext.Facilities.Find(id);
            if (facility == null)
                throw new KeyNotFoundException("Facility not found");
            return facility;
        }

        public void UpdateFacility(Facility facility)
        {
            _dbContext.Entry<Facility>(facility).State = EntityState.Modified;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
