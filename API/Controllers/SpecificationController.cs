using Apartment.Application.UseCase.Commands.Specification;
using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Specification;
using Apartment.DataAccess;
using Apartment.Domain.Entities;
using Apartment.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SpecificationController : MyBaseController
    {
        public SpecificationController(ApartmentContext context, UseCaseHandler handler) : base(context, handler)
        {
        }

        /// <summary>
        /// Pregled svih specifikacija apartmana - autorizovani i  neautorizovani korisnici.  
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Svaki korisnik moze dohvatiti sve postojece specifikacije. 
        ///
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="500">Unexpected server error.</response>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromServices] IGetAllSpecificationQuery query)
        {
            var res = handler.HandleQuery(query,new object());
            return Ok( res);
        }


        /// <summary>
        /// Dodavanje jedne secifikacije i njene vrednosti jednom apartmanu - autorizovani korisnici sa odredjenim (IdUseCase => 52) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///    Klijent prosledjuje Id aprtmana, Id specifikacije kao i vrenost te specifikacije u vidu teksta koji rucno dodaje. Svi podaci se upisuju u veznu tabelu.
        /// 
        /// {
        ///     "apartmentId":1,
        ///     "specificationId":1,
        ///     "value":3
        /// }
        /// 
        /// 
    /// </remarks>
    /// <response code="201">Inserted</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="422">Unprocessable Entity</response>
    /// <response code="500">Unexpected server error.</response>
    [HttpPost]
        public IActionResult Post([FromBody] ApartmentSpecificationDto obj, [FromServices] ICreateApartmentSpecificatonCommand command)
        {
            handler.HandleCommand(command, obj);
            return StatusCode(201);
        }

        /// <summary>
        /// Dodavanje pojedinacne vrste specifikacije (u posebnu tabelu koja sadrzi sve specifikacije koje se kasnije spajaju veznom tabelom sa apartmanima) - autorizovani korisnici sa odredjenim(IdUseCase => 22) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Dodavanje nove vrste specijikacije. Klijent prosledjue samo naziv specifikacije. Ta specifikacije ce kasnije biti dostupna za pridruzivanje apartmanima.
        ///     
        /// {
        ///     "name":"Wi Fi"
        /// }
        /// 
        /// </remarks>
        /// <response code="201">Inserted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPut]
        public IActionResult Put([FromBody] SpecificationDto obj, [FromServices] ICreateSpecificationCommand command)
        {
            handler.HandleCommand(command,obj);
            return StatusCode(201);
        }

    }
}
