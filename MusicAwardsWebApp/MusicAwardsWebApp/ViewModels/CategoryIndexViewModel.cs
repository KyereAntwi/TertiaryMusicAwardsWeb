using MusicAwardsWebApp.Models;
using System.Collections.Generic;

namespace MusicAwardsWebApp.ViewModels
{
    public class CategoryIndexViewModel
    {
        public IEnumerable<AwardCategory> AwardCategories { get; set; }
        public AddNewViewModel Vm { get; set; }
    }
}
