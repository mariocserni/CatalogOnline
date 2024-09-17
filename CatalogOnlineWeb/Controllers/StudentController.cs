using CatalogOnlineWeb.Data;
using CatalogOnlineWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CatalogOnlineWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;       
        }

        public IActionResult Index()
        {
            var objStudentList = _db.Studenti.ToList();
            return View(objStudentList);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudent(Student obj)
        {
            if (ModelState.IsValid)
            {
                obj.Email = obj.Prenume.Split(' ')[0].ToLower() + "." + obj.Nume.ToLower() + "@student.upt.ro";
                _db.Studenti.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
