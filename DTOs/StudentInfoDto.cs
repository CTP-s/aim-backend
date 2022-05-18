namespace aim_backend.DTOs
{
    public class StudentInfoDto
    {
        public int StudentId { get; set; }

        public int YearOfStudyId { get; set; }
        
        public int YearNumber { get; set; }

        public int StudyLineId { get; set; }

        public string StudyLineName { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int FacultyId { get; set; }

        public string FacultyName { get; set; }

    }
}