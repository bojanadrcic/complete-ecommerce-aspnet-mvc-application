namespace eTourist.Models
{
    public class TourGuide_Arrangement
    {
        public int ArrangementId { get; set; }
        public Arrangement Arrangement { get; set; }
        public int TourGuideId { get; set; }
        public TourGuide TourGuide { get; set; }
    }
}
