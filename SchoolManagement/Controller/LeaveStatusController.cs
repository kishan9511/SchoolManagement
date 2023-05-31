using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController] 
    public class LeaveStatusController : ControllerBase
    {
        public readonly SchoolManagementContext _db;
        public LeaveStatusController(SchoolManagementContext db)
        {
            _db = db;
        }

        //-------------------------------------API CREATIONS------------------------------------------


        //-------------------------------------Name with respect to USN--------------------------------------------

        public async Task<IActionResult>GetNameDropdown(int LeaveID)
        {
            var Status = await _db.Leaves.Where(t => t.Isdeleted == false && t.Id == LeaveID).Select(t => new Status_Model
            {
                Id = t.Id,
                StudentName = t.Name,
                USNDropdown = t.Usn,
                Reason = t.Reason,
                Status = t.Approved
            }).FirstOrDefaultAsync();

            return new JsonResult(Status);
        }

    }
}
