using eTourist.Models;

namespace eTourist.Data.ViewModels
{
    public class NewArrangementDropdownsVM
    {
        public NewArrangementDropdownsVM()
        {
            TravelAgencies = new List<TravelAgency>();
            Destinations = new List<Destination>();
            TourGuides = new List<TourGuide>();
        }
        public List <TravelAgency> TravelAgencies { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<TourGuide> TourGuides { get; set; }
    }
}
