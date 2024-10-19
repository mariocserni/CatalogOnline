using CatalogOnlineWeb.Data;
using CatalogOnlineWeb.Migrations;
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
        public IActionResult CreateStudent(Student student)
        {
            ModelState.Remove("Email");
            if (ModelState.IsValid)
            {
                student.Email = student.Prenume.Split(' ')[0].ToLower() + "." + student.Nume.ToLower() + "@student.upt.ro";
                if(student.An == null)
                {
                    student.An = 1;
                }
                _db.Studenti.Add(student);
                _db.SaveChanges();
				List<Disciplina> discipline = _db.Discipline.Where(d => d.An <= student.An).ToList();
				foreach(Disciplina disciplina in discipline)
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
                    _db.SaveChanges();
                }
				TempData["succes"] = "Contul a fost creat!";
                return RedirectToAction("Index");
            }
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
				foreach (var error in errors)
				{
					Console.WriteLine(error.ErrorMessage); // Sau folosește un debugger pentru a inspecta erorile
				}
				return View(student);
			}
			return View();
        }

		public IActionResult EditStudent(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var student = _db.Studenti.Find(id);
			if (student == null)
			{
				return NotFound();
			}
			return View(student);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditStudent(Student obj)
		{
			ModelState.Remove("Email");
			if (ModelState.IsValid)
			{
				obj.Email = obj.Prenume.Split(' ')[0].ToLower() + "." + obj.Nume.ToLower() + "@student.upt.ro";
				if (obj.An == null)
				{
					obj.An = 1;
				}
				_db.Studenti.Update(obj);
				_db.SaveChanges();
                TempData["succes"] = "Contul a fost modificat!";
                return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult DeleteStudent(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var student = _db.Studenti.Find(id);
			if (student == null)
			{
				return NotFound();
			}
			var contracte = _db.Contracte.Where(c => c.StudentId == id).ToList();
			foreach(Contract contract in contracte)
			{
				_db.Contracte.Remove(contract);
			}
            _db.Studenti.Remove(student);
            _db.SaveChanges();
            TempData["succes"] = "Contul a fost sters!";
            return RedirectToAction("Index");
        }

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public IActionResult DeleteStudent(Student obj)
		//{
		//	//ModelState.Remove("Email");
		//	//if (ModelState.IsValid)
		//	//{
		//	//	obj.Email = obj.Prenume.Split(' ')[0].ToLower() + "." + obj.Nume.ToLower() + "@student.upt.ro";
		//	//	if (obj.An == null)
		//	//	{
		//	//		obj.An = 1;
		//	//	}
		//	//	_db.Studenti.Update(obj);
		//	//	_db.SaveChanges();
		//	//	return RedirectToAction("Index");
		//	//}
		//	_db.Studenti.Remove(obj);
		//	_db.SaveChanges();
  //          return RedirectToAction("Index");
  //      }
	}
}


















































