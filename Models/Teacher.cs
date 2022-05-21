namespace aim_backend.Models
{
    public class Teacher : User
    {
        public int FirstOptionalCourseId { get; set; }

        public int SecondOptionalCourseId { get; set; }

        public int DepartmentId { get; set; }
    }
}