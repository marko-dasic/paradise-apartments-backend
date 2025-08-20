using Apartment.Application.Calendar;
using Apartment.Application.Exceptions;
using Apartment.Application.Mail;
using Apartment.Application.UseCase.Commands.Apartment;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using Apartment.Domain;
using Apartment.Domain.Entities;
using Apartment.Implementation.UseCase.Calendar;
using Apartment.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Apartment
{
    public class CreateReservationCommadn : EfBase, ICreateReservationsCommand
    {
        private string adminEmail = "markodasic70@gmail.com";
        private IEmailSend emailSender;
        private IUser user;
        private IWebHostEnvironment _environment;
        private CreateReservationValidator validator;
        private int taxForWashing = 15;
        private CalendarManager calendarManager;
        public CreateReservationCommadn(IWebHostEnvironment _environment,CreateReservationValidator validator,ApartmentContext context, IMapper mapper, IEmailSend email, IUser user, ICalendarManager calendarManager) : base(context, mapper)
        {
            this.user = user;
            this.validator = validator;
            this.emailSender = email;
            this.calendarManager = calendarManager as CalendarManager;
            this._environment = _environment;
        }

        public int Id => 56;

        public string Name => "Create Reservation - EF";

        public string Description => "";

        public void Execute(CreateReservationDto request)
        {
            if (request is null) throw new BadRequestException();
    
            validator.ValidateAndThrow(request);
    
            var apartment = Context.Apartments.Find(request.ApartmentId);
    
            if (apartment.MinPerson > request.NumPerson) throw new BadRequestException();
            if (apartment.MaxPerson < request.NumPerson) throw new BadRequestException();
            if (!calendarManager.CheckDates(apartment.LocalCalendar, request.From, request.To)) throw new FluentValidation.ValidationException("Apartmani je zauzet u traženom terminu",new List<ValidationFailure>{ new ValidationFailure("Apartmani je zauzet u traženom terminu","Apartmani je zauzet u traženom terminu")});
            if (!calendarManager.CheckDates(apartment.RemoteCalendar, request.From, request.To)) throw new FluentValidation.ValidationException("Apartmani je zauzet u traženom terminu",new List<ValidationFailure>{ new ValidationFailure("Apartmani je zauzet u traženom terminu","Apartmani je zauzet u traženom terminu")});
            var x = request.From; // Provera da li je korisnik rezervisao min Dva dana
            var y = request.To;
            if (x.AddDays(1) >= y) throw new FluentValidation.ValidationException("Apartmani je zauzet u traženom terminu",new List<ValidationFailure>{ new ValidationFailure("Apartmani mora biti rezervisan minimum na 2 dana!","Apartmani je zauzet u traženom terminu")});
            
            calendarManager.AddDates(apartment.LocalCalendar, request.From, request.To);
    
            double sumPrice = CalculateSumPrice(request);
            sumPrice += taxForWashing;
    
            if (request.UserId != null && request.UserId.Value == 0) request.UserId = null;

            var newReservation = new Domain.Entities.Reservation
            {
                ApartmentId = request.ApartmentId,
                UserId = request.UserId,
                From = request.From,
                To = request.To,
                FullName = request.FullName,
                Phone = request.Phone,
                Amount = sumPrice,
                IsPaid = false,
                NumPerson = request.NumPerson,
                CreatedAt = DateTime.Now
            };
            var from = newReservation.From;
            var to = newReservation.To.Value;
            from.AddHours(14);
            to.AddHours(11);

            string fileName = Path.Combine(_environment.ContentRootPath,"uploads/mail/customer.html");
            string htmlBody = System.IO.File.ReadAllText(fileName);
            htmlBody = htmlBody.Replace("{id-rezervacije}", newReservation.CreatedAt.ToString());
            htmlBody = htmlBody.Replace("{ime-apartmana}", apartment.Title);
            htmlBody = htmlBody.Replace("{datum-od}", from.ToString());
            htmlBody = htmlBody.Replace("{datum-do}", to.ToString());
            htmlBody = htmlBody.Replace("{lokacija}", apartment.Street + " " + apartment.StreetNumber);
            htmlBody = htmlBody.Replace("{suma}", newReservation.Amount.ToString());

            if (!string.IsNullOrEmpty(request.Email) || this.user != null)
            {
                string emailToSend = this.user.Id == 0 ? request.Email : this.user.Email;
                this.emailSender.Send(new MailDto
                {
                    Title = "Potvrda Rezervacije - Confirmation Of Booking",
                    To = emailToSend,
                    Message = htmlBody
                });
            }

            string fileNameAdmin = Path.Combine(_environment.ContentRootPath,"uploads/mail/admin.html");
            string htmlBodyAdmin = System.IO.File.ReadAllText(fileNameAdmin);
            htmlBodyAdmin = htmlBodyAdmin.Replace("{id-rezervacije}", newReservation.CreatedAt.ToString());
            htmlBodyAdmin = htmlBodyAdmin.Replace("{apartman}", apartment.Title);
            htmlBodyAdmin = htmlBodyAdmin.Replace("{datum-od}", from.ToString());
            htmlBodyAdmin = htmlBodyAdmin.Replace("{datum-do}", to.ToString());
            htmlBodyAdmin = htmlBodyAdmin.Replace("{ime-apartmana}", apartment.Title);
            htmlBodyAdmin = htmlBodyAdmin.Replace("{suma}", newReservation.Amount.ToString());
            htmlBodyAdmin = htmlBodyAdmin.Replace("{ime-korisnika}", this.user.Id == 0 ? request.FullName : this.user.FirstName + " " + this.user.LastName);
            htmlBodyAdmin = htmlBodyAdmin.Replace("{email-korisnika}", this.user.Id == 0 ? request.Email : this.user.Email);
            htmlBodyAdmin = htmlBodyAdmin.Replace("{telefon-korisnika}", this.user.Id == 0 ? request.Phone : this.user.Phone);
            this.emailSender.Send(new MailDto
            {
                Title = "Nova Rezervacija",
                To = this.adminEmail,
                Message = htmlBodyAdmin
            });
            Context.Reservations.Add(newReservation);
            Context.SaveChanges();
            
        }
        
        private double CalculateSumPrice(CreateReservationDto request)
        {
            // Unos cena za dane odredjene sezone i praznike
            var apartment = Context.Apartments.Where(x => x.Id == request.ApartmentId).Select(x => new ApartmentDto
            {
                Id = x.Id,
                MinPerson = x.MinPerson,
                MaxPerson = x.MaxPerson,
                PricePerPerson = x.PricePerPerson,
                Price = new PriceDto{
                 PricePerNight = x.Prices.OrderByDescending(y=>y.CreatedAt).FirstOrDefault().PricePerNight,
                 PriceOnHoliday = x.Prices.OrderByDescending(y=>y.CreatedAt).FirstOrDefault().PriceOnHoliday,
                },
                SpecPrices = x.SpecPrices.Select(y=> new SpecPriceGetDto
                {
                    Price = y.Price,
                    Date = y.Date
                }) 
            }).FirstOrDefault();

            var price = apartment.Price;
            double priceSummer = price.PricePerNight;
            double priceWinter = price.PriceOnHoliday;
            double priceNewYear = price.PriceOnNewYear;
            DateTime dateStart = request.From;
            DateTime dateEnd = request.To.Value;
            DateTime currentDate = dateStart;
            double sumPrice = 0;
            double priceForManyPereson = CalculatePriceFromPerson(request, apartment); // Racunamo povecanje cene usled povecanog broja ljudi

            while (currentDate < dateEnd)
            {
                // Provera da li je trenutni dan u zimskoji ili letnjoji sezoni
                bool newYear = currentDate.DayOfYear > 363 || currentDate.DayOfYear < 3;
                bool summer = currentDate.Month > 4 && currentDate.Month < 10;
                // Provera da li je trenutni dan praznik
                var  praznik = apartment.SpecPrices.FirstOrDefault(x=> x.Date.DayOfYear == currentDate.DayOfYear);
                // Odabir cene na osnovu sezone i praznika
                if (praznik != null)
                {
                    sumPrice += praznik.Price;
                }
                else if(summer)
                {
                    sumPrice += priceSummer;
                }
                else if(newYear)
                {
                    sumPrice += priceNewYear;
                }
                else
                {
                    sumPrice += priceWinter;
                }
                sumPrice += priceForManyPereson; // Dodajemo poskupljenje na ukupnu cenu ukoliko ima vise osoba od minimalnog broja osoba po apartmanu
                // Prelazak na sledeći dan
                currentDate = currentDate.AddDays(1);
            }
            return sumPrice;
        }

        //Ovaj metod vrac odgovarajucu cenu u zavnisnosti od broja gostiju za koje se rezervise apartman
        private double CalculatePriceFromPerson(CreateReservationDto request, ApartmentDto apartment)
        {
            double price = 0; 
            int numPerson= request.NumPerson;
            if (apartment.MinPerson == numPerson)
            {
                return price;
            }
            else
            {
                int x = numPerson - apartment.MinPerson;
                for(int i = 0; i<x; i++)
                {
                    price += apartment.PricePerPerson;
                }
                return price;

            }
        }
    }
}
