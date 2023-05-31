using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.CommonModel;
using SchoolManagement.Models;

namespace SchoolManagement.Pages.Student
{
    public class leaveStatusModel : PageModel
    {

        public readonly SchoolManagementContext _db;
        public leaveStatusModel (SchoolManagementContext db)
        {
            _db = db;

        }

        public IEnumerable<LeaveStatus_Model> LeaveStatusDatalist { get; set; }
        public List<SelectListItem> optionNameDropdown { get; set; }
        public List<SelectListItem> optionUSNDropdown { get; set; }

        [BindProperty]
        public int LeaveID { get; set; }


        [BindProperty]
        public LeaveStatus leaveStatus { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32(SD.RoleId) != SD.Student)
            {
                return RedirectToPage("/Logout");
            }

            LeaveStatusDatalist = _db.LeaveStatuses.Where(c => c.Isdeleted == false).Select(c => new LeaveStatus_Model
            {
                Id = c.Id,

                NameDropdown = c.Leave.Name,
                USNDropdown = c.Leave.Usn,
                  Reason = c.Leave.Reason,
                Approved = c.Leave.Approved

            }).ToList();
            leaveStatus = new LeaveStatus();

            if (id.HasValue)
            {
                var checks = _db.LeaveStatuses.Where(c => c.Id == id && c.Isdeleted == false).FirstOrDefault();
                if (checks == null)
                {
                    return Page();

                }
                leaveStatus = checks;
            }

            #region----------DDL get Method for USNDropdown---------


            optionUSNDropdown = _db.Leaves.Where(t => t.Isdeleted == false).Select(t => new SelectListItem
            {

                Value = t.Id.ToString(),
                Text = t.Usn,


            }).ToList();

            if (leaveStatus?.LeaveId > 0)
            {
                var tea = _db.Leaves.Where(t => t.Id == leaveStatus.LeaveId).Select(t => t).FirstOrDefault();
                optionUSNDropdown.Insert(0, new SelectListItem
                {
                    Text = tea?.Usn,
                    Value = tea?.Id.ToString()

                });

            }



            else
            {
                optionUSNDropdown.Insert(0, new SelectListItem()
                {
                    Text = "-------Select your USN---------",
                    Value = string.Empty


                });
            }

            List<Leave> listobjle = new List<Leave>();
            listobjle = (from leobj in _db.Leaves where leobj.Id == LeaveID select leobj).ToList();


            #endregion

            #region----------DDL get Method for NameDropdown---------

            optionNameDropdown = _db.Leaves.Where(t => t.Isdeleted == false).Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name,

            }).ToList();


            if (leaveStatus?.LeaveId > 0)
            {
                var tea = _db.Leaves.Where(t => t.Id == leaveStatus.LeaveId).Select(t => t).FirstOrDefault();
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
            List<Leave> listobjlee = new List<Leave>();
            listobjlee = (from leeobj in _db.Leaves where leeobj.Id == LeaveID select leeobj).ToList();

            #endregion



            return Page();
        }



        public IActionResult OnPost()
        {
            if(leaveStatus.Id>0)
            {
                var Status = _db.LeaveStatuses.AsNoTracking().Where(s => s.Id == leaveStatus.Id && s.Isdeleted == false).FirstOrDefault();
                if(Status == null)
                {
                    return Page();
                }


            leaveStatus.LeaveId = LeaveID;
                leaveStatus.Isdeleted = Status.Isdeleted;
                _db.LeaveStatuses.Update(leaveStatus);
                _db.SaveChanges();
            }

            else
            {
                leaveStatus.LeaveId = LeaveID;
                leaveStatus.Isdeleted = false;
                _db.LeaveStatuses.Add(leaveStatus);
                _db.SaveChanges();

            }

            return Page();
        }

    }
}



