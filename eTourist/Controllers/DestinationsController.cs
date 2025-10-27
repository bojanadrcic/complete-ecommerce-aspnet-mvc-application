using eTourist.Data;
using eTourist.Data.Services;
using eTourist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTourist.Controllers
{
    [Authorize]
    public class DestinationsController : Controller
    {
        
        private readonly IDestinationsService _service;
        public DestinationsController(IDestinationsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allDestinations = await _service.GetAllAsync();
            return View(allDestinations);
        }

        //Get: Destinations/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create([Bind("Picture, Name, Description")]Destination destination)
        {
            if (!ModelState.IsValid) return View(destination);
            await _service.AddAsync(destination);
            return RedirectToAction(nameof(Index));
        }

        //Get: TourGuides/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var destinationDetails = await _service.GetByIdAsync(id);

            if (destinationDetails == null) return View("NotFound");
            return View(destinationDetails);
        }

        //Get: Destinations/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var destinationDetails = await _service.GetByIdAsync(id);
            if (destinationDetails == null) return View("NotFound");
            return View(destinationDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Picture,Name,Description")] Destination destination)
        {
            if (!ModelState.IsValid) return View(destination);

            if (id == destination.Id)
            {
                await _service.UpdateAsync(id, destination);
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        //Get: Destinations/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var destinationDetails = await _service.GetByIdAsync(id);
            if (destinationDetails == null) return View("NotFound");
            return View(destinationDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinationDetails = await _service.GetByIdAsync(id);
            if (destinationDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
