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
    }
}
