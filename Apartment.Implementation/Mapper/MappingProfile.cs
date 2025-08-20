using Apartment.Application.UseCase.DTO;
using Apartment.Domain.Entities;
using AutoMapper;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.UseCases, opt => opt.MapFrom(src => new List<UseCaseDto>(src.UseCases.Select(t => new UseCaseDto { Id = t.Id, UseCaseId = t.UseCaseId}))));
            /* .ForMember(dest => dest.Rates, opt => opt.MapFrom(src => src.Rates
                 .Select(t => new { t.Id, t.ApartmentId, t.Value })))
             .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations
                 .Select(t => new { t.Id, t.From, t.To, t.IsPaid, t.ApartmentId })))
             .ForMember(dest => dest.Reports, opt => opt.MapFrom(src => src.Reports
                 .Select(t => new { t.Id, t.ApartmentId, t.ReportLineId})))
             .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments
                 .Select(t => new { t.Id, t.Text, t.AppartmentId })));*/
            CreateMap<Domain.Entities.Apartment, ApartmentDto>();
            CreateMap<Domain.Entities.Specification, SpecificationDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Domain.Entities.ReportLine, ReportLineDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Domain.Entities.Report, GetReportDto>()
                .ForMember(dest => dest.RepotLineText, opt => opt.MapFrom(src => src.ReportLine.Name))
                .ForMember(dest => dest.TitleApartment, opt => opt.MapFrom(src => src.Apartment.Title));

            CreateMap<Domain.Entities.Reservation, ReservationDto>()
                   .ForMember(dest => dest.ApartmentId, opt => opt.MapFrom(src => src.ApartmentId))
                   .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Apartment.Title))
                   .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                   .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User == null ? src.FullName : src.User.FirstName + " " + src.User.LastName))
                   .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.User == null ? src.Phone : src.User.Phone))
                   .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.From))
                   .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.To))
                   .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                   .ForMember(dest => dest.IsPaid, opt => opt.MapFrom(src => src.IsPaid))
                   .ForMember(dest => dest.NumPerson, opt => opt.MapFrom(src => src.NumPerson))
                   .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                   .ForMember(dest => dest.Cancelled, opt => opt.MapFrom(src => src.Cancelled));


        }

    }

}
