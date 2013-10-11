using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.Filters;

namespace SportsStore.WebUI.Controllers {
    public class ProductController : Controller {
        //
        // GET: /Product/

        private IProductRepository repository;
        public int PageSize = 3;

        public ProductController(IProductRepository productRepository) {
            this.repository = productRepository;
        }

        [CustomAuth(true)]
        public ViewResult List(string category, int page = 1) {

            ProductsListViewModel viewModel = new ProductsListViewModel();
            viewModel.Products = repository.Products.Where(p => category == null || p.Category == category)
                                                .OrderBy(p => p.ProductID)
                                                .Skip((page - 1) * PageSize)
                                                .Take(PageSize);
            viewModel.PagingInfo = new PagingInfo {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Category == category).Count()
            };

            viewModel.CurrentCategory = category;

            return View(viewModel);
        }

        public FileContentResult GetImage(int productId) {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if(prod != null) {
                return File(prod.ImageData, prod.ImageMimeType);
            } else {
                return null;
            }
        }

        [RangeException]
        public string RangeTest(int id) {
            if(id > 100) {
                return String.Format("The id value is: {0}", id);
            } else {
                throw new ArgumentOutOfRangeException("id", id, "");
            }
        }

        [SimpleMessage(Message = "A", Order=1)]
        [CustomAction(Order=2)] // para testar apenas a ação não existir
        public string TestFilter() {
            return "This is the Customer controller";
        }

    }
}
