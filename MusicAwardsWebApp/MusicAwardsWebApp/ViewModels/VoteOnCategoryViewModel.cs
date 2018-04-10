using MusicAwardsWebApp.Models;
using System.Collections.Generic;

namespace MusicAwardsWebApp.ViewModels
{
    public class VoteOnCategoryViewModel
    {
        public IEnumerable<Nominee> Nominees { get; set; }
        public AwardCategory Category { get; set; }
    }
}
