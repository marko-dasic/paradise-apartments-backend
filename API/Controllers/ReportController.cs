using Apartment.Application.UseCase.Commands.Report;
using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Report;
using Apartment.DataAccess;
using Apartment.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.ObjectiveC;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ReportController : MyBaseController
    {
        public ReportController(ApartmentContext context, UseCaseHandler handler) : base(context, handler)
        {
        }

        /// <summary>
        /// Preglde svih reporta apartmna - autorizovani korisnici sa odredjenim (IdUseCase => 8) privilegijama.  
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Administratori mogu dohvatiti sve reoprtove koje su korisnici slali za odredjene apartmane.
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpGet]
        public IActionResult Get([FromServices] IGetAllReportQuery query)
        {
            var res = handler.HandleQuery(query, new object());
            return Ok(res);
        }

        /// <summary>
        /// Preglde svih ponudjenih stavki reporta (pre slanja reporta korisnik mora odabrati jednu od ponudjenih stavki) - neautorizovani i autorizovani korisnici.  
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Korisnici mogu videti sve ponudjene stavke prilikom slanja reporta na apartman. Postoji poseban red u tabeli ReportLines koji sluzi za slobodan unos teksta ukoliko je report specificne prirode.
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="500">Unexpected server error.</response>
        [AllowAnonymous]
        [HttpGet("/lines")]
        public IActionResult Get1([FromServices] IGetAllReportLineQuery query)
        {
            var res =handler.HandleQuery(query, new object());
            return Ok(res);
            
        }

        /// <summary>
        /// Dodavanje jedne od stavki reporta (koje korisnik bira prilikom reporta apartmana) - autorizovani korisnici sa odredjenim (IdUseCase => 24) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Aministratori kreiraju nove ponudjene stavke koje ce korisnici moci odabrati prilikom reportovanja.
        /// 
        /// {
        ///     "name":"Ugrozavanje zivotinja"
        /// {
        /// </remarks>
        /// <response code="201">Inserted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] CreateReportLineDto obj, [FromServices] ICreateReportLineCommand command)
        {
            handler.HandleCommand(command, obj);
            return StatusCode(201);
        }

        /// <summary>
        /// Reportovanje apartmana od strane korisnika  - autorizovani korisnici sa odredjenim(IdUseCase => 16) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Prilikom slanja reporta klijent salje Id reportLine i opcioni tekst i Id apartmana, svi ovi podaci se upisuju u veznu tabelu "Report"
        /// Ulogovati se kao (markodasic70@gmail.com, VisokaIct1);
        /// {
        ///     "text":"Narusavanje autorskih prave i propagiranje nasilja!",
        ///     "apartmentId": 1,
        ///     "reportLineId" : 1
        /// }
    /// </remarks>
    /// <response code="201">Inserted</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="422">Unprocessable Entity</response>
    /// <response code="500">Unexpected server error.</response>
    [HttpPut]
        public IActionResult Put([FromBody] CreateReportDto obj, ICreateReportCommand command)
        {
            handler.HandleCommand(command, obj);
            return StatusCode(201);
        
        }


    }
}
