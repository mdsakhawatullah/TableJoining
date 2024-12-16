
namespace InternshipTask.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter class name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter created date")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Please enter modified date")]
        public DateTime ModificationDate { get; set; }

    }
}
