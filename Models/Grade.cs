using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        // [ForeignKey("studentId")]
        // public Student Student { get; set; }

        // [ForeignKey("courseId")]
        // public Course Course { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public int Value { get; set; }
    }
}