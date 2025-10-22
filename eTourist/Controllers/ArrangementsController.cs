using eTourist.Data;
using eTourist.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTourist.Controllers
{
    public class ArrangementsController : Controller
    {
        private readonly IArrangementsService _service;
        public ArrangementsController(IArrangementsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allArrangements = await _service.GetAllAsync(n => n.Destination);
         //.Include(a => a.Destination)      // povezana destinacija
         //.Include(a => a.TravelAgency)     // povezana agencija
         //.Include(a => a.TourGuides_Arrangements)  
         //    .ThenInclude(ta => ta.TourGuide)   // vodiči koji rade na tom aranžmanu
         //.ToListAsync();

            return View(allArrangements);
        }

        //GET: Arrangements/Detail/1
        public async Task<IActionResult> Details(int id)
        {
            var arrangementDetail = await _service.GetArrangementByIdAsync(id);

            return View(arrangementDetail);
        }
    }
}
