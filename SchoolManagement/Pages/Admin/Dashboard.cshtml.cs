using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchoolManagement.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;

        public DashboardModel(ILogger<DashboardModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetInt32(SD.RoleId)!=SD.Admin)
            {
                return RedirectToPage("/Logout");
            }


            return Page();
        }
    }
}