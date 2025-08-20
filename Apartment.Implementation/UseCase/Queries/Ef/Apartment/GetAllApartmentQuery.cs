using Apartment.Application.Calendar;
using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Apartment;
using Apartment.DataAccess;
using Apartment.Implementation.UseCase.Calendar;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.Apartment
{
    public class GetAllApartmentQuery : EfBase, IGetAllApartmentsQuery
    {
        private IHttpContextAccessor httpContextAccessor;
        private CalendarManager calendarManager;
        public GetAllApartmentQuery(IHttpContextAccessor httpContextAccessor, ApartmentContext context, IMapper mapper, ICalendarManager calendarManager) : base(context, mapper)
        {
            this.calendarManager = calendarManager as CalendarManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public int Id => 11;

        public string Name => "Get All Apartment - EF";

        public string Description => "";

        public PaginatedApartmentDto Execute(FilterPaginationApartmentDto request)
        {
            var serverDomainName = httpContextAccessor.HttpContext.Request;
            string filePath = $"{serverDomainName.Scheme}://{serverDomainName.Host}/api/uploads/";
          

            var res = Context.Apartments.Include(x => x.CategoryOfApartment)
                .Include(x => x.City)
                .Include(x => x.Author)
                .Include(x => x.Prices)
                .Include(x => x.Thumb)
                .Include(x=>x.Reservations)
                .Include(x => x.Rates).AsQueryable();

            res = res.Where(x=> x.DeletedAt == null);

            if (!string.IsNullOrEmpty(request.Title))
            {
                res = res.Where(x => x.Title.Contains(request.Title));
            }
            if( request.MaxPrice > request.MinPrice )
            {
                res = res.Where(x =>  x.Prices.OrderByDescending(y => y.CreatedAt).First().PricePerNight > request.MinPrice
               && x.Prices.OrderByDescending(y => y.CreatedAt).First().PricePerNight < request.MaxPrice);
            };
            if (request.CategoryIds != null && !request.CategoryIds.Contains(0))
            {
                res = res.Where(x => request.CategoryIds.Contains(x.CategoryId));
            }
            if (request.CityIds !=null  && !request.CityIds.Contains(0))
            {
                res = res.Where(x => request.CityIds.Contains(x.CityId));
            }
            if(request.NumPerson != 0)
            {
                res = res.Where(x=>x.MinPerson <= request.NumPerson && x.MaxPerson >= request.NumPerson);
            }
            if(request.Start != null && request.End != null)
            {
                res = res.Where(x=> calendarManager.CheckDates(x.LocalCalendar, request.Start.Value, request.End) && calendarManager.CheckDates(x.RemoteCalendar, request.Start.Value, request.End));
                res= res.Where(x=> !x.Reservations.Any(y=> request.Start <= y.To &&  request.End >= y.From));
            }
            if(request.Garage.HasValue && request.Garage.Value)
            {
                res = res.Where(x => x.Garage == request.Garage);
            }
            if(request.ApartmentSpecificationIds != null && request.ApartmentSpecificationIds.Any())
            {
                foreach(int x in request.ApartmentSpecificationIds)
                {
                    res = res.Where(ap => ap.ApartmentSpecifications.Any(spec => spec.SpecificationId == x));
                }
            }
            if (request.PageNumber == 0 || request.PageSize == 0)
            {
                request.PageNumber = 1;
                request.PageSize = 6;
            }

            res = res.OrderByDescending(x =>  x.Priority ).ThenByDescending(x=>x.CreatedAt);
            
            int numberApartmnets = res.Where(x=>x.DeletedAt != null).Count();
            var pagination = res.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

            var result = pagination.Select(x => new ApartmentDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                GoogleMap = x.GoogleMap,
                CordinateX = x.CordinateX,
                CordinateY = x.CordinateY,
                User = new UserDto { Id = x.Author.Id, FullName = x.Author.FirstName + x.Author.LastName, Email = x.Author.Email },
                Category = new CategoryDto { Id = x.CategoryId, Name = x.CategoryOfApartment.Name },
                City = new CityDto { Id = x.CityId, Name = x.City.Name },
                File = new FileDto { Id = x.FileId, Alt = x.Thumb.Alt, Path = filePath + x.Thumb.Path, Extension = x.Thumb.Extension, Size = x.Thumb.Size },
                SpecPrices =  x.SpecPrices.Select(x=> new SpecPriceGetDto{ Date = x.Date, Price = x.Price}),
                Price = x.Prices.Where(y => y.ApartmentId == x.Id).OrderByDescending(y => y.CreatedAt).Select(y => new PriceDto
                {
                    Id = y.Id,
                    PricePerNight = y.PricePerNight,
                    PriceOnHoliday = y.PriceOnHoliday,
                    PriceOnNewYear = y.PriceOnNewYear

                }).FirstOrDefault(),
                Rates = x.Rates.Select(y => new RateDto
                {
                    Id = y.Id,
                    Value = y.Value,
                    UserId = y.UserId
                }),
                Surface = x.Surface,
                Priority = x.Priority,
                Floor = x.Floor,
                Garage = x.Garage,
                WiFi = x.WiFi,
                Room = new RoomDto { Id = x.Room.Id, Value = x.Room.Value },
                PricePerPerson = x.PricePerPerson,
                MaxPerson = x.MaxPerson,
                MinPerson = x.MinPerson,
                RemoteCalendar = x.RemoteCalendar,
                Street = x.Street,
                StreetNumber = x.StreetNumber
            }).ToList();

            
            return new PaginatedApartmentDto
            {
                Apartments = result,
                NumberApartments = numberApartmnets
                
            };

        }
    }
}
