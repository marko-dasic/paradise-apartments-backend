using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class ReportLineDto : BaseDto
    {
        public  string Name { get; set; }
    }
    public class CreateReportLineDto
    {
        public string Name { get; set; }
    }
    public class ReportDto : BaseDto
    {
        public string Text { get; set; }
        public int  ApartmentId { get; set; }
        public int UserId { get; set; }
        public int ReportLineId{ get; set; }
    }
    public class CreateReportDto
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public string Text { get; set; }
        public int ApartmentId { get; set; }
        public int ReportLineId { get; set; }

    }
    public class GetReportDto : BaseDto
    {
        public string Text { get; set; }
        public string TitleApartment { get; set; }
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
        public int ReportLineId { get; set; }
        public string RepotLineText{ get; set; }
    }


}
