using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Teacher
{
    public class ApprovedForExaminationModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public ApprovedForExaminationModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IEnumerable<ApprovedExam_Model> approvedExamDatalist { get; set; }


      

        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Teacher)
            {
                return RedirectToPage("/Logout");
            }

            approvedExamDatalist = _db.ApprovedforExaminations.Where(a => a.IsDeleted == false).Select(a => new ApprovedExam_Model
            {

                ID = a.Id,
                SubjectID = a.SubjectId,
                TeacherDetailID = a.TeacherDetailsId,

                NameDropdown = a.TeacherDetails.Name,
                SubjectDropdown = a.Subject.SubjectName,
                ExamHallNumber = a.ExamHallNumber
            }).ToList();
            return Page();



        }
    }
}
