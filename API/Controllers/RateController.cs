using Apartment.Application.UseCase.Commands.Apartment;
using Apartment.Application.UseCase.Commands.Rate;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using Apartment.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RateController : MyBaseController
    {
        public RateController(ApartmentContext context, UseCaseHandler handler) : base(context, handler)
        {
        }

        /// <summary>
        /// Dodavanje ocene na apartman - autorizovani korisnici sa odredjenim(IdUseCase => 51) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///   Svaki autorizovani korisnik moze ostaviti samo jednom ocenu na jedan apartman u rasponu od 1 do 5.
        ///   Ulogovati se kao (markodasic70@gmail.com, VisokaIct1) 
        /// {
        ///     "apartmentId":1,
        ///     "value":5
        /// }
    /// 
    /// </remarks>
    /// <response code="201">Inserted</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="422">Unprocessable Entity</response>
    /// <response code="500">Unexpected server error.</response>
    [HttpPut]
        public IActionResult Put([FromBody] CreateRateDto obj, [FromServices] ICreateRateCommand command)
        {
            handler.HandleCommand(command, obj);
            return StatusCode(201);
        }


    }
}
