using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;
using System.Diagnostics; 

namespace SchoolManagement.Pages.Admin
{ 
    public class SubjectTakenModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public SubjectTakenModel(SchoolManagementContext db)
        {
            _db = db;
        }
        public IEnumerable<SubjectTaken_Model> subjectTakenDatalist { get; set; }
        public List<SelectListItem> optionNameDropdown { get; set; }

     


        [BindProperty]
        public SubjectTakenByTeacher SubjectTaken { get; set; }

        [BindProperty]
        public int TeacherDetailID { get; set; }



        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Admin)
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
            SubjectTaken = new SubjectTakenByTeacher();

            if (id.HasValue)
            {
                var Sub = _db.SubjectTakenByTeachers.Where(s => s.IsDeleted == false && s.Id==id).FirstOrDefault();
                if (Sub == null)
                {
                    return Page();
                }

                SubjectTaken = Sub;

            }



            

            #region----------DDL get Method for NameDropdown---------

            optionNameDropdown = _db.TeacherDetails.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name,

            }).ToList();


            if (SubjectTaken?.TeacherDetailsId > 0)
            {
                var tea = _db.TeacherDetails.Where(t => t.Id == SubjectTaken.TeacherDetailsId).Select(t => t).FirstOrDefault();
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




            return Page();
        }

        public IActionResult OnPost()
        {
            if(SubjectTaken.Id>0)
            {
                var sub = _db.SubjectTakenByTeachers.AsNoTracking().Where(s => s.Id == SubjectTaken.Id && s.IsDeleted == false).FirstOrDefault();
                if(sub == null)
                {
                    return Page();
                }
               
                SubjectTaken.TeacherDetailsId = TeacherDetailID;
                SubjectTaken.IsDeleted = sub.IsDeleted;

                _db.SubjectTakenByTeachers.Update(SubjectTaken);
                _db.SaveChanges();
                TempData["info"] = "Your Data update Successfully";


            }
            else
            {

                SubjectTaken.TeacherDetailsId = TeacherDetailID;
                SubjectTaken.IsDeleted = false;

                _db.SubjectTakenByTeachers.Add(SubjectTaken);
                _db.SaveChanges();
                TempData["success"] = "data saved";


            }


            return RedirectToPage();


        }
        public IActionResult OnPostDelete(int? id)
        {
            var sub = _db.SubjectTakenByTeachers.Where(s => s.Id == id && s.IsDeleted == false).FirstOrDefault();
            if(sub == null)
            {
                return Page();
            }
            sub.IsDeleted = true;
            _db.SaveChanges();
            TempData["success"] = "data deleted";

            return RedirectToPage();
        }








    }
}
