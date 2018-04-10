using System.ComponentModel.DataAnnotations;

namespace MusicAwardsWebApp.Models
{
    public class CategoryNominees
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int NomineeId { get; set; }
        public virtual AwardCategory Category { get; set; }
        public virtual Nominee Nominee { get; set; }
    }
}
