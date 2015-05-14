using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VGGLinkedIn.Web.Areas.Administration.Controllers
{
    using VGGLinkedIn.Data;
    using VGGLinkedIn.Web.Controllers;

    public class UsersController : AdministrationController
    {
        public UsersController(IVggLinkedInData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}