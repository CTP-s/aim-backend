using System.ComponentModel.DataAnnotations;

namespace aim_backend.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int TeacherId { get; set; }
        
        public int Semester { get; set; }
    }
}