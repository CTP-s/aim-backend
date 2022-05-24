namespace aim_backend.DTOs
{
    public class OptionalCourseDTO
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int CourseSemester { get; set; }

        public string LecturerFirstName { get; set; }

        public string LecturerLastName { get; set; }

        public int? MaxNumberStudents { get; set; }
    }
}