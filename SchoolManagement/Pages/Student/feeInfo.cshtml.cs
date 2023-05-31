using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Student
{
    public class feeInfoModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public feeInfoModel(SchoolManagementContext db)
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


            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Student)
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
                var fees = _db.Feesinfos.Where(t => t.IsDeleted == false & t.Id == id).FirstOrDefault();

                if (fees == null)
                {
                    return Page();
                }

                feesinfo = fees;

            }
            return Page();
        }

       
    }
}
