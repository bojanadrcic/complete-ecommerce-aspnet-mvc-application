using eTourist.Data.Base;
using eTourist.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTourist.Data.Services
{
    public class TourGuidesService : EntityBaseRepository <TourGuide>, ITourGuidesService
    {
        public TourGuidesService(AppDbContext context) : base(context) { }

    }
}
