using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Teacher
{
    public class MarksEntryModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public MarksEntryModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IEnumerable<MarksEntry_Model> marksEntryDatabase { get; set; }

        public List<SelectListItem> optionNameDropdown { get; set; }
        public List<SelectListItem> optionSubjectNameDropdown { get; set; }




        [BindProperty]
        public int StudentDetailID { get; set; }

        [BindProperty]
        public int SubjectID { get; set; }

        [BindProperty]
        public MarksEntry Entry { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Teacher)
            {
                return RedirectToPage("/Logout");
            }



            marksEntryDatabase = _db.MarksEntries.Where(f => f.IsDeleted == false).Select(f => new MarksEntry_Model
            {

                ID = f.Id,
                SubjectID = f.SubjectId,
                StudentDetailsID = f.StudentDetailId,
                TotalMarks = f.TotalMakes,
                NameDropdown = f.StudentDetail.Name,
                SubjectNameDropdown = f.Subject.SubjectName,
                Marks = f.Marks,
                PassingMarks = f.PassingMarks
            }).ToList();

            Entry = new MarksEntry();


            if (id.HasValue)
            {
                var marks = _db.MarksEntries.Where(t => t.Id == id && t.IsDeleted == false).FirstOrDefault();

                if (marks == null)
                {
                    return Page();
                }

                Entry = marks;

            }



            #region----------DDL get Method for NameDropdown---------

            optionNameDropdown = _db.StudentDetails.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name,

            }).ToList();


            if (Entry?.StudentDetailId > 0)
            {
                var tea = _db.StudentDetails.Where(t => t.Id == Entry.StudentDetailId).Select(t => t).FirstOrDefault();
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
            List<StudentDetail> listobjsd = new List<StudentDetail>();
            listobjsd = (from sdobj in _db.StudentDetails where sdobj.Id == StudentDetailID select sdobj).ToList();

            #endregion


            #region----------DDL get Method for SubjectNameDropdown---------

            optionSubjectNameDropdown = _db.Subjects.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.SubjectName,

            }).ToList();


            if (Entry?.SubjectId > 0)
            {
                var tea = _db.Subjects.Where(t => t.Id == Entry.SubjectId).Select(t => t).FirstOrDefault();
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

            if (Entry.Id > 0)
            {
                var markss = _db.MarksEntries.AsNoTracking().Where(t => t.Id == Entry.Id && t.IsDeleted == false).FirstOrDefault();
                if (markss == null)
                {
                    return Page();
                }

                Entry.StudentDetailId =StudentDetailID;
                Entry.SubjectId = SubjectID;

                Entry.IsDeleted = markss.IsDeleted;
                _db.MarksEntries.Update(Entry);
                _db.SaveChanges();

                TempData["info"] = "Your Data update Successfully";
            }


            else
            {

                Entry.StudentDetailId = StudentDetailID;
                Entry.SubjectId = SubjectID;

                Entry.IsDeleted = false;
                _db.MarksEntries.Add(Entry);
                _db.SaveChanges();

                TempData["success"] = "data saved";

            }


            return RedirectToPage();
        }


        public IActionResult OnPostDelete(int? id)
        {
            var marks = _db.MarksEntries.Where(t => t.Id == id && t.IsDeleted == false).FirstOrDefault();
            if (marks == null)
            {
                return NotFound();
            }

            marks.IsDeleted = true;
            _db.SaveChanges();

            TempData["success"] = "data deleted";
            return RedirectToPage();
        }






    }
}