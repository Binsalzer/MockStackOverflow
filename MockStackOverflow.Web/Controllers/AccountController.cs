using Microsoft.AspNetCore.Mvc;
using MockStackOverflow.Data;

namespace MockStackOverflow.Web.Controllers
{
    public class AccountController : Controller
    {
        private string _connectionString;

        public AccountController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            var repo = new AuthorizationRepository(_connectionString);
            repo.AddUser(user);
            return Redirect("/account/login");
        }
    }
}
