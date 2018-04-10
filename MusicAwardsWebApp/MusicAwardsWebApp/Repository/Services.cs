using Microsoft.EntityFrameworkCore;
using MusicAwardsWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicAwardsWebApp.Repository
{
    public class Services : IServices
    {
        private DataContext Context;

        public Services(DataContext _dataContext)
        {
            this.Context = _dataContext;
        }

        // add a galery
        public Gallery AddGallery(Gallery model)
        {
            Context.Galleries.Add(model);
            Context.SaveChanges();
            return model;
        }

        // add a nominee to a category
        public bool AddNomineeToCategory(int catId, int nomId)
        {
            var model = new CategoryNominees()
            {
                CategoryId = catId,
                NomineeId = nomId
            };

            var category = Context.AwardCategories.Find(catId);
            var nominee = Context.Nominees.Find(nomId);

            if (category != null && nominee != null)
            {
                Context.CategoryNominees.Add(model);
                Context.SaveChanges();
                return true;
            }

            return false;
        }

        // add a vote perform voting
        public bool AddVote(Vote model)
        {
            var votes = Context.Votes.Where(v => v.CategoryId == model.CategoryId && v.PhoneIPAdress == model.PhoneIPAdress).FirstOrDefault();
            if (votes != null) return false;
            var categoryNomiees = Context.CategoryNominees.Where(c => c.CategoryId == model.CategoryId);
            var nominee = Context.Nominees.Find(model.NomineeId);

            List<Nominee> nomineeList = new List<Nominee>();
            foreach (var cn in categoryNomiees)
            {
                nomineeList.Add(cn.Nominee);
            }

            if (nomineeList.Contains(nominee))
            {
                Context.Votes.Add(model);
                Context.SaveChanges();
                return true;
            }

            return false;
        }

        // delete category
        public bool DeleteCategory(int Id)
        {
            var category = Context.AwardCategories.Find(Id);
            if (category != null)
            {
                Context.AwardCategories.Remove(category);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        // delete galerry
        public bool DeleteGallery(int Id)
        {
            var gallery = Context.Galleries.Find(Id);
            if (gallery == null) return false;
            Context.Galleries.Remove(gallery);
            Context.SaveChanges();
            return true;
        }

        // dlete a nominee
        public bool DeleteNominee(int Id)
        {
            var nominee = Context.Nominees.Find(Id);
            if (nominee != null)
            {
                Context.Nominees.Remove(nominee);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        // get all gallery
        public IEnumerable<Gallery> GetAllGallery()
        {
            return Context.Galleries;
        }

        // get all categories
        public IEnumerable<AwardCategory> GetCategories()
        {
            return Context.AwardCategories
                .Include(c => c.Nominees)
                .Include(c => c.Votes);
        }

        // get a particular category
        public AwardCategory GetCategory(int Id)
        {
            return Context.AwardCategories
                .Include(c => c.Nominees)
                .Include(c => c.Votes)
                .FirstOrDefault(c => c.Id == Id);
        }

        // get the nominees of a category
        public IEnumerable<CategoryNominees> GetCategoryNominees(int id)
        {
            return Context.CategoryNominees
                .Include(c => c.Category)
                .Include(c => c.Nominee)
                .Where(c => c.CategoryId == id);
        }

        // get a particular gallery
        public Gallery GetGallery(int id)
        {
            return Context.Galleries.Find(id);
        }

        // get a nominee
        public Nominee GetNominee(int Id)
        {
            return Context.Nominees
                .Include(n => n.Votes)
                .Include(n => n.Categories)
                .FirstOrDefault(n => n.Id == Id);
        }

        // get all nominees
        public IEnumerable<Nominee> GetNominees()
        {
            return Context.Nominees
                .Include(n => n.Votes)
                .Include(n => n.Categories);
        }

        // get all votes
        public IEnumerable<Vote> GetVotes()
        {
            return Context.Votes
                .Include(v => v.Nominee)
                .Include(v => v.Category);
        }

        // remove a nominee from a category
        public bool RemoveNomineeFromCategory(int catId, int nomId)
        {
            var item = Context.CategoryNominees.Where(i => i.CategoryId == catId && i.NomineeId == nomId).First();

            if (item == null) return false;
            Context.CategoryNominees.Remove(item);
            Context.SaveChanges();
            return true;
        }

        // get the result of nominees for a category
        public Dictionary<Nominee, int> Results(int categoryId)
        {
            var category = GetCategory(categoryId);
            var votes = GetVotes().Where(v => v.CategoryId == category.Id);

            Dictionary<Nominee, int> keyValuePairs = new Dictionary<Nominee, int>();

            foreach (var vote in votes)
            {
                keyValuePairs.Add(vote.Nominee, vote.Nominee.Votes.Where(v => v.CategoryId == categoryId).Count());
            }

            return keyValuePairs;
        }

        // save a category
        public AwardCategory SaveCategory(AwardCategory model)
        {
            if (model.Id == 0)
            {
                Context.AwardCategories.Add(model);
            }
            else if (model.Id > 0)
            {
                // do the updating
            }

            Context.SaveChanges();
            return model;
        }

        // save a nominee
        public Nominee SaveNominee(Nominee model)
        {
            if (model.Id == 0)
                Context.Nominees.Add(model);
            else if (model.Id > 0)
            {
                // do the updating
            }

            Context.SaveChanges();
            return model;
        }
    }
}
