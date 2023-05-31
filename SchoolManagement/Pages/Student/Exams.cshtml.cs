using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Student
{
    public class ExamsModel : PageModel
    {



        public readonly SchoolManagementContext _db;
        public ExamsModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IEnumerable<Exam> ExamDatalist { get; set; }

        [BindProperty]
        public Exam exam { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Student)
            {
                return RedirectToPage("/Logout");
            }

            ExamDatalist = _db.Exams.Where(e => e.IsDeleted == false).ToList();
            if (id.HasValue)
            {
                var examm = _db.Exams.Where(e => e.Id == id && e.IsDeleted == false).FirstOrDefault();
                if (examm == null)
                {
                    return Page();

                }

                exam = examm;
                return Page();
            }
            exam = new Exam();

            return Page();
        }

        public IActionResult OnPost()
        {

            if (exam.Id > 0)

            {
                var eexam = _db.Exams.AsNoTracking().Where(e => e.Id == exam.Id && e.IsDeleted == false).FirstOrDefault();
                if (eexam == null)
                {
                    return Page();
                }
                exam.IsDeleted = eexam.IsDeleted;
                _db.Exams.Update(exam);
                _db.SaveChanges();
                TempData["info"] = "Your Data update Successfully";

            }
            else
            {

                exam.IsDeleted = false;
                _db.Exams.Update(exam);
                _db.SaveChanges();
                TempData["success"] = "data saved";
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int? id)
        {


            var Ex = _db.Exams.Where(e => e.Id == id && e.IsDeleted == false).FirstOrDefault();
            if (Ex == null)
            {
                return Page();
            }
            Ex.IsDeleted = true;
            _db.SaveChanges();

            TempData["success"] = "data deleted";
            return RedirectToPage();
        }


    }
}
