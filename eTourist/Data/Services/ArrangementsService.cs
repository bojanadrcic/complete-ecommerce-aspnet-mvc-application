using eTourist.Data.Base;
using eTourist.Data.ViewModels;
using eTourist.Models;
using Microsoft.EntityFrameworkCore;

namespace eTourist.Data.Services
{
    public class ArrangementsService : EntityBaseRepository<Arrangement>, IArrangementsService
    {
        private readonly AppDbContext _context;
        public ArrangementsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewArrangementAsync(NewArrangementVM data)
        {
            var newArrangement = new Arrangement()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                DestinationId = data.DestinationId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                TravelAgencyId = data.TravelAgencyId,
                ArrangementCategory = data.ArrangementCategory,
            };
            await _context.Arrangements.AddAsync(newArrangement);
            await _context.SaveChangesAsync();

            //Add tourguides
            foreach (var tourguideId in data.TourGuideIds)
            {
                var newTourGuideArrangement = new TourGuide_Arrangement()
                {
                    ArrangementId = newArrangement.Id,
                    TourGuideId = tourguideId,
                };
                await _context.TourGuides_Arrangements.AddAsync(newTourGuideArrangement);
            }
            await _context.SaveChangesAsync();
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

        public async Task<NewArrangementDropdownsVM> GetNewArrangementDropdownsValues()
        {
            var response = new NewArrangementDropdownsVM();
            response.TourGuides = await _context.TourGuides.OrderBy(n => n.FullName).ToListAsync();
            response.Destinations = await _context.Destinations.OrderBy(n => n.Name).ToListAsync();
            response.TravelAgencies = await _context.TravelAgencies.OrderBy(n => n.FullName).ToListAsync();

            return response;
        }

        public async Task UpdateArrangementAsync(NewArrangementVM data)
        {
            var dbArrangement = await _context.Arrangements.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbArrangement != null)
            {

                dbArrangement.Name = data.Name;
                dbArrangement.Description = data.Description;
                dbArrangement.Price = data.Price;
                dbArrangement.ImageURL = data.ImageURL;
                dbArrangement.DestinationId = data.DestinationId;
                dbArrangement.StartDate = data.StartDate;
                dbArrangement.EndDate = data.EndDate;
                dbArrangement.TravelAgencyId = data.TravelAgencyId;
                dbArrangement.ArrangementCategory = data.ArrangementCategory;
                await _context.SaveChangesAsync();
            }

            //Remove existing tourguides
            var existingTourGuidesDb = _context.TourGuides_Arrangements.Where(n => n.ArrangementId == data.Id).ToList();
            _context.TourGuides_Arrangements.RemoveRange(existingTourGuidesDb);
            await _context.SaveChangesAsync();

            //Add tourguides
            foreach (var tourguideId in data.TourGuideIds)
            {
                var newTourGuideArrangement = new TourGuide_Arrangement()
                {
                    ArrangementId = data.Id,
                    TourGuideId = tourguideId,
                };
                await _context.TourGuides_Arrangements.AddAsync(newTourGuideArrangement);
            }
            await _context.SaveChangesAsync();
        }
    }
}
