using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Teacher
{
    public class ResultEntryModel : PageModel
    {

        public readonly SchoolManagementContext _db;
        public ResultEntryModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IEnumerable<ResultEntry_Model> ResultEntryDatalist { get; set; }

        public List<SelectListItem> optionNameDropdown { get; set; }
        public List<SelectListItem> optionUSNDropdown { get; set; }
        public List<SelectListItem> optionSubjectNameDropdown { get; set; }
        public List<SelectListItem> optionMarksNameDropdown { get; set; }




        [BindProperty]
        public ResultEntry Result { get; set; }

        [BindProperty]
        public int StudentDetailsID { get; set; }

        [BindProperty]
        public int SubjectID { get; set; }

        [BindProperty]
        public int MarksID { get; set; }



        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Teacher)
            {
                return RedirectToPage("/Logout");
            }

            ResultEntryDatalist = _db.ResultEntries.Where(r => r.IsDeleted == false).Select(r => new ResultEntry_Model
            {
                ID = r.Id,
                SubjectID = r.SubjectId,
                StudentDetailsID = r.StudentDetailId,

              
                MarksID = r.MarksEntryId,
                TotalMarks = r.TotalMakes,
                USNDropdown = r.StudentDetail.Usn,
                NameDropdown = r.StudentDetail.Name,

                PassingMarks = r.PassingMarks,
                SubjectNameDropdown = r.Subject.SubjectName,
                MarksDropdown = r.MarksEntry.Marks,
                Result = r.Result
            }).ToList();
            Result = new ResultEntry();

            if (id.HasValue)
            {
                var result = _db.ResultEntries.Where(r => r.Id == id && r.IsDeleted == false).FirstOrDefault();
                if (result == null)
                {
                    return Page();
                }
                Result = result;

            }


            #region----------DDL get Method for USNDropdown---------


            optionUSNDropdown = _db.StudentDetails.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {

                Value = t.Id.ToString(),
                Text = t.Usn,


            }).ToList();

            if (Result?.StudentDetailId > 0)
            {
                var tea = _db.StudentDetails.Where(t => t.Id == Result.StudentDetailId).Select(t => t).FirstOrDefault();
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


            if (Result?.StudentDetailId > 0)
            {
                var tea = _db.StudentDetails.Where(t => t.Id == Result.StudentDetailId).Select(t => t).FirstOrDefault();
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


            #region----------DDL get Method for SubjectNameDropdown---------

            optionSubjectNameDropdown = _db.Subjects.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.SubjectName,

            }).ToList();


            if (Result?.SubjectId > 0)
            {
                var tea = _db.Subjects.Where(t => t.Id == Result.SubjectId).Select(t => t).FirstOrDefault();
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

            if (Result?.MarksEntryId > 0)
            {
                var resultt = _db.MarksEntries.Where(r => r.Id == Result.MarksEntryId).Select(r => r).FirstOrDefault();
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


            return Page();
        }




        public IActionResult OnPost()
        {
            if (Result.Id > 0)
            {
                var resuult = _db.ResultEntries.AsNoTracking().Where(r => r.Id == Result.Id && r.IsDeleted == false).FirstOrDefault();
                if (resuult == null)
                {
                    return Page();
                }


                Result.StudentDetailId = StudentDetailsID;




                Result.SubjectId =SubjectID;
                Result.MarksEntryId = MarksID;

                Result.IsDeleted = resuult.IsDeleted;
                _db.ResultEntries.Update(Result);
                _db.SaveChanges();

                TempData["info"] = "Your Data update Successfully";


            }

            else
            {
                Result.StudentDetailId = StudentDetailsID;



                Result.SubjectId = SubjectID;
                Result.MarksEntryId = MarksID;

                Result.IsDeleted = false;
                _db.ResultEntries.Add(Result);
                _db.SaveChanges();

                TempData["success"] = "data saved";

            }

            return RedirectToPage();

        }


        public IActionResult OnPostDelete(int? id)

        {

            var resultt = _db.ResultEntries.Where(t => t.Id == id && t.IsDeleted == false).FirstOrDefault();
            if (resultt == null)
            {
                return NotFound();
            }

            resultt.IsDeleted = true;
            _db.SaveChanges();

            TempData["success"] = "data deleted";
            return RedirectToPage();
        }

    }
}
