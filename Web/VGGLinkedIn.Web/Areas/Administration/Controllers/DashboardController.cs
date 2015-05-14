namespace VGGLinkedIn.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using VGGLinkedIn.Data;
    using VGGLinkedIn.Web.Areas.Administration.ViewModels.Dashboard;
    using VGGLinkedIn.Web.Controllers;

    public class DashboardController : AdministrationController
    {
        public DashboardController(IVggLinkedInData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var dashboardItems = this.LoadAdministrationDashboardItems();
            return View(dashboardItems);
        }

        private IEnumerable<DashboardItemViewModel> LoadAdministrationDashboardItems()
        {
            var items = new List<DashboardItemViewModel>
            {
                new DashboardItemViewModel("Users", "/Administration/Users/Index")
            };

            return items;
        }
    }
}