using Apartment.Application.UseCase.Commands.Blog;
using Apartment.Application.UseCase.Commands.Category;
using Apartment.Application.UseCase.Commands.City;
using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Blogs;
using Apartment.Application.UseCase.Queries.Category;
using Apartment.DataAccess;
using Apartment.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BlogController : MyBaseController
    {
        
        public BlogController([FromServices] ApartmentContext context_, UseCaseHandler handler) :base(context_, handler) { }
        
        /// <summary>
        /// Pregled sbih gradova - neautorizovani i autorizovani korisnici mogu pristupiti.  
        /// </summary>
        /// <param name="query"></param>
        /// <returns return="IEnumerable CategoryDto "></returns>
        /// <remarks>
        ///     Dohvatanje svih gradova. 
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpGet]
        [AllowAnonymous]

        public IActionResult Get([FromServices] IGetAllBlogQuery query)
        {
            var blogs = handler.HandleQuery(query, new object());
            return Ok(blogs);
        }


         /// <summary>
        /// Pregled pojedinacnog bloga - autorizovani i  neautorizovani korisnici.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Dohvatanje pojedinacnog bloga sa svim njegovim detaljima, slikama 
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="500">Unexpected server error.</response>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneBlogQuery query)
        {
            var blog = handler.HandleQuery(query, id);
            return Ok(blog);
        }

        /// <summary>
        /// Dodavanje blog - autorizovani korisnici sa odredjenim (IdUseCase => 7) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns return=""></returns>
        /// <remarks>
        ///    Administratori mogu dodavati blog.
        ///    
        /// {
        ///     
        /// }
        /// </remarks>
        /// <response code="201">Inserted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPut]
        public IActionResult Put([FromBody] CreateBlogDto obj, [FromServices] ICreateBlogCommand command)
        {
            handler.HandleCommand(command, obj);
            return StatusCode(201);
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] UpdateBlogDto obj, [FromServices] IUpdateBlogCommand command)
        {
            handler.HandleCommand(command, obj);
            return StatusCode(201);
        }

        /// <summary>
        /// Brisanje grada - autorizovani korisnici sa odredjenim (IdUseCase => 71) privilegijama.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns return=""></returns>
        /// <response code="204">Deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBlogCommand command)
        {
            handler.HandleCommand(command, id);
            return StatusCode(204);
        }


    }
}
