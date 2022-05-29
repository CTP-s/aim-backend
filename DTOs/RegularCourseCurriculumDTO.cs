namespace aim_backend.DTOs
{
    public class RegularCourseCurriculumDTO
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int Semester { get; set; }

        public string LecturerFirstName { get; set; }

        public string LecturerLastName { get; set; }
    }
}