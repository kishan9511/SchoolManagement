using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using System.Reflection.Metadata.Ecma335;

namespace SchoolManagement.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentDetailsController : ControllerBase
    {
    //    public readonly SchoolManagementContext _db;
    //    public StudentDetailsController(SchoolManagementContext db) 
    //    {
    //        _db = db;

    //    }

    //    //-------------------------------------------API Creations----------------------------------------------



     

    //    //-------------------------------EmailDropdown wiht respect to NameDropdown-------------------------------------------
    //    public async Task<IActionResult>GetEmailDropdown(int StudentRegistrationID)
    //    {
    //        var EmailDrop = await _db.StudentRegistrations.Where(t => t.IsDeleted == false && t.Id == StudentRegistrationID).Select(t => new
    //        {
    //            ID = t.Id,
    //            EmailDropdown = t.Email,
    //        }).ToArrayAsync();


    //        return new JsonResult(EmailDrop);
    //    }





    //    //for ResultEntry
    //    //--------------------------------------NameDropdown With Respec to USNDropdown--------------------------------------

    //    public async Task<IActionResult> GetNameDropdown(int StudentRegistrationID)
    //    {
    //        var NameDropdown = await _db.StudentRegistrations.Where(t => t.IsDeleted == false && t.Id == StudentRegistrationID).Select(t => new
    //        {
    //            ID = t.Id,
    //            NameDropdown = t.Name,

    //        }).ToArrayAsync();

    //        return new JsonResult(NameDropdown);

    //    }
        



    }
}
