using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using scheduler.Models;

namespace scheduler.Controllers
{
    public class SchedulerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ILogger _logger;

        public SchedulerController(UserManager<ApplicationUser> userManager, ILoggerFactory loggerFactory) 
        {
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<SchedulerController>();
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var user = await GetCurrentUserAsync();

            _logger.LogInformation(1, "Oh man all kinds of text just please work." + user);
            
            if (user != null) {
                return View(); 
            }
            return RedirectToAction(nameof(AccountController.Login));          
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

    }
}