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
            ModelState.Remove("Email");
            if (ModelState.IsValid)
            {
                obj.Email = obj.Prenume.Split(' ')[0].ToLower() + "." + obj.Nume.ToLower() + "@student.upt.ro";
                if(obj.An == null)
                {
                    obj.An = 1;
                }
                _db.Studenti.Add(obj);
                _db.SaveChanges();
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
				return View(obj);
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


















































