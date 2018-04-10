using System.ComponentModel.DataAnnotations;

namespace MusicAwardsWebApp.ViewModels
{
    public class AddNewNomineeViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Characters must be between 2 and 15")]
        [Display(Name = "Stage Name")]
        public string StageName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(1, ErrorMessage = "Characters must be 1, (M for Male and F for Female")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Characters must be between 2 and 100")]
        [Display(Name = "School Attending")]
        public string School { get; set; }
    }
}
