namespace CatalogOnlineWeb.Models
{
	public class SituatieScolaraViewModel
	{
        public Student Student { get; set; }
        public List<Contract> Contracte { get; set; }
        public List<Disciplina> Discipline { get; set; }
        public SituatieScolaraViewModel(Student student, List<Contract> contracte, List<Disciplina> discipline)
        {
            Student = student;
            Contracte = contracte;
            Discipline = discipline;
        }
    }
}
