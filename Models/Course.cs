using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        
        public string CourseName { get; set; }

        public int TeacherId { get; set; }
    }
}