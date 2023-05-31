using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Student
{
    public class resultModel : PageModel
    {

        public readonly SchoolManagementContext _db;
        public resultModel(SchoolManagementContext db)
        {
            _db = db;
        }
     
         public IEnumerable<ResultEntry_Model> ResultDatalist { get; set; }


        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Student)
            {
                return RedirectToPage("/Logout");
            }

            ResultDatalist = _db.ResultEntries.Where(r => r.IsDeleted == false).Select(r => new ResultEntry_Model
            {
                ID = r.Id,
                SubjectID = r.SubjectId,
                StudentDetailsID = r.StudentDetailId,
                MarksID = r.MarksEntryId,
                USNDropdown = r.StudentDetail.Usn,
                NameDropdown = r.StudentDetail.Name,
                SubjectNameDropdown = r.Subject.SubjectName,
                MarksDropdown = r.MarksEntry.Marks,
                PassingMarks = r.PassingMarks,
                TotalMarks =r.TotalMakes,
                Result = r.Result
            }).ToList();
            return Page();
        }
    }
}
