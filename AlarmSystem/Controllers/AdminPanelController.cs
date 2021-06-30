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
    public class AdminPanelController : Controller
    {
        private readonly ILogger<AdminPanelController> _logger;
        private readonly DBContext _context;
        public AdminPanelController(ILogger<AdminPanelController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Users()
        {
            var _userCore = new Core.UserCore(_context);
            var result = await _userCore.GetUsersAsync();
            return View(result);
        }

        public async Task<IActionResult> Systems()
        {
            var _alarmSystemCore = new Core.AlarmSystemCore(_context);
            var _alarmObjectCore = new Core.AlarmObjectCore(_context);
            var result = await _alarmSystemCore.GetAlarmSystemsAsync();
            var objects = await _alarmObjectCore.GetAlarmObjectsAsync();

            AlarmSystemViewModel model = new AlarmSystemViewModel()
            {
                ItemList = result,
                ObjectList = objects
            };
            return View(model);
        }

        public async Task<IActionResult> Objects()
        {
            var _userCore = new Core.UserCore(_context);
            var _alarmObjectCore = new Core.AlarmObjectCore(_context);
            var result = await _alarmObjectCore.GetAlarmObjectsAsync();
            var userList = await _userCore.GetOnwersAsync();

            AlarmObjectViewModel model = new AlarmObjectViewModel()
            {
                ItemList = result,
                UserList = userList
            };

            return View(model);
        }

        public async Task<IActionResult> Zones()
        {
            var _alarmZoneCore = new Core.AlarmZoneCore(_context);
            var result = await _alarmZoneCore.GetAlarmZonesAsync();
            return View(result);
        }

        public async Task<IActionResult> InputOutputs()
        {
            var _inputOutputCore = new Core.InputOutputCore(_context);
            var result = await _inputOutputCore.GetInputOutputsAsync();
            return View(result);
        }

        public async Task<IActionResult> Scenerios()
        {
            var _alarmScenerioCore = new Core.AlarmScenerioCore(_context);
            var result = await _alarmScenerioCore.GetAlarmSceneriosAsync();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UserForm(UserFormModel model)
        {
            if (!model.Id.HasValue)
            {
                var _userCore = new Core.UserCore(_context);
                await _userCore.InsertUserAsync(new Core.Models.User()
                {
                    Email = model.Email,
                    Role = model.Role,
                    Password = Helper.Crypto.Encrypt(model.Password)
                });
            }

            return Redirect("Users");
        }

        [HttpPost]
        public async Task<IActionResult> SystemForm(SystemFormModel model)
        {
            if (!model.ID.HasValue)
            {
                var _alarmSystemCore = new Core.AlarmSystemCore(_context);
                var _alarmObjectCore = new Core.AlarmObjectCore(_context);
                var _object = await _alarmObjectCore.GetAlarmObjectAsync(model.ObjectID);
                await _alarmSystemCore.InsertAlarmSystemAsync(new Core.Models.AlarmSystem()
                {
                    AlarmObject = _object,
                    SystemName = model.Name
                });
            }

            return Redirect("Systems");
        }

        [HttpPost]
        public async Task<IActionResult> ObjectForm(ObjectFormModel model)
        {
            if (!model.ID.HasValue)
            {
                var _alarmObjectCore = new Core.AlarmObjectCore(_context);
                var _userCore = new Core.UserCore(_context);
                var _owner = await _userCore.GetUserAsync(model.OwnerID);
                await _alarmObjectCore.InsertAlarmObjectAsync(new Core.Models.AlarmObject()
                {
                    ObjectOwner = _owner,
                    ObjectName = model.Name
                });
            }

            return Redirect("Objects");
        }
    }
}
