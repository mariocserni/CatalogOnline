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
    }
}
