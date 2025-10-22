using eTourist.Data;
using eTourist.Data.Services;
using eTourist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTourist.Controllers
{
    public class TravelAgenciesController : Controller
    {
        private readonly ITravelAgenciesService _service;
        public TravelAgenciesController(ITravelAgenciesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allTravelAgencies = await _service.GetAllAsync();
            return View(allTravelAgencies);
        }

        //Get: travelagencies/details/1
        public async Task<IActionResult> Details (int id)
        {
            var travelagencyDetails = await _service.GetByIdAsync(id);
            if (travelagencyDetails == null) return View("NotFound");
            return View(travelagencyDetails);
        }

        //Get: travelagencies/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]TravelAgency travelagency)
        {
            if (!ModelState.IsValid) return View(travelagency);

            await _service.AddAsync(travelagency);
            return RedirectToAction(nameof(Index));
        }

        //Get: travelagencies/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var travelagencyDetails = await _service.GetByIdAsync(id);
            if (travelagencyDetails == null) return View("NotFound");
            return View(travelagencyDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureURL,FullName,Bio")] TravelAgency travelagency)
        {
            if (!ModelState.IsValid) return View(travelagency);

            if(id == travelagency.Id)
            {
                await _service.UpdateAsync(id, travelagency);
                return RedirectToAction(nameof(Index));
            }
            return View (travelagency);
        }

        //Get: travelagencies/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var travelagencyDetails = await _service.GetByIdAsync(id);
            if (travelagencyDetails == null) return View("NotFound");
            return View(travelagencyDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelagencyDetails = await _service.GetByIdAsync(id);
            if (travelagencyDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index)); 
        }
    }
}
