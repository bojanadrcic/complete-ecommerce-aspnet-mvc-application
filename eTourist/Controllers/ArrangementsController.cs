using eTourist.Data;
using eTourist.Data.Services;
using eTourist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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

            return View(allArrangements);
        }


        public async Task<IActionResult> Filter(string searchString)
        {
            var allArrangements = await _service.GetAllAsync(n => n.Destination);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allArrangements.Where (n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allArrangements);
        }

        //GET: Arrangements/Detail/1
        public async Task<IActionResult> Details(int id)
        {
            var arrangementDetails = await _service.GetArrangementByIdAsync(id);

            return View(arrangementDetails);
        }

        //GET: Arrangements/Create
        public async Task<IActionResult> Create()
        {
            var arrangementDropdownsData = await _service.GetNewArrangementDropdownsValues();

            ViewBag.Destinations = new SelectList(arrangementDropdownsData.Destinations, "Id", "Name");
            ViewBag.TravelAgencies = new SelectList(arrangementDropdownsData.TravelAgencies, "Id", "FullName");
            ViewBag.TourGuides = new SelectList(arrangementDropdownsData.TourGuides, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewArrangementVM arrangement)
        {
            if (!ModelState.IsValid)
            {
                var arrangementDropdownsData = await _service.GetNewArrangementDropdownsValues();

                ViewBag.Destinations = new SelectList(arrangementDropdownsData.Destinations, "Id", "Name");
                ViewBag.TravelAgencies = new SelectList(arrangementDropdownsData.TravelAgencies, "Id", "FullName");
                ViewBag.TourGuides = new SelectList(arrangementDropdownsData.TourGuides, "Id", "FullName");

                return View(arrangement);
            }

            await _service.AddNewArrangementAsync(arrangement);
            return RedirectToAction(nameof(Index));
        }


        //GET: Arrangements/Edit/1
        public async Task<IActionResult> Edit(int id)
        {

            var arrangementDetails = await _service.GetArrangementByIdAsync(id);
            if (arrangementDetails == null) return View("NotFound");

            var response = new NewArrangementVM()
            {
                Id= arrangementDetails.Id, 
                Name = arrangementDetails.Name,
                Description = arrangementDetails.Description,  
                Price = arrangementDetails.Price,
                StartDate = arrangementDetails.StartDate,
                EndDate = arrangementDetails.EndDate,
                ImageURL = arrangementDetails.ImageURL,
                ArrangementCategory=arrangementDetails.ArrangementCategory,
                DestinationId= arrangementDetails.DestinationId,
                TravelAgencyId= arrangementDetails.TravelAgencyId,
                TourGuideIds=arrangementDetails.TourGuides_Arrangements.Select(n => n.TourGuideId).ToList(),
            };

            var arrangementDropdownsData = await _service.GetNewArrangementDropdownsValues();

            ViewBag.Destinations = new SelectList(arrangementDropdownsData.Destinations, "Id", "Name");
            ViewBag.TravelAgencies = new SelectList(arrangementDropdownsData.TravelAgencies, "Id", "FullName");
            ViewBag.TourGuides = new SelectList(arrangementDropdownsData.TourGuides, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewArrangementVM arrangement)
        {
            if (id != arrangement.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var arrangementDropdownsData = await _service.GetNewArrangementDropdownsValues();

                ViewBag.Destinations = new SelectList(arrangementDropdownsData.Destinations, "Id", "Name");
                ViewBag.TravelAgencies = new SelectList(arrangementDropdownsData.TravelAgencies, "Id", "FullName");
                ViewBag.TourGuides = new SelectList(arrangementDropdownsData.TourGuides, "Id", "FullName");

                return View(arrangement);
            }

            await _service.UpdateArrangementAsync(arrangement);
            return RedirectToAction(nameof(Index));
        }
    }
}
