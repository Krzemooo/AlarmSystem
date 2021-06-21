using AlarmSystem.Core;
using AlarmSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlarmSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly DBContext _context;

        public AccountController(ILogger<AccountController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserLogin(LoginFormModel form)
        {
            UserCore userCore = new UserCore(_context);
            string _role = await userCore.Login(form.Email, form.Password);
            switch(_role)
            {
                case "admin":
                    return RedirectToAction("Index", "AdminPanel");
                case "user":
                    return RedirectToAction("Index", "UserPanel");

                default: return NotFound();
            }
        }
    }
}
