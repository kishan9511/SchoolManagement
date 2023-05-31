using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Student
{
    public class leaveModel : PageModel
    {

        public readonly SchoolManagementContext _db;
        public leaveModel(SchoolManagementContext db)
        {
            _db = db;
        }
        public IEnumerable<leave_Model> leaveDatalist { get; set; }



        [BindProperty]
        public Leave leave { get; set; }


        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Student)
            {
                return RedirectToPage("/Logout");
            }
            leaveDatalist = _db.Leaves.Where(r => r.Isdeleted == false).Select(r => new leave_Model
            {
                ID = r.Id,
                StudentDetailsID = r.StudentDetailId,

                USNDropdown = r.Usn,
                NameDropdown = r.Name,
                Reason = r.Reason
            }).ToList();
            leave = new Leave();

            if (id.HasValue)
            {
                var Lev = _db.Leaves.Where(r => r.Id == id && r.Isdeleted == false).FirstOrDefault();
                if (Lev == null)
                {
                    return Page();
                }
                leave = Lev;

            }




            return Page();
        }


        public IActionResult OnPost()
        {
            if (leave.Id > 0)
            {
                var Lev = _db.Leaves.AsNoTracking().Where(r => r.Id == leave.Id && r.Isdeleted == false).FirstOrDefault();
                if (Lev == null)
                {
                    return Page();
                }

              
                leave.Isdeleted = Lev.Isdeleted;
                _db.Leaves.Update(leave);
                _db.SaveChanges();

               


            }

            else
            {
           
                leave.Isdeleted = false;
                _db.Leaves.Add(leave);
                _db.SaveChanges();

                TempData["success"] = "Your Application Has Been Submitted";

            }

            return RedirectToPage();

        }

        public IActionResult OnPostDelete(int? id)

        {

            var Lev = _db.Leaves.Where(t => t.Id == id && t.Isdeleted == false).FirstOrDefault();
            if (Lev == null)
            {
                return NotFound();
            }

            Lev.Isdeleted = true;
            _db.SaveChanges();

          
            return RedirectToPage();
        }



    }
}
