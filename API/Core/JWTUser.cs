using Apartment.Domain;
using Apartment.Domain.Entities;
using System.Collections.Generic;

namespace API.Core
{
    public class JwtUser : IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public IEnumerable<int> UseCasesIds { get; set; }

    }

    public class AnonimousUser : IUser
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = "Anonimo";
        public string LastName { get; set; } = "Anonimo";
        public string Phone { get; set; }
        public string Email { get; set; } = "anonimo@anonimo.com";
        public IEnumerable<int> UseCasesIds { get; set; } = new List<int> { 2,11,12,13,14,15,16,18,19,20,51,52,53,54,55,56,57,58,59,60};
        
    }


}
