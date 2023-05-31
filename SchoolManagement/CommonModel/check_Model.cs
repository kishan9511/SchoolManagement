using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.CommonModel
{
    public class check_Model
    {
    public int? Id { get; set; }
        public int? markID { get; set; } 
        public int? ResultID { get; set; } 
        public string? USNDropdown { get; set; } 
        public string? NameDropdown { get; set; } 
        public string? Marks { get; set; } 
        public string? Result { get; set; } 
        
    }
}
 