using System.ComponentModel.DataAnnotations.Schema;

namespace aim_backend.Models
{
    public class Admin : User
    {
        // public int FacultyId { get; set; }

        [ForeignKey("facultyId")]
        public Faculty Faculty { get; set; }
    }
}