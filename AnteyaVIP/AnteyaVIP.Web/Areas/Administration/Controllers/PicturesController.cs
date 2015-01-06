namespace AnteyaVIP.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Web;
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


    using Model = AnteyaVIP.Models.Picture;
    using ViewModel = AnteyaVIP.Web.Areas.Administration.ViewModels.Pictures.PictureViewModel;

    public class PicturesController : AdminController
    {

        public PicturesController(IAnteyaVIPData data)
            : base(data)
        {
        }
        // GET: Administration/Pictures
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read_ProductPictures(int productId, [DataSourceRequest]DataSourceRequest request)
        {
            var ads = this.Data.Pictures.All()
                .Where(c => c.ProductId == productId)
                .Project()
                .To<ViewModel>();
                
                //foreach (var item in ads.ToList())
                //{
                //    this.Picture(item.Id);
                //}

            return this.Json(ads.ToDataSourceResult(request));
        }

        public ActionResult Upload(int productId, IEnumerable<HttpPostedFileBase> UploadedFiles)
        {
            var currentProduct = this.Data.Products.GetById(productId);

            if (UploadedFiles != null)
            {
                foreach (var image in UploadedFiles)
                {
                    var currentImage = new Model
                    {
                        File = image,
                        FileExtension = image.FileName.Split(new[] { '.' }).Last()
                    };

                    currentProduct.Pictures.Add(currentImage);
                }
                this.Data.SaveChanges();
            }

           // Values.Pictures = currentProduct.Pictures;
            return Content("");
        }

        public ActionResult Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            //if (fileNames != null)
            //{
            //    foreach (var fullName in fileNames)
            //    {
            //        //var fileName = Path.GetFileName(fullName);
            //        //var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

            //        // TODO: Verify user permissions

            //        if (System.IO.File.Exists(physicalPath))
            //        {
            //            // The files are not actually removed in this demo
            //            // System.IO.File.Delete(physicalPath);
            //        }
            //    }
            //}

            //// Return an empty string to signify success
            return Content("");
        }

        public ActionResult Picture(int id)
        {
            var image = this.Data.Pictures.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.PictureAsByteArray, "image/" + image.FileExtension);
        }
    }
}