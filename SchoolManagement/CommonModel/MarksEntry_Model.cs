namespace SchoolManagement.CommonModel
{
    public class MarksEntry_Model
    {


        public int? ID { get; set; }

        public int? StudentDetailsID { get; set; }
        public int? SubjectID { get; set; }
        public int? MarksID { get; set; }
        public int? ExamID { get; set; }
        public string? NameDropdown { get; set; }
        public string? SubjectNameDropdown { get; set; }
        public string? Marks { get; set; }
        public string? TotalMarks { get; set; }
        public string? PassingMarks { get; set; }
    }
}
