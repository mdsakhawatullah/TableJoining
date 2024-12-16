using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Model
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
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "Please enter modified date")]
        public DateTime ModifyDate { get; set; }

        [BindNever]
        public Class Class { get; set; }
    }
}
