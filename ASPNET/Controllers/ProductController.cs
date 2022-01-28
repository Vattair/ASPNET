using ASPNET.Data;
using ASPNET.Models;
using ASPNET.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ASPNETContext _db;

        public ProductController(ASPNETContext db)
        {
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Product> objList = _db.Products;

            foreach(var obj in objList)
            {
                obj.ProductType = _db.ProductTypes.FirstOrDefault(u => u.Id == obj.ProductTypeId);
            }

            return View(objList);
            
        }

        // GET-Create
        [Authorize]
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown = _db.ProductTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});

            //ViewBag.TypeDropDown = TypeDropDown;

            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                TypeDropDown = _db.ProductTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(productVM);
        }

        // POST-Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVM obj)
        {
            if (ModelState.IsValid)
            {
                //obj.ExpenseTypeId = 1;
                _db.Products.Add(obj.Product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
           
        }


        // GET Delete
        [Authorize]
        public IActionResult Delete(int? id)
        {
           
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Products.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST Delete
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Products.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
           
            _db.Products.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET Update
        [Authorize]
        public IActionResult Update(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                TypeDropDown = _db.ProductTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }
            productVM.Product = _db.Products.Find(id);
            if (productVM.Product == null)
            {
                return NotFound();
            }
            return View(productVM);

        }

        // POST UPDATE
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ProductVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj.Product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
