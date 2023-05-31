using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;
using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace SchoolManagement.Pages.Admin
{
    public class TeacherDetailModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public TeacherDetailModel(SchoolManagementContext db)
        {
            _db = db;
        }

               
        public IEnumerable<TeacherDetail> TeacherDetailsDatalist { get; set; }

        [BindProperty]
        public TeacherDetail teacherDetail { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Admin)
            {
                return RedirectToPage("/Logout");
            }


            TeacherDetailsDatalist = _db.TeacherDetails.Where(t => t.IsDeleted == false).ToList();
                     
            if(id.HasValue)
            {
                var tteacherDetails = _db.TeacherDetails.Where(t => t.IsDeleted == false && t.Id == id).FirstOrDefault();

                if(tteacherDetails== null)
                {
                    return Page();
                }

                teacherDetail = tteacherDetails;
                return Page();
            }

            teacherDetail = new TeacherDetail();
            return Page();
        }


        public IActionResult OnPost()
        {

            if (teacherDetail.Id > 0)
            {
                var teach = _db.TeacherDetails.AsNoTracking().Where(t => t.Id == teacherDetail.Id && t.IsDeleted == false).FirstOrDefault();
                if (teach == null)
                {
                    return Page();
                }
                                                       
                teacherDetail.IsDeleted = teach.IsDeleted;
                _db.TeacherDetails.Update(teacherDetail);
                _db.SaveChanges();

                TempData["info"] = "Your Data update Successfully";
            }


            else
            {
                             
                teacherDetail.IsDeleted = false;
                _db.TeacherDetails.Add(teacherDetail);
                _db.SaveChanges();

                TempData["success"] = "data saved";

            }


            return RedirectToPage();
        }




        public IActionResult OnPostDelete(int? id)
        {
            var teach = _db.TeacherDetails.Where(t => t.Id == id && t.IsDeleted == false).FirstOrDefault();
            if( teach==null)
            {
                return NotFound();
            }

            teach.IsDeleted = true;
            _db.SaveChanges();

            TempData["success"] = "data deleted";
            return RedirectToPage();
        }


    }
}
