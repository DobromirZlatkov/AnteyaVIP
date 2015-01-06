namespace AnteyaVIP.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;
    using System.Globalization;
    using System.Threading;


    using AnteyaVIP.Common.Constants;
    using AnteyaVIP.Data;
    using AnteyaVIP.Web.Controllers.Base;
    using AnteyaVIP.Web.Areas.Administration.ViewModels.Products;

   // [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminController : BaseController
    {
        protected ProductForeignKeyValues Values { get; private set; }

        public AdminController(IAnteyaVIPData data)
            : base(data)
        {
           // Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }
    }
}