namespace AnteyaVIP.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Web.Mvc;
    using System.Linq;

    using AnteyaVIP.Data;
    using AnteyaVIP.Web.Areas.Administration.Controllers.Base;
    using AnteyaVIP.Web.Infrastructure.Caching;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using Model = AnteyaVIP.Models.OrderDetail;
    using ViewModel = AnteyaVIP.Web.Areas.Administration.ViewModels.OrderDetails.OrderDetailViewModel;

    public class OrderDetailsController : KendoGridAdministrationController
    {
        // GET: Administration/OrderDetails
        public OrderDetailsController(IAnteyaVIPData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.OrderDetails.GetById(id) as T;
        }

        protected override IEnumerable GetData()
        {
            return this.Data
               .OrderDetails
               .All()
               .Project()
               .To<ViewModel>();
        }

        [HttpPost]
        public ActionResult Read_OrderDetails(int? orderId, [DataSourceRequest]DataSourceRequest request)
        {
            var ads = this.Data.OrderDetails.All()
                .Where(c => c.OrderId == orderId.Value)
                .Project()
                .To<ViewModel>()
                .ToDataSourceResult(request);

            return this.Json(ads);
        }

        [HttpPost]
        public ActionResult Create(int orderId, [DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var currentOrder = this.Data.Orders.GetById(orderId);
          
            var dbModel = Mapper.Map<Model>(model);
           // currentOrder.Total += dbModel.UnitPrice * dbModel.Quantity; // for non admin part
            currentOrder.OrderDetails.Add(dbModel);
            this.Data.SaveChanges();
            if (dbModel != null) model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.Data.OrderDetails.Delete(model.Id.Value);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}