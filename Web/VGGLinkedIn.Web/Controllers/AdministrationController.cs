namespace VGGLinkedIn.Web.Controllers
{
    using System.Web.Mvc;

    using VGGLinkedIn.Common.Constants;
    using VGGLinkedIn.Data;
    using VGGLinkedIn.Data.Models;

    [Authorize(Roles = GlobalConstants.RoleNameAdministrator)]
    public abstract class AdministrationController : BaseController
    {
        protected AdministrationController(IVggLinkedInData data) : base(data)
        {
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.Data.AdministrationLogs.Add(
                new AdministrationLog
                {
                    IpAddress = this.Request.UserHostAddress,
                    Url = this.Request.RawUrl,
                    UserId = this.UserProfile.Id,
                    RequestType = this.Request.RequestType,
                    PostParams = this.Request.Form.ToString(),
                });

            this.Data.SaveChanges();

            base.OnActionExecuted(filterContext);
        }
    }
}