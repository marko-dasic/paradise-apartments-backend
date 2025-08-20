using Apartment.Application.UseCase.Commands.UseCase;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using Apartment.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ical.Net;
using Ical.Net.CalendarComponents;
using System.Collections.Generic;
using System;
using System.IO;
using Microsoft.Extensions.Hosting;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;

using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CalendarController : MyBaseController
    {
        public CalendarController(ApartmentContext context, UseCaseHandler handler) : base(context, handler)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get(IWebHostEnvironment env)
        {
            string filePath = Path.Combine(env.ContentRootPath, "uploads")+"/calendars/myevents.ics";
            string fileContent;
            using (StreamReader reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd();
            }

            var calendar = Calendar.Load(fileContent);

            List<DateTime> dates = new List<DateTime>();

            foreach (var calendarEvent in calendar.Events)
            {
                dates.Add(calendarEvent.Start.AsSystemLocal.Date);
            }

            return Ok(dates);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(IWebHostEnvironment env)
        {
        // Kreiranje novog kalendara
        var calendar = new Calendar();

        // Kreiranje novog događaja
        var calendarEvent = new CalendarEvent
        {
            Summary = "Closed",
            Start = new CalDateTime(2024, 2, 12, 10, 0, 0),
            End = new CalDateTime(2024, 2, 12) 
        };
        string filePath = Path.Combine(env.ContentRootPath, "uploads")+"/calendars/myevents.ics";
        string fileContent;
            using (StreamReader reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd();
            }

        var oldCalendar = Calendar.Load(fileContent);
        oldCalendar.Events.Add(calendarEvent);

        var serializer = new CalendarSerializer();
        var serializedCalendar = serializer.SerializeToString(oldCalendar);

        System.IO.File.WriteAllText(filePath, serializedCalendar);

            return StatusCode(201);
        }

    }
}
