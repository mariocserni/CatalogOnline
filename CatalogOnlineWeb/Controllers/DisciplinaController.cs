using CatalogOnlineWeb.Data;
using CatalogOnlineWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOnlineWeb.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DisciplinaController(ApplicationDbContext db)
        {
            _db = db;    
        }

        public IActionResult Index()
        {
            var objSubjectsList = _db.Discipline.ToList();
            return View(objSubjectsList);
        }

        public IActionResult CreateSubject()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSubject(Disciplina disciplina)
        {
            if(ModelState.IsValid) 
            {
                _db.Discipline.Add(disciplina);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
