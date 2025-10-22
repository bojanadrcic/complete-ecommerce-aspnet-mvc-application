using eTourist.Data.Base;
using eTourist.Models;

namespace eTourist.Data.Services
{
    public class DestinationsService: EntityBaseRepository<Destination>, IDestinationsService
    {
        public DestinationsService(AppDbContext context) : base(context)
        {
            
        }
    }
}
