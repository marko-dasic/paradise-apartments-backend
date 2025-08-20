using Apartment.Application.UseCase.Commands.User;
using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.User;
using Apartment.DataAccess;
using Apartment.Domain;
using Apartment.Domain.Entities;
using Apartment.Implementation;
using Apartment.Implementation.UseCase.Commands.Ef.User;
using Apartment.Implementation.UseCase.Queries.Ef.User;
using API.Core;
using API.Core.TokenStorage;
using API.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : MyBaseController
    {

        public UserController([FromServices] ApartmentContext context, [FromServices] UseCaseHandler handler) : base(context, handler)
        {
            
        }

        /// <summary>
        /// Pregled svi korisnika u aplikaciji uz mogucnost filtriranja i paginacije - autorizovani korisnici sa odredjenim(IdUseCase => 4) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks> 
        /// Administrator moze dohvatiti sve korisnike, kao i filtrirati korisnike po: imenu i prezimenu, po datumu kreiranja u formi od-do. Tkoadje je omogucena paginacija poljima pageNumber (broji stranica koji treba da se prikaze) i pageSize (broji korisnika koji treba prikazati po strnaici)
        /// 
        /// Mozete uneti sledece podatke kako biste zasigurno dobili rezultat
        /// [
        ///  FullName => "Marko"
        ///  CreatedAtFrom => 2022-06-11T21:04:32.331Z
        ///  CreatedAtTo => 2024-06-11T21:04:32.331Z
        ///  PageNumber => 100
        ///  PageSize => 10
        /// ]
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpGet]
        public IActionResult Get([FromQuery] FilterPaginationUserDto obj, [FromServices] IGetAllUsersQuery query)
        {
        
            var all = handler.HandleQuery(query,obj);
            return Ok(all);
        }

        /// <summary>
        /// Korisnicki pregled sopstvenog profila - svaki autorizovani korisnici.  
        /// </summary>
        /// <param name="user"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Korisnik moze sam dohvatiti svoje podatke. Id korisnika se izvlazi iz JWT tokena.
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpGet("GetYourSelf")]
        public IActionResult GetYourSelf([FromServices] GetYourSelfQuery query, [FromServices] IUser user)
        {
            var id = user.Id;
            var all = handler.HandleQuery(query, id);
            return Ok(all);
        }

        /// <summary>
        /// Pregled pojedinacnog korisnika u aplikaciji - autorizovani korisnici sa odredjenim(IdUseCase => 3) privilegijama.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        /// Administratori mogu dohvatiti sve detaljne informacije o korisniku prosledjivanjem Id korz url {user/id};
        /// 
        /// {
        ///     "id":1
        /// }
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Unexpected server error.</response>

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneUserQuery query)
        {
            var user = handler.HandleQuery(query, id);
            return Ok(user);
        }

        /// <summary>
        /// Log In korisnika na platformu pmocu JWT tokena - neautorizovani korisnici.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="manager"></param>
        /// <returns></returns>
        /// <remarks>
        /// Korisnik se loguje na aplikaciju putem emaila i passworda. njegovi podaci se beleze u token koji se vraca klijentu u vidu teksta. Tokeni se skladiste u lokalnu memoriju aplikacije tako da je potrebno ulogovati se svaki put nakon gasenje aplikacije, jer se svi token brisu iz memorije nekon gasenje aplikacije.
        /// 
        /// {
        ///     "email":"markodasic70@gmail.com",
        ///     "password":"VisokaIct1"
        /// }
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] LogInUserDto obj, [FromServices] JwtManager manager)
        {
            var token = manager.MakeToken(obj.Email, obj.Password);
            return Ok( new {token});
            
        }

        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public IActionResult RefreshToken([FromServices] IUser user, [FromServices] JwtManager manager)
        {
            string result = "";
            string token = "";
            var header = HttpContext.Request.Headers.Any();
            string authorizationHeader = null;
            if (header) authorizationHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
            {
                token = authorizationHeader.Substring("Bearer ".Length);
                result = manager.RefreshToken(token);
            }

            return Ok(new { token = result });
        }

        /// <summary>
        /// Registracija korisnika na platformu - neautorizovani korisnici.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="createUserCommand"></param>
        /// <returns></returns>
        /// <remarks>
        /// Korisnik se moze registrovati. Nakon uspesne registracije korisniku ce biti poslat mejl dobrodoslice. Unique ogranicenja  su sledeca: broji telefona i email adresa ne smeju biti isti. Ova logika je resena u vlaidatorima, cak i ukoliko je neki korisnik obrisan (zbog soft delete se njegovi podaci idalje fizicki cuvaju u bazi ) moguce je kreirati novog korisnika sa istom email adresom ili borjem telefona, ali samo ukoliko je korisnik koji vec poseduje istu emai adresu ili br. telefona obrisan.
        /// 
        /// {
        ///     "firstName":"Dasic",
        ///     "lastName":"Marko"
        ///     "email":"markodasic70@gmail.com",
        ///     "password":"VisokaIct1",
        ///     "phone":"+381652254864",
        ///}
        /// 
        /// 
        /// </remarks>
        /// <response code="201">Inserted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [AllowAnonymous]
        [HttpPut]
        public IActionResult Put([FromBody] CreateUserDto obj, [FromServices] ICreateUserCommand createUserCommand)
        {
            handler.HandleCommand(createUserCommand, obj);
            return StatusCode(201);
        }
        /// <summary>
        /// Azuriranje korisnika od strane administratora.- autorizovani korisnici sa odredjenim(IdUseCase => 9) privilegijama. 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///  Administratori mogu azurirati bilo kog korisnika sistema. Prilikom azuriranja potrebno je da se proslede svi postojeci podaci korisnika. Ukoliko je neki od podataka promenjen to ce se detektovati i azurirace se samo ta svojstva objekta koji se azurira.
        ///  
        /// {
        ///     "id": 1,
        ///     "firstName":"Dasic",
        ///     "lastName":"Marko"
        ///     "email":"markodasic70@gmail.com",
        ///     "password":"VisokaIct1",
        ///     "phone":"+381652254864",
        ///     "cityId":1,
        ///     "useCaseIds":[]
        /// }
        /// </remarks>
        /// <response code="204">Updated</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPatch]
        public IActionResult Patch([FromBody] UpdateUserDto obj, [FromServices] IUpdateUserCommand command)
        {
            handler.HandleCommand(command, obj);
            return StatusCode(204);
        }

        /// <summary>
        /// Korisnicko azuriranje sopstvenog naloga.- autorizovani korisnici sa odredjenim(IdUseCase => 55) privilegijama. 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="user"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>  
        ///Korisnici  mogu azurirati svoji nalog na sistemu. Prilikom azuriranja potrebno je da se proslede svi postojeci podaci korisnika. Ukoliko je neki od podataka promenjen to ce se detektovati i azurirace se samo ta svojstva objekta koji se azurira.
        /// Ovim izvrsavanjem se nece azurirati niz useCaseIds, jer ukoliko je prosledjen prazan niz, nece se vrsiti azurianje.
        /// {
        ///     ,
        ///     "firstName":"Dasic",
        ///     "lastName":"Marko"
        ///     "email":"markodasic70@gmail.com",
        ///     "password":"VisokaIct1",
        ///     "phone":"+381652254864",
        ///     "cityId":1,
        ///     "useCaseIds":[]
        /// }
        /// 
        /// 
    /// </remarks>
    /// <response code="204">Updated</response>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="422">Unprocessable Entity</response>
    /// <response code="500">Unexpected server error.</response>

    [HttpPatch("UpdateYourSelf")]
        public IActionResult PatchYourSelf([FromBody] UpdateUserDto obj, [FromServices] IUser user, [FromServices] UpdateYourSelfCommand command)
        {
            obj.Id = user.Id;
            handler.HandleCommand(command, obj);
            return StatusCode(204);
        }


        /// <summary>
        /// Brisanje korisnika od strane administratora - autorizovani korisnici sa odredjenim(IdUseCase => 27) privilegijama.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns return="ApartmentDto"></returns>
        /// <remarks>
        ///    
        /// </remarks>
        /// <response code="204">Deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="404">Not Found Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }

        /// <summary>
        /// Korisnicko Brisanje sopstvenog naloga i automatski log out - autorizovani korisnici sa odredjenim(IdUseCase => 53) privilegijama.  
        /// </summary>
        /// <param name="command"></param>
        /// <param name="token"></param>
        /// <returns return="ApartmentDto"></returns>
        /// <remarks>
        ///     Korisnik moze izbrisati sam svoji nalog. Nakon brisnaja njegov token ce automatski biti unisten. Koristi se Sof Delete
        /// </remarks>
        /// <response code="204">Deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="404">Not Found Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("DeleteYourSelf/{id}")]
        public IActionResult DeleteYourSelf([FromServices] IDeleteYourSelfCommand command, [FromServices] ITokenStorage token)
        {
            handler.HandleCommand(command,new object());
            this.InvalidateToken(token);
            return NoContent();
        }

        /// <summary>
        /// Log out - svaki autorizovani korisnik.  
        /// </summary>
        /// <param name="storage"></param>
        /// <returns return="ApartmentDto"></returns>
        /// <remarks>
        ///     Token se unistava.
        /// </remarks>
        /// <response code="204">Deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="404">Not Found Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("logout")]
        public IActionResult InvalidateToken([FromServices] ITokenStorage storage)
        {
            var header = HttpContext.Request.Headers["Authorization"];

            var token = header.ToString().Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;

            storage.InvalidateToken(jti);

            return NoContent();
        }
    }
}
