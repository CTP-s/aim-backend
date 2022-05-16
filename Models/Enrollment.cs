using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class Enrollment
    {
        [ForeignKey("studentId")]
        public Student Student { get; set; }

        [ForeignKey("yearOfStudyId")]
        public YearOfStudy yearOfStudy { get; set; }
    }
}