using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherDetailController : ControllerBase
    {
        public readonly SchoolManagementContext _db; 
        public TeacherDetailController(SchoolManagementContext db)
        {
            _db = db;
        }

        //-------------------------------------------API Creations----------------------------------------------





        //-------------------------------EmailDropdown wiht respect to NameDropdown-------------------------------------------
        public async Task<IActionResult> GetEmailDropdown(int RegistrationID)
        {
            var EmailDrop = await _db.Registrations.Where(t => t.IsDeleted == false && t.Id == RegistrationID).Select(t => new
            {
                ID = t.Id,
                EmailDropdown = t.Email,
            }).ToArrayAsync();


            return new JsonResult(EmailDrop);
        }


    
       

    }
}
