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

    public class OptionalCourseProposedDto
    {
        public string CourseName { get; set; }

        public int CourseSemester { get; set; }

        public int TeacherId { get; set; }
    }

    public class OptionalCourseApproveDto
    {
        public int CourseId { get; set; }

        public int Approved = 1;
    }
}