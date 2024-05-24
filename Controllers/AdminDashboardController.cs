using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminCRUDController : Controller
    {
        // GET: AdminCRUDController
        public ActionResult Index()
        {
            return View();
        }
    }
}
