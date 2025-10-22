using eTourist.Data.Base;
using eTourist.Models;

namespace eTourist.Data.Services
{
    public class TravelAgenciesService: EntityBaseRepository<TravelAgency>, ITravelAgenciesService
    {
        public TravelAgenciesService(AppDbContext context): base (context)
        {
            
        }
    }
}
