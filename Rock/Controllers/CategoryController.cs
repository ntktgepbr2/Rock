using Microsoft.AspNetCore.Mvc;
using Rock.Data;
using Rock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }
        //Get-Create
        public IActionResult Create()
        {

            return View();
        }
        //Post-Create
        [HttpPost]//Defined this method as Post action method 
        [ValidateAntiForgeryToken]//security token
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)//if condition checks is all defined in Category(Model) rules are valid
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");//Redirect to Category Index}

            }
            return View(obj);
        }
        //Get-Edit
        public IActionResult Edit(int Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(Id);

            if (obj == null) return NotFound();


            return View(obj);
        }
        //Post-Edit

        [HttpPost]//Defined this method as Post action method 
        [ValidateAntiForgeryToken]//security token
        public IActionResult Edit(Category obj)//We need Id parametr in Category obj for Update method correct functioning.Update is looking for Category entities by Id.
        {
            if (ModelState.IsValid)//if condition checks is all defined in Category(Model) rules are valid
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");//Redirect to Category Index}

            }
            return View(obj);
        }

        //Get-Delete
        public IActionResult Delete(int Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(Id);

            if (obj == null) return NotFound();


            return View(obj);
        }
        //Post-Delete

        [HttpPost]//Defined this method as Post action method 
        [ValidateAntiForgeryToken]//security token
        public IActionResult DeletePost(int Id)//We need Id parametr in Category obj for Update method correct functioning.Update is looking for Category entities by Id.
        {
            var obj = _db.Category.Find(Id);
            {
                _db.Category.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");//Redirect to Category Index}

            }
          
        }
    }
}
