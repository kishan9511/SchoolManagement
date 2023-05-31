using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;
using System.Runtime.CompilerServices;

namespace SchoolManagement.Pages.Teacher
{
    public class StudentDetailsModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public StudentDetailsModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IEnumerable<StudentDetails_Model> StudentDetailDatalist { get; set; }

        public List<SelectListItem> optionUSNDropdown { get; set; }

        public List<SelectListItem> optionSubjectNameDropdown { get; set; }
        public List<SelectListItem> optionMarksNameDropdown { get; set; }
        public List<SelectListItem> optionResultNameDropdown { get; set; }
        public List<SelectListItem> optionPassingDropdown { get; set; }
        public List<SelectListItem> optiontotalpassingmarksDropdown { get; set; }



        [BindProperty]
        public int SubjectID { get; set; }

        [BindProperty]
        public int MarksID { get; set; }

        [BindProperty]
        public int ResultID { get; set; }


        [BindProperty]
        public StudentDetail Detail { get; set; }



        public IActionResult OnGet(int? id)
        {

            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Teacher)
            {
                return RedirectToPage("/Logout");
            }

            StudentDetailDatalist = _db.StudentDetails.Where(t => t.IsDeleted == false).Select(t => new StudentDetails_Model
            {

                ID = t.Id,
                Name = t.Name,
                Email = t.Email,
                PhoneNumber = t.Phone,
                USN = t.Usn,
                Gender = t.Gender,
                Class = t.Class,
                Address = t.Address,
                Attendance = t.Attendance,
                Result = t.ResultEntry.Result,
                Subject = t.Subject.SubjectName,
                Marks = t.Marks.Marks,
                TotalMarks = t.ResultEntry.TotalMakes,
                PassinMarks = t.ResultEntry.PassingMarks

            }).ToList();

            Detail = new StudentDetail();
            if (id.HasValue)
            {
                var details = _db.StudentDetails.Where(d => d.Id == id && d.IsDeleted == false).FirstOrDefault();
                if (details == null)
                {
                    return Page();
                }

                Detail = details;
            }


            #region----------DDL get Method for SubjectNameDropdown---------

            optionSubjectNameDropdown = _db.Subjects.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.SubjectName,

            }).ToList();


            if (Detail?.SubjectId > 0)
            {
                var tea = _db.Subjects.Where(t => t.Id == Detail.SubjectId).Select(t => t).FirstOrDefault();
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



            #region----------DDL get Method for MarksDropdown---------

            optionMarksNameDropdown = _db.MarksEntries.Where(r => r.IsDeleted == false).Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Marks,

            }).ToList();

            if (Detail?.MarksId > 0)
            {
                var resultt = _db.MarksEntries.Where(r => r.Id == Detail.MarksId).Select(r => r).FirstOrDefault();
                optionMarksNameDropdown.Insert(0, new SelectListItem
                {
                    Text = resultt?.Marks,
                    Value = resultt?.Id.ToString()
                });

            }

            else
            {

                optionMarksNameDropdown.Insert(0, new SelectListItem()
                {
                    Text = "---------Marks-----------",
                    Value = string.Empty


                });

            }





            List<MarksEntry> listobjMarks = new List<MarksEntry>();
            listobjMarks = (from marksobj in _db.MarksEntries where marksobj.Id == MarksID select marksobj).ToList();

            #endregion


            #region----------DDL get Method for ResultDropdown---------

            optionResultNameDropdown = _db.ResultEntries.Where(r => r.IsDeleted == false).Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Result,

            }).ToList();

            if (Detail?.ResultEntryid > 0)
            {
                var resultt = _db.ResultEntries.Where(r => r.Id == Detail.ResultEntryid).Select(r => r).FirstOrDefault();
                optionResultNameDropdown.Insert(0, new SelectListItem
                {
                    Text = resultt?.Result,
                    Value = resultt?.Id.ToString()
                });

            }

            else
            {

                optionResultNameDropdown.Insert(0, new SelectListItem()
                {
                    Text = "---------Result-----------",
                    Value = string.Empty


                });

            }





            List<ResultEntry> listobjResult = new List<ResultEntry>();
            listobjResult = (from Resultsobj in _db.ResultEntries where Resultsobj.Id == ResultID select Resultsobj).ToList();

            #endregion


            #region----------DDL get Method for passingMarksDropdown---------

            optionPassingDropdown = _db.ResultEntries.Where(r => r.IsDeleted == false).Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.PassingMarks,

            }).ToList();

            if (Detail?.ResultEntryid > 0)
            {
                var resultt = _db.ResultEntries.Where(r => r.Id == Detail.ResultEntryid).Select(r => r).FirstOrDefault();
                optionPassingDropdown.Insert(0, new SelectListItem
                {
                    Text = resultt?.PassingMarks,
                    Value = resultt?.Id.ToString()
                });

            }

            else
            {

                optionPassingDropdown.Insert(0, new SelectListItem()
                {
                    Text = "---------Passing Marks-----------",
                    Value = string.Empty


                });

            }





            List<ResultEntry> listobjpassing = new List<ResultEntry>();
            listobjpassing = (from passinobj in _db.ResultEntries where passinobj.Id == ResultID select passinobj).ToList();

            #endregion

            #region----------DDL get Method for totalpassingmarksDropdown---------

            optiontotalpassingmarksDropdown = _db.ResultEntries.Where(r => r.IsDeleted == false).Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.TotalMakes,

            }).ToList();

            if (Detail?.ResultEntryid > 0)
            {
                var resultt = _db.ResultEntries.Where(r => r.Id == Detail.ResultEntryid).Select(r => r).FirstOrDefault();
                optiontotalpassingmarksDropdown.Insert(0, new SelectListItem
                {
                    Text = resultt?.TotalMakes,
                    Value = resultt?.Id.ToString()
                });

            }

            else
            {

                optiontotalpassingmarksDropdown.Insert(0, new SelectListItem()
                {
                    Text = "---------Total Marks-----------",
                    Value = string.Empty


                });

            }





            List<ResultEntry> listobjtotal = new List<ResultEntry>();
            listobjtotal = (from totalinobj in _db.ResultEntries where totalinobj.Id == ResultID select totalinobj).ToList();

            #endregion


            return Page();


        }

        public IActionResult OnPost()
        {
            if (Detail.Id > 0)
            {
                var details = _db.StudentDetails.AsNoTracking().Where(d => d.Id == Detail.Id && d.IsDeleted == false).FirstOrDefault();
                if (details == null)
                {
                    return Page();
                }
                Detail.SubjectId = SubjectID;
                Detail.MarksId = MarksID;
                Detail.ResultEntryid = ResultID;

                Detail.IsDeleted = details.IsDeleted;

                _db.StudentDetails.Update(Detail);
                _db.SaveChanges();
                TempData["info"] = "Your Data update Successfully";

            }
            else
            {
                Detail.ResultEntryid = ResultID;
                Detail.SubjectId = SubjectID;
                Detail.MarksId = MarksID;

                Detail.IsDeleted = false;
                _db.StudentDetails.Add(Detail);
                _db.SaveChanges();

                TempData["success"] = "data saved";

            }



            return RedirectToPage();
        }


        public IActionResult OnPostDelete(int? id)
        {

            var details = _db.StudentDetails.Where(d => d.Id == id && d.IsDeleted == false).FirstOrDefault();
            if (details == null)
            {
                return NotFound();
            }
            details.IsDeleted = true;
            _db.SaveChanges();

            TempData["success"] = "data deleted";
            return RedirectToPage();
        }


    }
}
