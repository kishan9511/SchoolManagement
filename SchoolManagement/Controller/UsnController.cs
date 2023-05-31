using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsnController : ControllerBase
    {
        public readonly SchoolManagementContext _db;
        public UsnController (SchoolManagementContext db)
        {
            _db = db;
        }

        //-------------------------------------API CREATIONS------------------------------------------


        //-------------------------------------Name with respect to USN--------------------------------------------

        public async Task<IActionResult> GetNameDropdown(int StudentDetailid)
        {
            var NameDropdown = await _db.StudentDetails.Where(t => t.IsDeleted == false && t.Id == StudentDetailid).Select(t => new
            {
                ID = t.Id,
                NameDropdown = t.Name,







            }).ToArrayAsync();

            return new JsonResult(NameDropdown);

        }




    }
}
