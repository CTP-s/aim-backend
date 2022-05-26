using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class StudentCurriculum
    {
        [Key]
        public int StudentCurriculumId { get; set; }

        public int StudentId { get; set; }

        public int CurriculumId { get; set; }

        public int OptionalCourseId { get; set; }
    }
}