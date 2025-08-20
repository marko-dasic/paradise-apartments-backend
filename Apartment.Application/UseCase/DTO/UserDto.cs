using Apartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class UserDto : BaseDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
      //  public string Password { get; set; }
        public string Phone { get; set; }

       // public int? CityId { get; set; }

      //  public  City City { get; set; }
        public  IEnumerable<UseCaseDto> UseCases { get; set; }
      /*  public  IEnumerable<Report> Reports { get; set; }
        public  IEnumerable<Comment> Comments { get; set; }
        public  IEnumerable<Rate> Rates { get; set; }
        public  IEnumerable<Reservation> Reservations { get; set; }*/
    }
    public class CreateUserDto
    {
        public string Email { get; set; } //Required, Regex, Unique
        public string Phone { get; set; } //Required

        public string FirstName { get; set; } //Required, Regex
        public string LastName { get; set; } //Required, Regex
        public string Password { get; set; } //Required, min|max, Regex
    }
    public class UpdateUserDto :BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int? CityId { get; set; }
        public  IEnumerable<int> UseCaseIds { get; set; }
    }

    public class FilterPaginationUserDto
    {
        public string FullName { get; set; }
        public DateTime CreatedAtFrom { get; set; }
        public DateTime CreatedAtTo { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
