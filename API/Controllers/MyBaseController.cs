using Apartment.DataAccess;
using Apartment.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyBaseController : ControllerBase
    {
        protected readonly ApartmentContext context;
        protected readonly UseCaseHandler handler;
        public MyBaseController(ApartmentContext context, UseCaseHandler handler)
        {
            this.context = context;
            this.handler = handler;
        }
    }
}
