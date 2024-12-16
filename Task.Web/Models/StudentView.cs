
namespace InternshipTask.Models
{
    public class StudentView
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter student name")]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "Please select a gender")]
        public int Gender { get; set; } 

        [Required(ErrorMessage = "Please select a date of birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please select a class")]
        public int ClassId { get; set; }

        public IEnumerable<SelectListItem>? ClassList { get; set; }

        public string? ClassName { get; set; }

        //public DateTime CreatedDate { get; set; }
        //public DateTime ModificationDate { get; set; }
    }
}
