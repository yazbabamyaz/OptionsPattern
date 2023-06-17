using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OptionsPattern.Models;
using System.Reflection;

namespace OptionsPattern.Controllers
{
    public class OptionsController : Controller
    {
        private readonly IConfiguration _configuration;
        public OptionsController(IConfiguration configuration)
        {    
            _configuration= configuration;  
           
        }
        public IActionResult Index()
        {
            //Options Pattern kullanmadan verileri aşağıdaki şekilde okuyabiliriz
            //IConfiguration ile appsetting.json okuma işlemi:
            var options = new List<string>();
            options.Add(_configuration["Teacher:Name"]);
            options.Add(_configuration["Teacher:No"]);
            //aynı işlemi şu şekilde de (GetSection ile) yapabilirdik.
            string teacherName = _configuration.GetSection("Teacher:Name").Value;

            //Eğer verileri bir nesne olarak getireceksen Get metodu kullanabiliriz.
            //appsettings.json daki verileri karşılayacak model-class- oluşturmalıyız. (Teacher class)
            Teacher teacher = _configuration.GetSection("Teacher").Get<Teacher>();


            return View();
        }
    }
}
