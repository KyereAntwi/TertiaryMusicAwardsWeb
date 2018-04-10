using MusicAwardsWebApp.Models;
using System.Collections.Generic;

namespace MusicAwardsWebApp.ViewModels
{
    public class SummaryResultsViewModel
    {
        public int TotalVotes { get; set; }
        public IEnumerable<AwardCategory> Categories { get; set; }
    }
}
