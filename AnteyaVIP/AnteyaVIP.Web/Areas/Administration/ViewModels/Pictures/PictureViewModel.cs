using AnteyaVIP.Models;
using AnteyaVIP.Web.Areas.Administration.ViewModels.Base;
using AnteyaVIP.Web.Infrastructure.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnteyaVIP.Web.Areas.Administration.ViewModels.Pictures
{
    public class PictureViewModel : IMapFrom<Picture>
    {
        [Key]
        public int Id { get; set; }

        public byte[] PictureAsByteArray { get; set; }

        public string FileExtension { get; set; }

        public int ProductId { get; set; }
    }
}