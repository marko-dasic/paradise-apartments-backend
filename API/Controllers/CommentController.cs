using Apartment.Application.UseCase.Commands.Comment;
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
    public class CommentController : MyBaseController
    {
        public CommentController(ApartmentContext context, UseCaseHandler handler) : base(context, handler)
        {
        }

        /// <summary>
        /// Dodavanje komentara na apartman - autorizovani korisnici sa odredjenim (IdUseCase => 50) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns return="ApartmentDto"></returns>
        /// <remarks>
        ///         Svaki autorizovani korisnik moze komentarisati bilo koji apartman. Takodje moze odgovarati drugi korisnicima na komenatre.
        ///         
        ///{
        /// "apartmentId":1,
        /// "parrentId":0,
        /// "text": "Komentar 111"
        /// }
    /// </remarks>
    /// <response code="201">Inserted</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="422">Unprocessable Entity</response>
    /// <response code="500">Unexpected server error.</response>

    [HttpPut]
        public IActionResult Put([FromBody] CreateCommentDto obj, [FromServices] ICreateCommentCommand command)
        {
            handler.HandleCommand(command, obj);
            return StatusCode(201);
        }

        /// <summary>
        /// Korisnikcko brisanje sopstvenog apartmana - autorizovani korisnici sa odredjenim(IdUseCase => 54) privilegijama.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns return="ApartmentDto"></returns>
        /// <remarks>
        ///    Korisnik moze obrisati svoji komentar. Ukoliko je njegov komentar imao decu komentare onda se i oni automatski brisu sa njim.
        /// </remarks>
        /// <response code="204">Deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="404">Not Found Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("DeleteYourSelf/{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentYourSelfCommand command)
        {
            handler.HandleCommand(command, id);
            return NoContent();

        }

        /// <summary>
        /// Administratorsko risanje bilo kog apartmana - autorizovani korisnici sa odredjenim(IdUseCase => 29) privilegijama.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns return="ApartmentDto"></returns>
        /// <remarks>
        ///     Administrator moze obrisati bilo koji komentar, ukoliko izbrisani komentar sadrzi decu komentare, onda ce i deca biti obrisana. Koristis se soft delete.   
        /// </remarks>
        /// <response code="204">Deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="404">Not Found Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand command)
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
