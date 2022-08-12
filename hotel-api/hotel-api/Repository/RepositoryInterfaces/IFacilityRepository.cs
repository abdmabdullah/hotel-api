using hotel_api.Models;

namespace hotel_api.Repository.RepositoryInterfaces
{
    public interface IFacilityRepository : IDisposable
    {
        IEnumerable<Facility> GetAllFacilities();
        Facility GetFacilityById(int id);
        IEnumerable<Facility> GetFacilitiesByHotelId(int hotelId);
        void AddFacility(Facility facility);
        void DeleteFacility(Facility facility);
        void UpdateFacility(Facility facility);
    }
}
