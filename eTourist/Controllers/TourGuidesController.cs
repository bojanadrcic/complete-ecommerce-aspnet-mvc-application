using eTourist.Data;
using eTourist.Data.Services;
using eTourist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTourist.Controllers
{

    [Authorize]
    public class TourGuidesController : Controller
    {
        private readonly ITourGuidesService _service;
        public TourGuidesController(ITourGuidesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async  Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);

            //var allTourGuides = await _service.GetByIdAsync(id); // ✅ uzmi sve vodiče iz baze
            //return View(allTourGuides);
        }

        //Get: TourGuides/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")]TourGuide tourguide)
        {
            if (!ModelState.IsValid)
            {
               return View(tourguide);
            }
            await _service.AddAsync(tourguide);
            return RedirectToAction(nameof(Index));
        }

        //Get: TourGuides/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var tourguideDetails = await _service.GetByIdAsync(id);

            if (tourguideDetails == null) return View("NotFound");
            return View(tourguideDetails);
        }

        //Get: TourGuides/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var tourguideDetails = await _service.GetByIdAsync(id);

            if (tourguideDetails == null) return View("NotFound");
            return View(tourguideDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] TourGuide tourguide)
        {
            if (!ModelState.IsValid)
            {
                return View(tourguide);
            }
            await _service.UpdateAsync(id, tourguide);
            return RedirectToAction(nameof(Index));
        }


        //Get: TourGuides/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var tourguideDetails = await _service.GetByIdAsync(id);
            if (tourguideDetails == null) return View("NotFound");
            return View(tourguideDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tourguideDetails = await _service.GetByIdAsync(id);
            if (tourguideDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
