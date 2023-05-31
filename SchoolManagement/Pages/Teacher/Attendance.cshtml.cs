using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Teacher
{
    public class AttendanceModel : PageModel
    {

        public readonly SchoolManagementContext _db;
        public AttendanceModel(SchoolManagementContext db)
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
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Teacher)
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
            Attendance = new StudentAttendance();

            if (id.HasValue)
            {
                var attendance = _db.StudentAttendances.Where(r => r.Id == id && r.Isdeleted == false).FirstOrDefault();
                if (attendance == null)
                {
                    return Page();
                }
                Attendance = attendance;

            }


            #region----------DDL get Method for USNDropdown---------


            optionUSNDropdown = _db.StudentDetails.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {

                Value = t.Id.ToString(),
                Text = t.Usn,


            }).ToList();

            if (Attendance?.StudentDetailId > 0)
            {
                var tea = _db.StudentDetails.Where(t => t.Id == Attendance.StudentDetailId).Select(t => t).FirstOrDefault();
                optionUSNDropdown.Insert(0, new SelectListItem
                {
                    Text = tea?.Usn,
                    Value = tea?.Id.ToString()

                });

            }



            else
            {
                optionUSNDropdown.Insert(0, new SelectListItem()
                {
                    Text = "-------Select your USN---------",
                    Value = string.Empty


                });
            }

            List<StudentDetail> listobjsd = new List<StudentDetail>();
            listobjsd = (from sdobj in _db.StudentDetails where sdobj.Id == StudentDetailsID select sdobj).ToList();


            #endregion


            #region----------DDL get Method for NameDropdown---------

            optionNameDropdown = _db.StudentDetails.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name,

            }).ToList();


            if (Attendance?.StudentDetailId > 0)
            {
                var tea = _db.StudentDetails.Where(t => t.Id == Attendance.StudentDetailId).Select(t => t).FirstOrDefault();
                optionNameDropdown.Insert(0, new SelectListItem

                {
                    Text = tea?.Name,
                    Value = tea?.Id.ToString()

                });

            }

            else
            {
                optionNameDropdown.Insert(0, new SelectListItem()
                {
                    Text = "---------Name-----------",
                    Value = string.Empty


                });

            }
            List<StudentDetail> listobjsdd = new List<StudentDetail>();
            listobjsdd = (from sdobj in _db.StudentDetails where sdobj.Id == StudentDetailsID select sdobj).ToList();

            #endregion




            return Page();
        }
        public IActionResult OnPost()
        {
            if (Attendance.Id > 0)
            {
                var attendance = _db.StudentAttendances.AsNoTracking().Where(r => r.Id == Attendance.Id && r.Isdeleted == false).FirstOrDefault();
                if (attendance == null)
                {
                    return Page();
                }


                Attendance.StudentDetailId = StudentDetailsID;





                Attendance.Isdeleted = attendance.Isdeleted;
                _db.StudentAttendances.Update(Attendance);
                _db.SaveChanges();

                TempData["info"] = "Your Data update Successfully";


            }

            else
            {
                Attendance.StudentDetailId = StudentDetailsID;





                Attendance.Isdeleted = false;
                _db.StudentAttendances.Add(Attendance);
                _db.SaveChanges();

                TempData["success"] = "data saved";

            }

            return RedirectToPage();

        }
        public IActionResult OnPostDelete(int? id)

        {

            var attendence = _db.StudentAttendances.Where(t => t.Id == id && t.Isdeleted == false).FirstOrDefault();
            if (attendence == null)
            {
                return NotFound();
            }

            attendence.Isdeleted = true;
            _db.SaveChanges();

            TempData["success"] = "data deleted";
            return RedirectToPage();
        }

    }

}
