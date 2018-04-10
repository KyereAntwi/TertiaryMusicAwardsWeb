using System.ComponentModel.DataAnnotations;

namespace MusicAwardsWebApp.ViewModels
{
    public class AddNewViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This feild is required")]
        [StringLength(100, ErrorMessage = "Must be between 2 to 100 characters long")]
        [Display(Name = "Category Title")]
        public string Category { get; set; }

        [Required(ErrorMessage = "This feild is required")]
        [StringLength(300, ErrorMessage = "Must be between 2 to 300 characters long")]
        [Display(Name = "Category Description")]
        public string Description { get; set; }
    }
}
