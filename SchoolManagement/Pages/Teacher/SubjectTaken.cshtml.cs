using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Teacher
{
    public class SubjectTakenModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public SubjectTakenModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IEnumerable<SubjectTaken_Model> subjectTakenDatalist { get; set; }

        [BindProperty]
        public SubjectTakenByTeacher SubjectTaken { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Teacher)
            {
                return RedirectToPage("/Logout");
            }


            subjectTakenDatalist = _db.SubjectTakenByTeachers.Where(s => s.IsDeleted == false).Select(s => new SubjectTaken_Model
            {
                ID = s.Id,

                TeacherDetailID = s.TeacherDetailsId,
                NameDropdown = s.TeacherDetails.Name,
                SubjectName = s.SubjectName,

                Time = s.Time
            }).ToList();
            return Page();
        }
    }
}
