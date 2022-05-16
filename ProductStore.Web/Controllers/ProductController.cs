using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductStore.Domain.Entities;
using ProductStore.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Web.Controllers
{
    public class ProductController : Controller
    {
      
        // GET: ProductController
        readonly IProductService productService;
        readonly ICategoryService categoryService;
        public ProductController(IProductService productService, 
            ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public ActionResult Index(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
                return View(productService.GetMany(p => p.Name.Contains(filter)));
            //else
            return View(productService.GetAll());
        }

        public ActionResult ListProduits()
        {
            return View (productService.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(productService.GetById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var myCategories = categoryService.GetAll();
            ViewBag.CategoryList = new SelectList(myCategories,"CategoryId","Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, IFormFile file)
        {

            product.ImageURL2 = file.FileName; // permet 
            productService.Add(product);
            productService.Commit();

            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                file.FileName);
                using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }


            return RedirectToAction("Index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = productService.GetById(id);

            ViewBag.CategoryList = new SelectList(categoryService.GetAll(), "CategoryId", "Name");
            return View(p);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product productEdit, IFormFile file)
        {
            // Product p = productService.GetById(id) ;

            if (file != null)
            {
                productEdit.ImageURL2 = file.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
               file.FileName);
                using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            productService.Update(productEdit);
            productService.Commit();
            return RedirectToAction(nameof(Index));

        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product p = productService.GetById(id);
            return View(p);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {

            productService.Delete(productService.GetById(id));
            return RedirectToAction("ListProduits");
            
        }
       
    }
}
