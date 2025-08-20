using Apartment.Application.UseCase.Commands.Email;
using Apartment.Application.UseCase.Commands.UseCase;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using Apartment.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : MyBaseController
    {
        public EmailController(ApartmentContext context, UseCaseHandler handler) : base(context, handler)
        {
        }


        /// <summary>
        /// Slanje poruke u obliku email-a administratoru od strane anonimnog korisnika ili autorizovanog korisnika.
        /// Poruka ce se sa API-a poslati na email-adresu svim administratorima aplikacije.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///{
        /// "userId":1,
        /// "useCaseIds":[101]
        /// }
        ///
        ///
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPut]
        public IActionResult Put([FromBody] SendEmailDto obj, [FromServices] ISendEmailToAdminCommand command)
        {
            handler.HandleCommand(command, obj);
            return StatusCode(200);
        }


    }
}
