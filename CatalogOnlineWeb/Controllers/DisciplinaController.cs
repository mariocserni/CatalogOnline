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
                List<Student> studenti = _db.Studenti.Where(s => s.An >= disciplina.An).ToList();
                foreach(Student student in studenti)
                {
                    Contract contract = new Contract {
                        StudentId = student.StudentId,
                        DisciplinaId = disciplina.DisciplinaId,
                        NotaPrezentarea1 = 0,
                        NotaPrezentarea2 = 0,
                        NotaPrezentarea3 = 0,
                        NotaParcurs = 0,
                        Medie = 0
                    };
					_db.Contracte.Add(contract);
				}
                TempData["succes"] = "Disciplina a fost creata!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult EditSubject(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var subject = _db.Discipline.Find(id);
            if(subject == null) 
            {
                return NotFound();
            }
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSubject(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                _db.Discipline.Update(disciplina);
                _db.SaveChanges();
                TempData["succes"] = "Disciplina a fost modificata!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteSubject(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var subject = _db.Discipline.Find(id);
            if (subject == null)
            {
                return NotFound();
            }
            var contracte = _db.Contracte.Where(c => c.DisciplinaId == id);
            foreach(Contract contract in contracte) 
            {
                _db.Contracte.Remove(contract);
            }
            _db.Discipline.Remove(subject);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
