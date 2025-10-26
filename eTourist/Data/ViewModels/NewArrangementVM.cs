using eTourist.Data.Base;
using eTourist.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTourist.Models
{
    public class NewArrangementVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Arrangement name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Arrangement description")]

        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Arrangement price in RSD")]

        public double Price { get; set; }

        [Required(ErrorMessage = "Arrangement poster URL is required")]
        [Display(Name = "Arrangement poster URL")]

        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [Display(Name = "Arrangement start date")]

        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [Display(Name = "Arrangement end date")]

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Arrangement category is required")]
        [Display(Name = "Select a category")]

        public ArrangementCategory ArrangementCategory { get; set; }


        [Required(ErrorMessage = "Tourguide is required")]
        [Display(Name = "Select tourguide(s)")]
        //Relationships
        public List<int> TourGuideIds { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        [Display(Name = "Select a destination")]
        //Destination
        public int DestinationId { get; set; }

        [Required(ErrorMessage = "Travel agency is required")]
        [Display(Name = "Select a travel agency")]
        //TravelAgency
        public int TravelAgencyId { get; set; }
    }
}
