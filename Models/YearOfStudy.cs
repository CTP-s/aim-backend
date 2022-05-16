using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class YearOfStudy
    {
        [Key]
        public int yearOfStudyId { get; set; }

        public int yearNumber { get; set; }

        [ForeignKey("studyLineId")]
        public StudyLine StudyLine { get; set; }
    }
}