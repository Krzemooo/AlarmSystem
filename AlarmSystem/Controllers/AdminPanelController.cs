using AlarmSystem.Core;
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
            var result = await _alarmSystemCore.GetAlarmSystemsAsync();
            return View(result);
        }

        public async Task<IActionResult> Objects()
        {
            var _alarmObjectCore = new Core.AlarmObjectCore(_context);
            var result = await _alarmObjectCore.GetAlarmObjectsAsync();
            return View(result);
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
    }
}
