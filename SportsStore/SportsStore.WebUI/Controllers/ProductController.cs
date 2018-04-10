using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// my public object to access the IProductsRepository
        /// </summary>
        /// <returns></returns>
        /// 
        private IProductsRepository Repository;
        private int PageSize = 4;

        /// <summary>
        /// main contstructor
        /// implementing dependency indection for separations of concerns pattern of the MVC
        /// </summary>
        /// <returns></returns>
        /// 
        public ProductController()
        {
            foreach (IProductsRepository innerRepository in GlobalConfig.Connections)
            {
                this.Repository = innerRepository;
            }
        }


        //GET All 
        public ActionResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = Repository.Products
                .Where(p => p.Category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        Repository.Products.Count() :
                        Repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = Repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}