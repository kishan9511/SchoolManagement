using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Admin
{
    public class ApprovedForExaminationModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public ApprovedForExaminationModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IEnumerable<ApprovedExam_Model> approvedExamDatalist { get; set; }

        public List<SelectListItem> optionNameDropdown { get; set; }
        public List<SelectListItem> optionEmailDropdown { get; set; }

        public List<SelectListItem> optionSubjectNameDropdown { get; set; }




        [BindProperty]
        public int TeacherDetailID { get; set; }



        [BindProperty]
        public int SubjectID { get; set; }


        [BindProperty]
        public ApprovedforExamination Approved { get; set; }

        public IActionResult OnGet(int? id)
        {


            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Admin)
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

            Approved = new ApprovedforExamination();

            if (id.HasValue)
            {
                var approveed = _db.ApprovedforExaminations.Where(a => a.IsDeleted == false && a.Id == id).FirstOrDefault();

                if (approveed == null)
                {
                    return Page();
                }

                Approved = approveed;
            }




            #region----------DDL get Method for NameDropdown---------

            optionNameDropdown = _db.TeacherDetails.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name,

            }).ToList();


            if (Approved?.TeacherDetailsId > 0)
            {
                var tea = _db.TeacherDetails.Where(t => t.Id == Approved.TeacherDetailsId).Select(t => t).FirstOrDefault();
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
            List<TeacherDetail> listobjTD = new List<TeacherDetail>();
            listobjTD = (from TDobj in _db.TeacherDetails where TDobj.Id == TeacherDetailID select TDobj).ToList();

            #endregion






            #region----------DDL get Method for SubjectNameDropdown---------

            optionSubjectNameDropdown = _db.Subjects.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.SubjectName,

            }).ToList();


            if (Approved?.SubjectId > 0)
            {
                var tea = _db.Subjects.Where(t => t.Id == Approved.SubjectId).Select(t => t).FirstOrDefault();
                optionSubjectNameDropdown.Insert(0, new SelectListItem

                {
                    Text = tea?.SubjectName,
                    Value = tea?.Id.ToString()

                });

            }

            else
            {
                optionSubjectNameDropdown.Insert(0, new SelectListItem()
                {
                    Text = "---------Subject-----------",
                    Value = string.Empty


                });

            }
            List<Subject> listobjsub = new List<Subject>();
            listobjsub = (from Subjectobj in _db.Subjects where Subjectobj.Id == SubjectID select Subjectobj).ToList();

            #endregion


            return Page();
        }

        public IActionResult OnPost()
        {

            if (Approved.Id > 0)
            {
                var Appro = _db.ApprovedforExaminations.AsNoTracking().Where(a => a.Id == Approved.Id && a.IsDeleted == false).FirstOrDefault();
                if (Appro == null)
                {
                    return Page();

                }
                Approved.TeacherDetailsId = TeacherDetailID;
                Approved.SubjectId = SubjectID;


                Approved.IsDeleted = Appro.IsDeleted;
                _db.ApprovedforExaminations.Update(Approved);
                _db.SaveChanges();

                TempData["info"] = "Your Data update Successfully";

            }


            else
            {
                Approved.TeacherDetailsId = TeacherDetailID;
                Approved.SubjectId = SubjectID;


                Approved.IsDeleted = false;
                _db.ApprovedforExaminations.Add(Approved);
                _db.SaveChanges();

                TempData["success"] = "data saved";

            }


            return RedirectToPage();

        }


        public IActionResult OnPostDelete(int? id)

        {
            var Approo = _db.ApprovedforExaminations.Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefault();
            if (Approo == null)
            {
                return NotFound();
            }

            Approo.IsDeleted = true;
            _db.SaveChanges();

            TempData["success"] = "data deleted";


            return RedirectToPage();

        }


    }
}
