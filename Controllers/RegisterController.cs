using ETicaret.DB;
using System.Linq;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    public class RegisterController : Controller
    {
        private ETicaretEntities context;

        public RegisterController()   // Entitiy ile code first yaptığımız Data base'i inşa method ile oluşturalım.
        {
            context = new ETicaretEntities();
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (Session["LogonUser"] != null)
            {
                return RedirectToAction("Index");
            }
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult KullanıcıEkle(DB.Members üye)
        {
            DB.Members userlar = context.Members.FirstOrDefault(x => x.Email == üye.Email);
            var list = context.Members.ToList();
            if (userlar != null)
            {
                return PartialView("_HaveNotUser", list);
            }
            else
            {
                context.Members.Add(üye);
                context.SaveChanges();

                return PartialView("_HaveUser", list);
            }
        }
    }
}