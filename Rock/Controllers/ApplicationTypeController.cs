using Microsoft.AspNetCore.Mvc;
using Rock.Data;
using Rock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
           System.Diagnostics.Debug.WriteLine(_db);
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
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
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)//if condition checks is all defined in ApplicationType(Model) rules are valid

            _db.ApplicationType.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");//Redirect to ApplicationType Index
        }
        //Get-Edit
        public IActionResult Edit(int Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.ApplicationType.Find(Id);

            if (obj == null) return NotFound();


            return View(obj);
        }
        //Post-Edit

        [HttpPost]//Defined this method as Post action method 
        [ValidateAntiForgeryToken]//security token
        public IActionResult Edit(ApplicationType obj)//We need Id parametr in Category obj for Update method correct functioning.Update is looking for Category entities by Id.
        {
            if (ModelState.IsValid)//if condition checks is all defined in Category(Model) rules are valid
            {
                _db.ApplicationType.Update(obj);
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
            var obj = _db.ApplicationType.Find(Id);

            if (obj == null) return NotFound();


            return View(obj);
        }
        //Post-Delete

        [HttpPost]//Defined this method as Post action method 
        [ValidateAntiForgeryToken]//security token
        public IActionResult DeleteApplication(int Id)//We need Id parametr in Category obj for Update method correct functioning.Update is looking for Category entities by Id.
        {
            var obj = _db.ApplicationType.Find(Id);
            {
                _db.ApplicationType.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");//Redirect to Category Index}

            }

        }
    }
}
