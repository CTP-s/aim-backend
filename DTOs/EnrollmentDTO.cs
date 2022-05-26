namespace aim_backend.DTOs
{
    public class EnrollmentDTO
    {
        public int FacultyId { get; set; }

        public string FacultyName { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string StudyLineId { get; set; }

        public string StudyLineName { get; set; }

        public int YearOfStudyId { get; set; }

        public int Year { get; set; }
    }

    public class EnrollDto
    {
        public int StudentId { get; set; }

        public int YearOfStudyId { get; set; }
    }
}