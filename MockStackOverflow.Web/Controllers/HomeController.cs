using Microsoft.AspNetCore.Mvc;
using MockStackOverflow.Data;
using MockStackOverflow.Web.Models;
using System.Diagnostics;

namespace MockStackOverflow.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;
        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        public IActionResult Index()
        {
            var repo = new QuestionsRepository(_connectionString);
            var vm = new IndexViewModel { Questions = repo.GetAllQuestions() };
            return View(vm);
        }

    }
}