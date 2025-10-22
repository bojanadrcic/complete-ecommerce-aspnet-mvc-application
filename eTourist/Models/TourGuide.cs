using eTourist.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace eTourist.Models

    
{
    public class TourGuide: IEntityBase
    {
        [Key] 
        public int Id { get; set; }

        [Display (Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Full name must be between 3 and 50 characters")]
        public string FullName { get; set; }

        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }

        //Relationships 
        [ValidateNever]
        public List <TourGuide_Arrangement> TourGuides_Arrangements { get; set; }
        //public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
