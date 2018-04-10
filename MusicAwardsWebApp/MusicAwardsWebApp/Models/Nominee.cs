using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicAwardsWebApp.Models
{
    public class Nominee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Stage Name")]
        public string StageName { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "School")]
        public string School { get; set; }
        public byte[] Image { get; set; }
        public string ImageMime { get; set; }
        public virtual List<Vote> Votes { get; set; }
        public virtual List<CategoryNominees> Categories { get; set; }
    }
}
