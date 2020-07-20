using ETicaret.DB;
using ETicaret.Models.Index;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    public class IndexController : Controller
    {
        private ETicaretEntities context;

        public IndexController()   // Entitiy ile code first yaptığımız Data base'i inşa method ile oluşturalım.
        {
            context = new ETicaretEntities();
        }

        public ActionResult Index()
        {
            IndexModel viewModel = new IndexModel()
            {
                Categories = context.Categories.ToList()
            };
            return View(viewModel);
        }
    }
}