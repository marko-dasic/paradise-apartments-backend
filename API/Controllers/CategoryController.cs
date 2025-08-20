using Apartment.Application.UseCase.Commands.Category;
using Apartment.Application.UseCase.Commands.City;
using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Category;
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
    public class CategoryController : MyBaseController
    {
        public CategoryController(ApartmentContext context, UseCaseHandler handler) : base(context, handler)
        {
        }


        /// <summary>
        /// Pregled svih kategorija - neautorizovani i autorizovani korisnici mogu pristupiti.  
        /// </summary>
        /// <param name="query"></param>
        /// <returns return="IEnumerable CategoryDto"></returns>
        /// <remarks>
        ///     Dohvatanje svih kategorija i njihove dece.
        /// </remarks>tment   
        /// <response code="200">Success</response>
        /// <response code="500">Unexpected server error.</response>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromServices] IGetAllCategoriesQuery query)
        {
            var res = handler.HandleQuery(query, new object());
            return Ok(res);
        }


        /// <summary>
        /// Dodavanje Kategorije - autorizovani korisnici sa odredjenim (IdUseCase => 6) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns return=""></returns>
        /// <remarks>
        ///     Administratori mogu dodavati nove kategorije ili novu decu kategorije.
        ///     
        /// {
        ///     "name":"Izuzetnog kvaliteta",
        ///     "parrentId":1
        /// }
        /// 
        /// </remarks>
        /// <response code="201">Inserted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPut]
        public IActionResult Put([FromBody] CreateCategoryDto obj, [FromServices] ICreateCategoryCommand command)
        {
            handler.HandleCommand(command, obj);
            return StatusCode(201);
        }
    

        /// <summary>
        /// Brisanje kategorije - autorizovani korisnici sa odredjenim (IdUseCase => 72) privilegijama.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns return=""></returns>
        /// <response code="204">Deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            handler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
