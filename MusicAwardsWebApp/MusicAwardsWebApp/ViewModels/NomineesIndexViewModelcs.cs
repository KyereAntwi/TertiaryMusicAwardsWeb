using MusicAwardsWebApp.Models;
using System.Collections.Generic;

namespace MusicAwardsWebApp.ViewModels
{
    public class NomineesIndexViewModelcs
    {
        public IEnumerable<Nominee> AllNominees { get; set; }
        public AddNewNomineeViewModel AddNominee { get; set; }
    }
}
