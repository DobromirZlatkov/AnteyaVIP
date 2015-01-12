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

    using Model = AnteyaVIP.Models.Order;
    using ViewModel = AnteyaVIP.Web.Areas.Administration.ViewModels.Orders.OrderViewModel;

    public class OrdersController : KendoGridAdministrationController
    {
        private readonly ICacheService service;

        public OrdersController(IAnteyaVIPData data, ICacheService service)
            : base(data)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
           

            return this.Data
                .Orders
                .All()
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Orders.GetById(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null) model.Id = dbModel.Id;
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model.Id == null)
            {
                this.Create(request, model);
            }
            else
            {
                base.Update<Model, ViewModel>(model, model.Id);
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var order = this.Data.Orders.GetById(model.Id.Value);
                foreach (var orderDetail in order.OrderDetails.Select(o => o.Id).ToList())
                {
                    this.Data.OrderDetails.Delete(orderDetail);
                } 

                this.Data.Orders.Delete(order);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}