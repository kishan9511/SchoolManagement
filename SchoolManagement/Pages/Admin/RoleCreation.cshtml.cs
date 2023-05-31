using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Admin
{
    public class RoleCreationModel : PageModel
    {

        public readonly SchoolManagementContext _db;
        public RoleCreationModel(SchoolManagementContext db)
        {
            _db = db;
        }

        public IEnumerable<RoleCreation> RoleCreationDatalist { get; set; }

        [BindProperty]
        public RoleCreation RoleCreationn { get; set; }


        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Admin)
            {
                return RedirectToPage("/Logout");
            }

            RoleCreationDatalist = _db.RoleCreations.Where(r => r.IsDeleted == false).ToList();
            if (id.HasValue)
            {
                var Role = _db.RoleCreations.Where(r => r.Id == id && r.IsDeleted == false).FirstOrDefault();
                if (Role == null)
                {
                    return Page();
                }
                RoleCreationn = Role;
                return Page();
            }

            RoleCreationn = new RoleCreation();
            return Page();
        }




        public IActionResult OnPost()
        {
            if (RoleCreationn.Id > 0)
            {
                var RoleeCreation = _db.RoleCreations.AsNoTracking().Where(a => a.Id == RoleCreationn.Id && a.IsDeleted == false).FirstOrDefault();
                if (RoleeCreation == null)
                {
                    return Page();
                }
                RoleCreationn.IsDeleted = RoleeCreation.IsDeleted;
                _db.RoleCreations.Update(RoleCreationn);
                _db.SaveChanges();
                TempData["info"] = "Your Data update Successfully";
            }
            else
            {
                RoleCreationn.IsDeleted = false;
                _db.RoleCreations.Add(RoleCreationn);
                _db.SaveChanges();
                TempData["success"] = "data saved";
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int? id)
        {
            var RoleeCreation = _db.RoleCreations.Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefault();
            if (RoleeCreation == null)
            {
                return NotFound();
            }
            RoleeCreation.IsDeleted = true;

            _db.SaveChanges();
            TempData["success"] = "data deleted";
            return RedirectToPage();
        }





    }
}
