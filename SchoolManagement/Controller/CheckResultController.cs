using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController] 
    public class CheckResultController : ControllerBase
    {

        public readonly SchoolManagementContext _db;
        public CheckResultController(SchoolManagementContext db)
        {
            _db = db; 
        }

        //-------------------------------------API CREATIONS------------------------------------------


        //-------------------------------------Name with respect to USN--------------------------------------------

        public async Task<IActionResult> GetNameDropdown(int StudentDetailid)
        {
            var check = await _db.StudentDetails.Where(t => t.IsDeleted == false && t.Id == StudentDetailid).Select(t => new checkResult_Model
            {
                Id = t.Id,
                ResultId = t.ResultEntryid,
                SubjectId = t.SubjectId,
                MarksId = t.MarksId,


                
                StudentName = t.Name,
                Usn = t.Usn,
                Phonenumber = t.Phone, 
                Email = t.Email,
                Address = t.Address,
                Class = t.Class,
                Result = t.ResultEntry.Result,
                Subject = t.Subject.SubjectName,
                Marks = t.Marks.Marks,
                TotalMarks = t.ResultEntry.TotalMakes,
                PassinMarks = t.ResultEntry.PassingMarks



            }).FirstOrDefaultAsync();

            return new JsonResult(check);

        }
    }
}
