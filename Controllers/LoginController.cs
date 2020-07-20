using ETicaret.DB;
using System.Linq;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    public class LoginController : Controller
    {
        private ETicaretEntities context;

        public LoginController()   // Entitiy ile code first yaptığımız Data base'i inşa method ile oluşturalım.
        {
            context = new ETicaretEntities();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(DB.Members üye)
        {
            if (context.Members.Any(x => x.Email == üye.Email && x.Password == üye.Password))
            {
                var sesion = context.Members.FirstOrDefault(x => x.Email == üye.Email && x.Password == üye.Password);
                Session["LogonUser"] = sesion;

                return RedirectToAction("Index", "Index");
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Index");
        }
    }
}