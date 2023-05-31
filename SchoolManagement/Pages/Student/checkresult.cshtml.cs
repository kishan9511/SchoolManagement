using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Student
{
    public class checkresultModel : PageModel
    { 
        public readonly SchoolManagementContext _db;
        public checkresultModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IEnumerable<check_Model> checkDatalist { get; set; }

        public List<SelectListItem> optionNameDropdown { get; set; }
        public List<SelectListItem> optionUSNDropdown { get; set; }

       

        [BindProperty]
        public int StudentDetailsID { get; set; }



        [BindProperty]
        public int SubjectID { get; set; }

        [BindProperty]
        public int MarksID { get; set; }

        [BindProperty]
        public int ResultID { get; set; }


        [BindProperty]
        public Checkresult Check { get; set; }


        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Student)
            {
                return RedirectToPage("/Logout");
            }

            checkDatalist = _db.Checkresults.Where(c => c.IsDeleted == false).Select(c => new check_Model
            {
                Id = c.Id,
                markID = c.MarkId,
                ResultID = c.ResultId,
                NameDropdown = c.StudentDetail.Name,
                USNDropdown = c.StudentDetail.Usn,
              

            }).ToList();
            Check = new Checkresult();

            if (id.HasValue)
            {
                var checks = _db.Checkresults.Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();
                if (checks == null)
                {
                    return Page();

                }
                Check = checks;
            }

            #region----------DDL get Method for USNDropdown---------


            optionUSNDropdown = _db.StudentDetails.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {

                Value = t.Id.ToString(),
                Text = t.Usn,


            }).ToList();

            if (Check?.StudentDetailId > 0)
            {
                var tea = _db.StudentDetails.Where(t => t.Id == Check.StudentDetailId).Select(t => t).FirstOrDefault();
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


            if (Check?.StudentDetailId > 0)
            {
                var tea = _db.StudentDetails.Where(t => t.Id == Check.StudentDetailId).Select(t => t).FirstOrDefault();
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
            if (Check.Id > 0)
            {
                var checks = _db.Checkresults.AsNoTracking().Where(c => c.Id == Check.Id && c.IsDeleted == false).FirstOrDefault();
                if (checks == null)
                {
                    return Page();
                }
                Check.StudentDetailId = StudentDetailsID;
                Check.ResultId = ResultID;
                Check.MarkId = MarksID;

                Check.IsDeleted = checks.IsDeleted;
                _db.Checkresults.Update(Check);
                _db.SaveChanges();
                TempData["info"] = "Your Data update Successfully";

            }
            else
            {
                Check.StudentDetailId = StudentDetailsID;
                Check.ResultId = ResultID;
                Check.MarkId = MarksID;

                Check.IsDeleted = false;
                _db.Checkresults.Add(Check);
                _db.SaveChanges();
                TempData["success"] = "data saved";

            }

            return RedirectToPage();
        }


        public IActionResult OnPostDelete(int? id)
        {
            var checks = _db.Checkresults.Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();
            if (checks == null)
            {
                return Page();
            }
            checks.IsDeleted = true;
            _db.SaveChanges();

            TempData["success"] = "data deleted";
            return RedirectToPage();

        }



    }
}
