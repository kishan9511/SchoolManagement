using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Admin
{
    public class RegistrationModel : PageModel
    {

        public readonly SchoolManagementContext _db;
        public RegistrationModel(SchoolManagementContext db)
        {
            _db = db;
        }

       public List<SelectListItem> optionRoleDropdown { get; set; }
       public IEnumerable<Registration_Model> RegistrationDatalist { get; set; }

        [BindProperty]
        public Registration registration { get; set; }

        [BindProperty]
        public int RoleID { get; set; }




        public IActionResult OnGet(int? id)
        {

            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Admin)
            {
                return RedirectToPage("/Logout");
            }

            RegistrationDatalist = _db.Registrations.Where(r => r.IsDeleted == false).Select(r => new Registration_Model
            {

                ID = r.Id,
                RoleID = r.RoleId,
                Name = r.Name,
                RoleName =r.Role.Name,
                Email = r.Email,
                Password = r.Password,
            }).ToList();


            registration = new Registration();
            if (id.HasValue)
            {
                var Reg = _db.Registrations.Where(r => r.Id == id && r.IsDeleted == false).FirstOrDefault();

                if (Reg == null)
                {
                    return NotFound();

                }
                registration = Reg;
                
            }


            #region----------DDL get Method for RoleDropdown---------

            optionRoleDropdown = _db.RoleCreations.Where(r => r.IsDeleted == false).Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            }

            ).ToList();

            if(registration?.RoleId>0)
            {
                var rrole = _db.RoleCreations.Where(r => r.Id == registration.RoleId).Select(r => r).FirstOrDefault();
                optionRoleDropdown.Insert(0, new SelectListItem()
                {
                    Text = rrole.Name,
                    Value = rrole.Id.ToString()
                }

                );
            }

            else

            {
                optionRoleDropdown.Insert(0, new SelectListItem()
                {
                
                Text = "----Select Your Role----",
                Value = string.Empty
                
                }
                );

            }


            List<RoleCreation> listobjrole = new List<RoleCreation>();
            listobjrole = (from roleidobj in _db.RoleCreations where roleidobj.Id ==RoleID select roleidobj).ToList();  


            #endregion


            return Page();
        }

        public IActionResult OnPost()
        {
            if(registration.Id>0)
            {
                var reg = _db.Registrations.AsNoTracking().Where(r => r.Id == registration.Id && r.IsDeleted == false).FirstOrDefault();
                if (reg == null) 
                {
                    return Page();
                
                }

                registration.RoleId = RoleID;
                registration.IsDeleted = reg.IsDeleted;
                _db.Registrations.Update(registration);
                _db.SaveChanges();

                TempData["info"] = "Your Data update Successfully";
            }

            else
            {
                registration.RoleId = RoleID;
                registration.IsDeleted = false;
                _db.Registrations.Add(registration);
                _db.SaveChanges();

                TempData["success"] = "data saved";



            }
            return RedirectToPage();
        }



        //public IActionResult OnPostDelete(int? id)
        //{
        //    var regg = _db.Registrations.Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefault();
        //    if (regg == null)
        //    {
        //        return NotFound();
        //    }
        //    regg.IsDeleted = true;

        //    _db.SaveChanges();
        //    TempData["success"] = "data deleted";
        //    return RedirectToPage();
        //}




    }
}
