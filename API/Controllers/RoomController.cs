using Apartment.Application.UseCase.Queries.Room;
using Apartment.DataAccess;
using Apartment.Implementation;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : MyBaseController
    {
        
        public RoomController(ApartmentContext context, UseCaseHandler handler) : base(context, handler)
        {
        }

        [HttpGet]
        public IActionResult Get([FromServices] IGetRoomsQuery query)
        {
            var result = this.handler.HandleQuery(query,new object());
            return Ok(result);
        }


    }
}
