using MusicAwardsWebApp.Models;
using System.Collections.Generic;

namespace MusicAwardsWebApp.ViewModels
{
    public class AddNomineesToCategoryViewModel
    {
        public AwardCategory Category { get; set; }
        public IEnumerable<Nominee> Nominees { get; set; }
        public IEnumerable<Nominee> CatNominees { get; set; }
    }
}
