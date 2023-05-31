using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using System.ComponentModel;

namespace SchoolManagement.Pages
{
    public class DashboardAnalyticsModel : PageModel
    {
        public readonly SchoolManagementContext _db;
        public DashboardAnalyticsModel (SchoolManagementContext db)
        {
            _db = db;
        }
        public IEnumerable<DashboardAnalytic> DashboardAnalyticDatalist { get; set; }

        [BindProperty]
        public DashboardAnalytic Analytic { get; set; }


        public IActionResult OnGet(int? id)
        {
            DashboardAnalyticDatalist = _db.DashboardAnalytics.Where(a => a.IsDeleted == false).ToList();
            if(id.HasValue)
            {
                var Analyticc = _db.DashboardAnalytics.Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefault();
                if(Analyticc == null)
                {
                    return NotFound();
                }
                Analytic= Analyticc;
                return Page();
            }
            Analytic = new DashboardAnalytic();

            return Page();
        }
        public IActionResult OnPost() 
        
        {
            if(Analytic.Id>0)
            {
                var Analyticc = _db.DashboardAnalytics.AsNoTracking().Where(a => a.Id == Analytic.Id && a.IsDeleted == false).FirstOrDefault();
                if (Analyticc == null)
                {
                    return Page();
                }
                Analytic.IsDeleted = Analyticc.IsDeleted;
                _db.DashboardAnalytics.Update(Analytic);
                _db.SaveChanges();
                TempData["info"] = "Your Data update Successfully";

            }
            else
            {
                Analytic.IsDeleted = false;
                _db.DashboardAnalytics.Add(Analytic);
                _db.SaveChanges();
                TempData["success"] = "data saved";
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int? id)
        {
            var DashboardAnalyticsss = _db.DashboardAnalytics.Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefault();
            if(DashboardAnalyticsss == null)
            {
                return NotFound();
            }
            DashboardAnalyticsss.IsDeleted = true;

            _db.SaveChanges();
            TempData["success"] = "data deleted";
            return RedirectToPage();
        }



    }
}
