using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using DecoratorDesignPatternDemo.Models;
using DecoratorDesignPatternDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DecoratorDesignPatternDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayersService _playersService;

        public HomeController(IPlayersService playersService)
        {
            _playersService = playersService;
        }

        public IActionResult Index()
        {
            return View(_playersService.GetPlayersList());
        } 
    }
}
