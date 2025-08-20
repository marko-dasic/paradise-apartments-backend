using Apartment.Application.UseCase.Commands.Apartment;
using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Apartment;
using Apartment.DataAccess;
using Apartment.Domain.Entities;
using Apartment.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ApartmentController : MyBaseController
    {
        public ApartmentController(ApartmentContext context, UseCaseHandler handler) : base(context, handler)
        {
        }

        /// <summary>
        /// Preglde apartmana uz filtriranje i paginaciju - autorizovani i  neautorizovani korisnici.   
        /// </summary>
        /// <param name="request"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///  Ukoliko se neki od parametara ostavi prazan, taj parametar se nece uzimati u obzir pri filtriranju. Ukoliko je u pitanju paginacija
        ///     onda ce se prikazati svi apartmani zajedno. Apartmani se ne vracaju sa svi svojim podacima (bez komentara, slikama...), vec samo sa najosnovnijim podacima.
        ///     
        /// title => "Sofia",
        /// minPrice => 0,
        /// maxPrice => 10000,
        /// CategoryId => 0,
        /// pageNumber=> 100,
        /// pageSize => 10
        /// 
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromQuery] FilterPaginationApartmentDto request, [FromServices] IGetAllApartmentsQuery query)
        {
            var apartments = handler.HandleQuery(query,request);
            return Ok(apartments);
        }


        /// <summary>
        /// Pregled pojedinacnog apartmana - autorizovani i  neautorizovani korisnici.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Dohvatanje pojedinacnog apartmana sa svim njegovim detaljima, komentarima, slikama, ocenama itd. 
        ///     Prosledite Id => 1 kako biste sigurno dohvatili jedan apartman
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="500">Unexpected server error.</response>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneApartmentQuery query)
        {
            var apartment = handler.HandleQuery(query, id);
            return Ok(apartment);
        }



        /// <summary>
        /// Dodavanje apartmana - autorizovani korisnici sa odredjenim(IdUseCase => 5) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="createApartmentCommand"></param>
        /// <returns></returns>
        /// <remarks>
        /// 
        ///     Thumb slika, kao i ostale slike se salju u formi base64. Ukoliko se Prioritet ne definise podrazumevana vrednost ce biti 3;
        ///     Prioritet nam kazuje da li ce se apartman videti na vrhu ili dnu stranice. 
        ///
        /// 
        /// {
        ///     "title":"Peti najbolji Apartman (inserted)",
        ///     "description": "desc",
        ///       "geoLocationX": "string",
        ///      "geoLocationY": "string",
        ///      "categoryId": 1,
        ///      "cityId": 1,
        ///      "file": "uneti sliku u base64 formatu",
        ///      "fileId": 0,
        ///      "price": {
        ///        "pricePerNight": 500,
        ///        "pricePerNightWeekend": 900,
        ///        "priceOnHoliday":1000
        ///      },
        ///      "imagesIds": [
           ///
        ///       ],
        ///      "images": [
        ///        "string"
        ///      ],
        ///      "priority": 1
        /// }
        /// </remarks>
        /// <response code="201">Inserted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPut]
        public IActionResult Put([FromBody] CreateApartmentDto obj, [FromServices] ICreateApartmentCommand createApartmentCommand)
        {
            handler.HandleCommand(createApartmentCommand, obj); 
            return StatusCode(201);
        }



        /// <summary>
        /// Azuriranje apartmana - autorizovani korisnici sa odredjenim(IdUseCase => 23) privilegijama.  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///          Prilikom azuriranja podataka, prosledjuju se svi podaci objekta koji se azurira. Tacnje ukoliko se azurira samo naziv, potrebno je u request-u posalti i sve ostale informacije. Funkcionalnost je zamisljena tako sto bi korisnik na front dobio sve podatke o nekom apartmanu i njih izmenio ukoliko to zeli i vratio nazad na server. Azuriraju se samo oa polja koja su promenjena,ne i ceo objekat.   
        ///          Ukoliko se ne proslede svi Id-evi slika ili ukoliko se prosledi samo nekolicina Id-eva slika, smatrace se da su slike ciji Id-evi nisu prosledjeni izbrisanim.
        ///          
        /// {
        ///     "id":13,
        ///     "title":"Treci najbolji Apartman (edit)",
        ///     "description": "desc",
        ///       "geoLocationX": "string",
        ///      "geoLocationY": "string",
        ///      "categoryId": 1,
        ///      "cityId": 1,
        ///      "file": "uneti sliku u base64 formatu",
        ///      "fileId": 45,
        ///      "price": {
        ///        "pricePerNight": 8000,
        ///        "pricePerNightWeekend": 9000,
        ///        "priceOnHoliday":10000
        ///      },
        ///      "imagesIds": [
        ///
        ///       ],
        ///      "images": [
        ///        "string"
        ///      ],
        ///      "priority": 5
        /// }
        /// 
    /// </remarks>
    /// <response code="204">Updated</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="422">Unprocessable Entity</response>
    /// <response code="500">Unexpected server error.</response>
    [HttpPatch]
        public IActionResult Patch([FromBody] UpdateApartmentDto obj, [FromServices] IUpdateApartmentCommand command )
        {
            handler.HandleCommand(command, obj);
            return StatusCode(204);
        }

        /// <summary>
        /// Brisanje apartmana - autorizovani korisnici sa odredjenim (IdUseCase => 25) privilegijama.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns return="ApartmentDto"></returns>
        /// <remarks>
        ///    Aminstrator moze obrisati bilo koji apartman u aplikaciji, ali se primenjuje tzv. "soft delete" tako da podaci ostaju fizicnki u bazi podataka.
        ///    
        /// Prosledite Id => 14 Kako biste bili sigurni da se jedan apartman obrisali.
        /// </remarks>
        /// <response code="204">Deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="404">Not Found Entity</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteApartmentCommand command)
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
