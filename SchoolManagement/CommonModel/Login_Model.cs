using System.ComponentModel.DataAnnotations;


namespace SchoolManagement.CommonModel
{
    public class Login_Model
    { 

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
