using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Teacher
{
    public class FeesInfoModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public FeesInfoModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IEnumerable<FeesInfo_Model> feesinfoDatalist { get; set; }
        public List<SelectListItem> optionNameDropdown { get; set; }

        [BindProperty]
        public Feesinfo feesinfo { get; set; }

        [BindProperty]
        public int StudentDetailID { get; set; }

        public IActionResult OnGet(int? id)
        {


            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Teacher)
            {
                return RedirectToPage("/Logout");
            }

            feesinfoDatalist = _db.Feesinfos.Where(f => f.IsDeleted == false).Select(f => new FeesInfo_Model
            {

                ID = f.Id,
                StudentDetailID = f.StudentDetailId,
                NameDropdown = f.StudentDetail.Name,
                TotalFee = f.TotalFees,
                PaidFess = f.PaidFess,
                DueFees = f.DueFees
            }).ToList();
            feesinfo = new Feesinfo();

            if (id.HasValue)
            {
                var fees = _db.Feesinfos.Where(t => t.IsDeleted == false & t.Id==id).FirstOrDefault();

                if (fees == null)
                {
                    return Page();
                }

                feesinfo = fees;

            }




            #region----------DDL get Method for NameDropdown---------

            optionNameDropdown = _db.StudentDetails.Where(t => t.IsDeleted == false).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name,

            }).ToList();


            if (feesinfo?.StudentDetailId > 0)
            {
                var tea = _db.StudentDetails.Where(t => t.Id == feesinfo.StudentDetailId).Select(t => t).FirstOrDefault();
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


            return Page();
        }
        public IActionResult OnPost()
        {

            if (feesinfo.Id > 0)
            {
                var teach = _db.Feesinfos.AsNoTracking().Where(t => t.Id == feesinfo.Id && t.IsDeleted == false).FirstOrDefault();
                if (teach == null)
                {
                    return Page();
                }
                feesinfo.StudentDetailId = StudentDetailID;

                feesinfo.IsDeleted = teach.IsDeleted;
                _db.Feesinfos.Update(feesinfo);
                _db.SaveChanges();

                TempData["info"] = "Your Data update Successfully";
            }


            else
            {

                feesinfo.StudentDetailId = StudentDetailID;

                feesinfo.IsDeleted = false;
                _db.Feesinfos.Add(feesinfo);
                _db.SaveChanges();

                TempData["success"] = "data saved";

            }


            return RedirectToPage();
        }


        public IActionResult OnPostDelete(int? id)
        {
            var fee = _db.Feesinfos.Where(t => t.Id == id && t.IsDeleted == false).FirstOrDefault();
            if (fee == null)
            {
                return NotFound();
            }

            fee.IsDeleted = true;
            _db.SaveChanges();

            TempData["success"] = "data deleted";
            return RedirectToPage();
        }




    }
}
