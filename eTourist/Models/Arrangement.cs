using eTourist.Data.Base;
using eTourist.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTourist.Models
{
    public class Arrangement: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]

        public string Name { get; set; }

        [Display(Name = "Description")]

        public string Description { get; set; }

        [Display(Name = "Price")]

        public double Price { get; set; }

        [Display(Name = "Image")]

        public string ImageURL { get; set; }

        [Display(Name = "StartDate")]

        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate")]

        public DateTime EndDate { get; set; }

        [Display(Name = "ArrangementCategory")]

        public ArrangementCategory ArrangementCategory { get; set; }

        //Relationships
        public List<TourGuide_Arrangement> TourGuides_Arrangements { get; set; }

        //Destination
        public int DestinationId { get; set; }
        [ForeignKey("DestinationId")]
        public Destination Destination { get; set; }

        //TravelAgency
        public int TravelAgencyId { get; set; }
        [ForeignKey("TravelAgencyId")]
        public TravelAgency TravelAgency { get; set; }
    }
}
