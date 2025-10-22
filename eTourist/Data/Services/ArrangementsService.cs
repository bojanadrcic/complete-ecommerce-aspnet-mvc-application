using eTourist.Data.Base;
using eTourist.Models;
using Microsoft.EntityFrameworkCore;

namespace eTourist.Data.Services
{
    public class ArrangementsService: EntityBaseRepository<Arrangement>, IArrangementsService
    {
        private readonly AppDbContext _context;
        public ArrangementsService(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<Arrangement> GetArrangementByIdAsync(int id)
        {
            var arrangementDetails = await _context.Arrangements
                .Include(d => d.Destination)      // povezana destinacija
                .Include(g => g.TravelAgency)     // povezana agencija
                .Include(ta => ta.TourGuides_Arrangements)
                .ThenInclude(t => t.TourGuide)   // vodiči koji rade na tom aranžmanu
                .FirstOrDefaultAsync(n => n.Id == id);
            return arrangementDetails;
        }
    }
}
