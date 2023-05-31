using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Admin
{
    public class StudentRegistrationModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public StudentRegistrationModel(SchoolManagementContext db)
        {
            _db = db;
        }


        public IEnumerable<StudentRegistration_Model> StudentRegistrationDatalist { get; set; }




        [BindProperty]
        public StudentRegistration Studentregistration { get; set; }


        public IActionResult OnGet(int? id)
        {


            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Admin)
            {
                return RedirectToPage("/Logout");
            }
            StudentRegistrationDatalist = _db.StudentRegistrations.Where(r => r.IsDeleted == false).Select(r => new StudentRegistration_Model
            {

                ID = r.Id,

                Name = r.Name,
                Address = r.Address,
                Email = r.Email,
                PhoneNumber = r.PhoneNumber,
                StudentUSN = r.StudentUsn,
                Gender = r.Gender,
                AadharCard = r.AadharCard
            }).ToList();


            Studentregistration = new StudentRegistration();
            if (id.HasValue)
            {
                var Reg = _db.StudentRegistrations.Where(r => r.Id == id && r.IsDeleted == false).FirstOrDefault();

                if (Reg == null)
                {
                    return NotFound();

                }
                Studentregistration = Reg;

            }

            return Page();
        }


        public IActionResult OnPost()
        {
            if (Studentregistration.Id > 0)
            {
                var reg = _db.StudentRegistrations.AsNoTracking().Where(r => r.Id == Studentregistration.Id && r.IsDeleted == false).FirstOrDefault();
                if (reg == null)
                {
                    return Page();

                }


                Studentregistration.IsDeleted = reg.IsDeleted;
                _db.StudentRegistrations.Update(Studentregistration);
                _db.SaveChanges();

                TempData["info"] = "Your Data update Successfully";
            }

            else
            {

                Studentregistration.IsDeleted = false;
                _db.StudentRegistrations.Add(Studentregistration);
                _db.SaveChanges();

                TempData["success"] = "data saved";



            }
            return RedirectToPage();
        }



        public IActionResult OnPostDelete(int? id)
        {
            var regg = _db.StudentRegistrations.Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefault();
            if (regg == null)
            {
                return NotFound();
            }
            regg.IsDeleted = true;

            _db.SaveChanges();
            TempData["success"] = "data deleted";
            return RedirectToPage();
        }



    }
}
