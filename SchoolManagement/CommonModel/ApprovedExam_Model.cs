namespace SchoolManagement.CommonModel
{
    public class ApprovedExam_Model
    {
        public int? ID { get; set; }
        public int? RoleID { get; set; }
        public int? SubjectID { get; set; }
        public int? TeacherDetailID { get; set; }
        public int? SubjectTakenID { get; set; }


        public string? NameDropdown { get; set; }
        public string? EmailDropdown { get; set; }
        public string? PhoneDropdown { get; set; }
        public string? RoleDropdown { get; set; }


        public string? SubjectDropdown { get; set; }
        public string? ExamHallNumber { get; set;}




    }
}
