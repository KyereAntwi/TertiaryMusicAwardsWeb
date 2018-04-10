using MusicAwardsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAwardsWebApp.ViewModels
{
    public class CategoryResultViewModel
    {
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Dictionary<Nominee, int> votes { get; set; }
    }
}
