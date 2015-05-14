namespace VGGLinkedIn.Web.Controllers
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using VGGLinkedIn.Data;

    public class HomeController : BaseController
    {
        public HomeController(IVggLinkedInData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return this.View();
        }
    }
}