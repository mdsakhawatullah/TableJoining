
namespace InternshipTask.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter student name")]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "Please select gender options")]
        public int Gender { get; set; }

        public DateTime DOB { get; set; }

        [BindNever]
        [ForeignKey("Class")]
        public int ClassId { get; set; }

        [Required(ErrorMessage = "Please enter create date")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Please enter modified date")]
        public DateTime ModificationDate { get; set; }

        [BindNever]
        public Class Class { get; set; }
    }
}
