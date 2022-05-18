using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class StudentCurriculum
    {
        [Key]
        public int StudentCurriculumId { get; set; }

        // [ForeignKey("studentId")]
        // public Student Student { get; set; }

        // [ForeignKey("curriculumId")]
        // public Curriculum Curriculum { get; set; }
        
        // [ForeignKey("optionalId")]
        // public OptionalCourse OptionalCourse { get; set; }

        public int StudentId { get; set; }

        public int CurriculumId { get; set; }

        public int OptionalCourseId { get; set; }
    }
}