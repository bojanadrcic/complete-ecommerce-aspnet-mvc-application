using eTourist.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTourist.Models
{
    public class TravelAgency: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display (Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "FullName")]
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }

        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }

        [ValidateNever]
        //Relationships
        public List <Arrangement> Arrangements { get; set; }
       //public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
