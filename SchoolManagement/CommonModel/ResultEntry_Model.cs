namespace SchoolManagement.CommonModel
{
    public class ResultEntry_Model
    {
        public int? ID { get; set; }

        public int? StudentDetailsID { get; set; }
        public int? SubjectID { get; set; }
        public int? StudentRegistrationID { get; set; }
        public int? MarksID { get; set; }
        public int? ExamID { get; set; }

     
        public string? NameDropdown { get; set; }
        public string? SubjectNameDropdown { get; set; }
        public string? USNDropdown { get; set; }
        public string?  MarksDropdown { get; set; }
        public string? Result  { get; set; }
        public string? TotalMarks { get; set; }
        public string? PassingMarks { get; set; }



    }
}
