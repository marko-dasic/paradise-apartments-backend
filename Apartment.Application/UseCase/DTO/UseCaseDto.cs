using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class UseCaseDto : BaseDto
    {
        public int UseCaseId { get; set; }
    }

    public class AddUseCaseDto
    {
        public  int UserId { get; set; }
        public  List<int> UseCaseIds{ get; set; }
    }

}
