using Microsoft.AspNetCore.Mvc;
using NetDevChallange.Business.Abstract;
using NetDevChallange.Entities.Concrete;

namespace NetDevChallange.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.Add(user);
                return RedirectToAction("Index", "Chat");
            }
            return View(user);
        }
    }
}
