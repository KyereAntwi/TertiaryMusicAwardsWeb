using MusicAwardsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAwardsWebApp.Repository
{
    public interface IServices
    {
        IEnumerable<AwardCategory> GetCategories();
        AwardCategory GetCategory(int Id);
        IEnumerable<Nominee> GetNominees();
        Nominee GetNominee(int Id);
        IEnumerable<Vote> GetVotes();
        bool AddVote(Vote model);
        bool AddNomineeToCategory(int catId, int nomId);
        IEnumerable<CategoryNominees> GetCategoryNominees(int id);
        AwardCategory SaveCategory(AwardCategory model);
        Nominee SaveNominee(Nominee model);
        bool DeleteCategory(int Id);
        bool DeleteNominee(int Id);
        bool RemoveNomineeFromCategory(int catId, int nomId);
        Dictionary<Nominee, int> Results(int categoryId);
        IEnumerable<Gallery> GetAllGallery();
        Gallery GetGallery(int id);
        Gallery AddGallery(Gallery model);
        bool DeleteGallery(int Id);
        //empty database

    }
}
