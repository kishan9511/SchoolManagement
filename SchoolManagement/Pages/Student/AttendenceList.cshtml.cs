using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Student
{
    public class AttendenceListModel : PageModel
    {

        public readonly SchoolManagementContext _db;
        public AttendenceListModel(SchoolManagementContext db)
        {
            _db = db;
        }
        public IEnumerable<StudentAttendance_Model> studentAttendancesDatalist { get; set; }
        public List<SelectListItem> optionNameDropdown { get; set; }
        public List<SelectListItem> optionUSNDropdown { get; set; }

        [BindProperty]
        public StudentAttendance Attendance { get; set; }
        [BindProperty]
        public int StudentDetailsID { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Student)
            {
                return RedirectToPage("/Logout");
            }

            studentAttendancesDatalist = _db.StudentAttendances.Where(r => r.Isdeleted == false).Select(r => new StudentAttendance_Model
            {
                ID = r.Id,
                StudentDetailsID = r.StudentDetailId,
                USNDropdown = r.StudentDetail.Usn,
                NameDropdown = r.StudentDetail.Name,
                Attendance = r.Attendance,
                Date = r.Date
            }).ToList();
            return Page();



        }
    }
}