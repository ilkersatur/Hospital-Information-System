using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.AdminPanel.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("AdminPanel")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
