using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreCrud.Models
{
    public class Faculty
    {
        public int ID { get; set; }
        public string FacultyName { get; set; }
        public string PhoneNumber { get; set; }
        public string CourseName { get; set; }
        [DataType(DataType.Date)]
        public DateTime CourseStartDate { get; set; }
        [NotMapped]
        
        public IFormFile Picture { get; set; }
        [ValidateNever]
        public string PicPath { get; set; }
        // public virtual ICollection<Student> Students { get; set; }
    }
}
