using Apartment.Application.UseCase.Commands.Apartment;
using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Apartment;
using Apartment.DataAccess;
using Apartment.Implementation;
using Apartment.Implementation.UseCase.Commands.Ef.Apartment;
using Apartment.Implementation.UseCase.Queries.Ef.Apartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ReservationController : MyBaseController
    {
        public ReservationController(ApartmentContext context, UseCaseHandler handler) : base(context, handler)
        {
        }

        /// <summary>
        /// Preglde svih rezervacija apartmna Uz omoguceno filtriranje i paginaciju - autorizovani korisnici sa odredjenim (IdUseCase => 26) privilegijama.  
        /// </summary>
        /// <param name="request"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///  Moguce je filtrirati pretragu rezervacija po datumu, Id apartmana, da li je placeno. Takodje s unosom broja zeljenih stranica za brikaz kao i velicine tih stranica relaizuje paginacija
        ///  
        /// CreatedAtFrom predstavlja datum od kada rezervacija pocinje,  CreatedAtTo predstavlja do kada je apartman rezervisan. 
        /// 
        /// CreatedAtFrom => "2000-05-11T21:13:31.594Z"
        /// CreatedAtTo => "2030-05-11T21:13:31.594Z"
        /// isPaid = false
        /// 
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpGet]
        public IActionResult Get([FromQuery] FilterPaginationReservationDto request, [FromServices] IGetAllReservationQuery query)
        {
            var res = handler.HandleQuery(query, request);
            return Ok(res);
        }

        /// <summary>
        /// Preglded svojih rezervacija apartmna od strane ulogovanog korisnika. Uz omoguceno filtriranje i paginaciju - autorizovani korisnici sa odredjenim (IdUseCase => 57) privilegijama.  
        /// </summary>
        /// <param name="request"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///  Moguce je filtrirati pretragu rezervacija po datumu, Id apartmana, da li je placeno. Takodje s unosom broja zeljenih stranica za brikaz kao i velicine tih stranica relaizuje paginacija
        ///  
        /// CreatedAtFrom predstavlja datum od kada rezervacija pocinje,  CreatedAtTo predstavlja do kada je apartman rezervisan. 
        /// 
        /// CreatedAtFrom => "2000-05-11T21:13:31.594Z"
        /// CreatedAtTo => "2030-05-11T21:13:31.594Z"
        /// isPaid = false
        /// 
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="422">Unprocessable entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpGet("GetYourSelf")]
        public IActionResult GetYourSelf([FromQuery] FilterPaginationReservationDto request, [FromServices] GetYourSelfReservationQuery query)
        {
            var res = handler.HandleQuery(query, request);
            return Ok(res);

        }
        /// <summary>
        /// Oznacavanje rezervacije da je otkazana od strane korisnika ili administratora - autorizovani korisnici sa odredjenim(IdUseCase => 59) privilegijama.  
        /// </summary>
        /// <param name="request"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>  
        ///     Korinsik prosledjuje id rezervacije koju zeli da oznaci kao otkazanu ili ponovno aktivnu ukoliko je slucajno otkaze.
        ///     
        /// 
        /// {
        ///     "id":1
        /// }
        /// 
        /// </remarks>
        /// <response code="204">Updated</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Entity not found</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost("MarkCancelOrRecancel")]
        public IActionResult markCancelOrRecancel([FromBody] int request, [FromServices] ICancelledReservationCommand command)
        {
            handler.HandleCommand(command, request);
            return StatusCode(204);
        }



        /// <summary>
        /// Oznacavanje rezervacije da je otkazana od vlasnika rezervacije - autorizovani korisnici sa odredjenim(IdUseCase => 59) privilegijama.  
        /// </summary>
        /// <param name="request"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>  
        ///     Korinsik prosledjuje id rezervacije koju zeli da oznaci kao placenu ili neplacenu
        ///     
        /// 
        /// {
        ///     "id":1
        /// }
        /// 
        /// </remarks>
        /// <response code="204">Updated</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost("CancelledYourSelf")]
        public IActionResult CancelledYourSelf([FromBody] int request, [FromServices] CancelledReservationYourSelfCommand command)
        {
            handler.HandleCommand(command, request);
            return StatusCode(204);
        }



        /// <summary>
        /// Oznacavanje rezervacije da je placena ili da je neplacena - autorizovani korisnici sa odredjenim(IdUseCase => 30) privilegijama.  
        /// </summary>
        /// <param name="request"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>  
        ///     Korinsik prosledjuje id rezervacije koju zeli da oznaci kao placenu ili neplacenu
        ///     
        /// 
        /// {
        ///     "id":1
        /// }
        /// 
        /// </remarks>
        /// <response code="204">Updated</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        public IActionResult post([FromBody] int request, [FromServices] IMarkPaidReservationCommand command)
        {
            handler.HandleCommand(command, request);
            return StatusCode(204);
        }



        /// <summary>
        /// Dodavanje rezervacije apartmana - autorizovani korisnici sa odredjenim(IdUseCase => 56) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>  
        ///     Korinsik kreira rezervaciju unosenjem Id apartmana, datumo od, do. Ukoliko je apartman zauzet nekim danima koje spadaju u opseg u kom je korisnik zeleo da ga rezervise, bice obavesten porukom da je termin zauzet.
        ///     
        /// 
        /// {
        ///     "apartmentId":1,
        ///     "from":"2025-05-11T21:13:31.594Z",
        ///     "to":"2025-06-11T21:13:31.594Z"
        /// 
        /// }
        /// 
        /// </remarks>
        /// <response code="201">Inserted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [AllowAnonymous]
        [HttpPut]
        public IActionResult Put([FromBody] CreateReservationDto obj, [FromServices] ICreateReservationsCommand command)
        {
            handler.HandleCommand(command, obj);
            return StatusCode(201);
        }



        /// <summary>
        /// Brisanje Rezervacija od strane admina - autorizovani korisnici sa odredjenim (IdUseCase => 28) privilegijama.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns return="ApartmentDto"></returns>
        /// <remarks>
        ///     Aministrator moze brisati sve rezervacije (soft delete).
        ///     proslediti id => 16 kako biste sigurno obrisali jednu rezervacju
        /// </remarks>
        /// <response code="204">Deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="404">Not Found Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReservationCommand command)
        {
            handler.HandleCommand(command,id);
            return NoContent();
        }

        /// <summary>
        /// Brisanje Rezervacija od strane korisnika koji ju je kreirao - autorizovani korisnici sa odredjenim (IdUseCase => 58) privilegijama.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns return="ApartmentDto"></returns>
        /// <remarks>
        ///     Korisnik moze brisati iskljucivo samo svoje rezervacije
        /// </remarks>
        /// <response code="204">Deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("yourself/{id}")]
        public IActionResult DeleteYourSelf(int id, [FromServices] IDeleteYorSelfReservationCommand command)
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }







    }
}
