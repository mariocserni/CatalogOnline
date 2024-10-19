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
            Student student = _db.Studenti.Find(id);
            if(student == null) 
            {
                return NotFound();
            }
            List<Disciplina> discipline = _db.Discipline.Where(d => d.An <= student.An).ToList();
            List<Contract> contracte = _db.Contracte.Where(c => c.StudentId == id).ToList();
			if (!discipline.Any() || !contracte.Any())
			{
				return NotFound();
			}

			SituatieScolaraViewModel SituatieScolara = new SituatieScolaraViewModel(student, contracte, discipline);
            return View(SituatieScolara);
        }
    }
}
