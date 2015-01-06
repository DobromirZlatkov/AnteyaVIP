namespace AnteyaVIP.Web.Controllers.Base
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AnteyaVIP.Data;
    using AnteyaVIP.Models;

    using Microsoft.AspNet.Identity;

    public class BaseController : Controller
    {
        protected IAnteyaVIPData Data { get; private set; }

        protected User UserProfile { get; private set; }

        public BaseController(IAnteyaVIPData data)
        {
            this.Data = data;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.Data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}