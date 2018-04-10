using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicAwardsWebApp.Models
{
    public class AwardCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Award Category")]
        public string Category { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public virtual List<Vote> Votes { get; set; }
        public virtual List<CategoryNominees> Nominees { get; set; }
    }
}
