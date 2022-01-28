using ASPNET.Data;
using ASPNET.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : Controller
    {
        private readonly ASPNETContext _db;

        public ProductTypeController(ASPNETContext db)
        {
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<ProductType> objList = _db.ProductTypes;
            return View(objList);

        }

        // GET-Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST-Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        // GET Delete
        [Authorize]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ProductTypes.Find(id);
            if (obj == null)
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
            var obj = _db.ProductTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.ProductTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET Update
        [Authorize]
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ProductTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST UPDATE
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ProductType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
