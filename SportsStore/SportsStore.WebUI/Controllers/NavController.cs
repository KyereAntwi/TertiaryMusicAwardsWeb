using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository Repository;

        public NavController()
        {
            foreach (IProductsRepository innerRepository in GlobalConfig.Connections)
            {
                this.Repository = innerRepository;
            }
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<String> categories = Repository.Products
                                    .Select(x => x.Category)
                                    .Distinct()
                                    .OrderBy(x => x);
            
            return PartialView("FlexMenu", categories);
        }
    }
}