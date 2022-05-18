using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class StudyLine
    {
        [Key]
        public int studyLineId { get; set; }

        public string studyLineName { get; set; }

        // [ForeignKey("departmentId")]
        // public Department Department { get; set; }

        public int DepartmentId { get; set; }

    }
}