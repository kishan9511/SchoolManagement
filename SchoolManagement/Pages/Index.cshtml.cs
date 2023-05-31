using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages
{
    public class IndexModel : PageModel 
    {
        private readonly SchoolManagementContext _db;



        [BindProperty]
        public Login_Model Login { get; set; }



        public IndexModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {

            Login = new Login_Model();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {

            if(ModelState.IsValid)
                {
                var registration = await _db.Registrations.Where(r => r.IsDeleted == false &&
                                 r.Email.Trim().ToLower() == Login.Email.Trim().ToLower() &&
                                     r.Password ==Login.Password).FirstOrDefaultAsync();

                if(registration != null) 
                
                {
                 int roleId = (int)registration.RoleId;
                    HttpContext.Session.SetInt32(SD.RoleId, roleId);
                    HttpContext.Session.SetInt32(SD.UserKey,registration.Id);


                if(roleId == SD.Admin)
                    {
                        return RedirectToPage("/Admin/Dashboard");
                    }
                

                if(roleId == SD.Teacher)
                    {
                        return RedirectToPage("/Teacher/SubjectTaken");
                    }
                

                if(roleId == SD.Student)
                    {
                        return RedirectToPage("/Student/AttendenceList");
                    }
                
               
                }

            }
            TempData["error"] = "Incorrect Password";
            return Page();
        }

    }
}