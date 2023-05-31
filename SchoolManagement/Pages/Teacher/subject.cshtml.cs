using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Teacher
{
    public class subjectModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public subjectModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IEnumerable<Subject> SubjectDatalist { get; set; }

        [BindProperty]
        public Subject subject { get; set; }

        public IActionResult OnGet(int? id)
        {

            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Teacher)
            {
                return RedirectToPage("/Logout");
            }



            SubjectDatalist = _db.Subjects.Where(s => s.IsDeleted == false).ToList();
            if(id.HasValue)
            {
                var subjects = _db.Subjects.Where(s => s.Id == id && s.IsDeleted == false).FirstOrDefault();
                if(subjects== null)
                {
                    return Page();
                }
                subject = subjects;
                return Page();
            }
            subject = new Subject();
            return Page();
            
        }
        public IActionResult OnPost()
        {

            if(subject.Id>0)
            {
                var subjects = _db.Subjects.AsNoTracking().Where(s => s.Id == subject.Id && s.IsDeleted == false).FirstOrDefault();

                if(subjects == null)
                {
                    return Page();
                }
                subject.IsDeleted = subjects.IsDeleted;
                _db.Subjects.Update(subject);
                _db.SaveChanges();
                TempData["info"] = "Your Data update Successfully";
            }
            else
            {
                subject.IsDeleted = false;
                _db.Subjects.Add(subject);
                _db.SaveChanges();
                TempData["success"] = "data saved";
            }

            return RedirectToPage();
        }


        public IActionResult OnPostDelete(int? id)
        {
            var subjects = _db.Subjects.Where(s => s.IsDeleted == false).FirstOrDefault();
            if(subjects == null)
            {
                return Page();
            }
            subject.IsDeleted = true;
            _db.SaveChanges();

            TempData["success"] = "data deleted";
            return RedirectToPage();
        }




    }
}
