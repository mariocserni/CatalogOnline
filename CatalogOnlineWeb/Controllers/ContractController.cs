using CatalogOnlineWeb.Data;
using CatalogOnlineWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogOnlineWeb.Controllers
{
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ContractController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SituatieScolara(int? id)
        {
            Console.WriteLine("LoogiC");
            Student student = _db.Studenti.Find(id);
            if(student == null) 
            {
                Console.WriteLine("LogiC1");
                return NotFound();
            }
            List<Disciplina> discipline = _db.Discipline.Where(d => d.An <= student.An).ToList();
            foreach(Disciplina disciplina in discipline) 
            {
                Console.WriteLine(disciplina.Titlu);
            }
            List<Contract> contracte = _db.Contracte.Where(c => c.StudentId == id).ToList();
            foreach (Contract disciplina in contracte)
            {
                Console.WriteLine(disciplina.StudentId);
            }
            if (!discipline.Any() || !contracte.Any())
			{
                Console.WriteLine("LogiC2");
                return NotFound();
			}

			SituatieScolaraViewModel SituatieScolara = new SituatieScolaraViewModel(student, contracte, discipline);
            
            return View(SituatieScolara);
        }

        public IActionResult AdaugaNote(int studentId)
        {
            var student = _db.Studenti.Find(studentId);
            if (student == null)
            {
                return NotFound();
            }
            List<Disciplina> discipline = _db.Discipline.Where(d => d.An <= student.An).ToList();
            List<Contract> contracte = _db.Contracte.Where(c => c.StudentId == studentId).ToList();
            var model = new SituatieScolaraViewModel(student, contracte, discipline);
            return View(model);
        }



        [HttpPost]
        public IActionResult AdaugaNote(int disciplinaId, int studentId, double NotaParcurs, double NotaPrezentarea1, double NotaPrezentarea2, double NotaPrezentarea3)
        {
            var contract = _db.Contracte.FirstOrDefault(c => c.StudentId == studentId && c.DisciplinaId == disciplinaId);

            if (contract != null)
            {
                contract.NotaParcurs = NotaParcurs;
                contract.NotaPrezentarea1 = NotaPrezentarea1;
                contract.NotaPrezentarea2 = NotaPrezentarea2;
                contract.NotaPrezentarea3 = NotaPrezentarea3;

                contract.Medie = (NotaParcurs + NotaPrezentarea1 + NotaPrezentarea2 + NotaPrezentarea3) / 4;

                _db.SaveChanges(); 
            }

            return RedirectToAction("SituatieScolara", new { id = studentId });
        }

        [HttpGet]
        public IActionResult GetNoteDisciplina(int studentId, int disciplinaId)
        {
            var contract = _db.Contracte.FirstOrDefault(c => c.StudentId == studentId && c.DisciplinaId == disciplinaId);
            if (contract == null)
            {
                return Json(new { success = false });
            }
            return Json(new
            {
                success = true,
                NotaParcurs = contract.NotaParcurs,
                NotaPrezentarea1 = contract.NotaPrezentarea1,
                NotaPrezentarea2 = contract.NotaPrezentarea2,
                NotaPrezentarea3 = contract.NotaPrezentarea3
            });
        }



    }
}
