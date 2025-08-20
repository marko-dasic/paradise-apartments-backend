using Apartment.Application.Calendar;
using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Apartment;
using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Apartment;
using Apartment.DataAccess;
using Apartment.Domain;
using Apartment.Domain.Entities;
using Apartment.Implementation.UseCase.Calendar;
using Apartment.Implementation.UseCase.UploadImages;
using Apartment.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Apartment
{
    public class CreateApartmentCommand : EfBase, ICreateApartmentCommand
    {
        private CreateApartmentValidator validatorApartment;
        private AddPriceForApartmentValidator validatorPrice;
        private UploaderImages uploader;
        private IUser author;
        private readonly CalendarManager calendarManager;
     
        public CreateApartmentCommand(Implementation.UseCase.UploadImages.UploaderImages uploader, ApartmentContext context, IMapper mapper, IUser author, CreateApartmentValidator validatorApartment, AddPriceForApartmentValidator validatorPrice, ICalendarManager calendarManager) : base(context, mapper)
        {
            this.validatorApartment = validatorApartment;
            this.validatorPrice = validatorPrice;
            this.author = author;
            this.uploader = uploader;
            this.calendarManager = calendarManager as CalendarManager;
        }

        public int Id => 5;

        public string Name => "Create Apartment - EF";

        public string Description => "";

        public void Execute(CreateApartmentDto request)
        {
            if (request is null) throw new BadRequestException();
            if (request.Priority == 0) request.Priority = 3;
            validatorApartment.ValidateAndThrow(request);
            validatorPrice.ValidateAndThrow(request.Price);

            var specification = request.Specification.Select(x => new ApartmentSpecification
            {
                SpecificationId = x.SpecificationId,
                Value = x.Value,
            });

            var localCalendar = this.calendarManager.CreateCalendar();


            var newApartment = new Domain.Entities.Apartment
            {
                Title = request.Title,
                Description = request.Description,
                CordinateX = request.CordinateX,
                CordinateY = request.CordinateY ,
                GoogleMap = request.GoogleMap,
                UserId = author.Id,
                CategoryId = request.CategoryId,
                CityId = request.CityId,   
                Priority = request.Priority,
                Surface = request.Surface,
                ApartmentSpecifications = specification.ToList(),
                Floor = request.Floor,
                RoomId = request.RoomId,
                WiFi = request.WiFi,
                Garage = request.Garage,
                PricePerPerson = request.PricePerPerson,
                MinPerson = request.MinPerson,
                MaxPerson = request.MaxPerson,
                Street = request.Street,
                StreetNumber = request.StreetNumber,
                RemoteCalendar = request.RemoteCalendar,
                LocalCalendar = localCalendar
            };



            /*ADDING THUMB FILE*/
            uploader.UploadImages(new List<string> { request.File },newApartment, true);
            /*END THUMB FILE*/

            /*ADDING OTHER IMAGES*/
            uploader.UploadImages(request.Images, newApartment, false);
            /*END ADDING OTHER IMAGES*/

            /*ADDING PRICE*/
            var newPrice = new Price
            {
                Apartment= newApartment,
                PriceOnHoliday = request.Price.PriceOnHoliday,
                PricePerNight = request.Price.PricePerNight,
                PriceOnNewYear = request.Price.PriceOnNewYear
            };
            newApartment.Prices = new List<Domain.Entities.Price>();
            newApartment.Prices.Add(newPrice);
            /*END ADDING PRICE*/

            /*ADDING SPECPRICE*/
            var newSpecPrice = request.SpecPrices.Select(x => new SpecPrice { Date = x.Date, Price = x.Price, Apartment = newApartment, PricePerPerson = x.PricePerPerson });
            newApartment.SpecPrices = newSpecPrice.ToList();
            /*END ADDING SPECPRICE*/

            /*ADDING APARTMENT*/
            Context.Apartments.Add(newApartment);
            Context.SaveChanges();
            /*END APARTMENT*/
        }

       
    }
}
