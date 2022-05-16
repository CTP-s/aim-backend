using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class StudentCurriculum
    {
        [ForeignKey("studentId")]
        public Student Student { get; set; }

        [ForeignKey("curriculumId")]
        public Curriculum Curriculum { get; set; }
        
        [ForeignKey("optionalId")]
        public Optional Optional { get; set; }
    }
}