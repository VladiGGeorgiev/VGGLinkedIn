namespace VGGLinkedIn.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using VGGLinkedIn.Data;
    using VGGLinkedIn.Data.Models;
    using VGGLinkedIn.Web.InputModels;
    using VGGLinkedIn.Web.ViewModels.Common;

    public class GroupsController : BaseController
    {
        public GroupsController(IVggLinkedInData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            var groupTypes = DropdownViewModel.GetEnumValues<GroupType>();
            this.ViewBag.GroupTypes = groupTypes;
            // TODO: Show all groups
            return this.View();
        }

        [HttpGet]
        public ActionResult Create()
        {

            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Create(GroupInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}