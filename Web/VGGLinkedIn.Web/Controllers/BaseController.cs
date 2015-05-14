namespace VGGLinkedIn.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Microsoft.AspNet.Identity;

    using VGGLinkedIn.Data;
    using VGGLinkedIn.Data.Models;
    using System.Collections.Generic;

    using VGGLinkedIn.Common.SystemMessages;

    public abstract class BaseController : Controller
    {

        protected BaseController(IVggLinkedInData data)
        {
            this.Data = data;
        }

        protected BaseController(IVggLinkedInData data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected IVggLinkedInData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            
            
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.GetUserName();
                this.UserProfile = this.Data.Users
                    .All()
                    .FirstOrDefault(x => x.UserName == username);
            }

            var result = base.BeginExecute(requestContext, callback, state);

            if (!requestContext.HttpContext.Request.IsAjaxRequest())
            {
                // This should be after base.BeginExecute so we can access TempData
                var systemMessages = this.PrepareSystemMessages();
                this.ViewBag.SystemMessages = systemMessages;
            }

            return result;
        }

        private object PrepareSystemMessages()
        {
            var messages = new List<SystemMessage>();
            if (this.TempData.ContainsKey(SystemMessageType.Information.ToString()))
            {
                messages.Add(new SystemMessage
                {
                    Content = this.TempData[SystemMessageType.Information.ToString()].ToString(),
                    Type = SystemMessageType.Information
                });
            }

            return messages;
        }
    }
}