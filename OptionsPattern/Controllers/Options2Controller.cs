using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPattern.Models;

namespace OptionsPattern.Controllers
{
    public class Options2Controller : Controller
    {
        //private readonly IOptions<Teacher> _teacher;
        private readonly Teacher _teacher;
        public Options2Controller(IOptions<Teacher> teacher)
        {
            //program.cs de options pattern i configure ettim.            
            //class property leri ile apsettings.json içindeki veriler birebir aynı olmalı.            
            _teacher = teacher.Value;
        }
        public IActionResult Index()
        {
            //Options Pattern kullanarak IConfiguration dan okuma yerine IOptions interface'inden okuma yapcaz 
            ViewBag.Name=_teacher.Name;
            ViewBag.No=_teacher.No;
            return View();
        }
    }
}
