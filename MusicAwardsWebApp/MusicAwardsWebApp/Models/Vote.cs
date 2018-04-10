using System.ComponentModel.DataAnnotations;

namespace MusicAwardsWebApp.Models
{
    public class Vote
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int NomineeId { get; set; }

        [Required]
        public string PhoneIPAdress { get; set; }
        public virtual AwardCategory Category { get; set; }
        public virtual Nominee Nominee { get; set; }
    }
}
