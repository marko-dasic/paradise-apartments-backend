using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Castle.Components.DictionaryAdapter.Xml;
using Apartment.Application.Calendar;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.IIS;

namespace Apartment.Implementation.UseCase.Calendar
{

    public class CalendarManager : ICalendarManager  
    {
        private readonly IWebHostEnvironment env;
        private readonly string generalPath;
        public CalendarManager(IWebHostEnvironment env){
            this.env = env;
            this.generalPath = Path.Combine(env.ContentRootPath, "uploads")+"/calendars/";

        }
        public List<DateTime> GetDates(string fileName){
            if(string.IsNullOrEmpty(fileName)) return new List<DateTime>();
                string filePath;
                if(fileName.Contains("http"))
                {
                    return GetRemoteDates(fileName).Result;
                }
                else
                {
                    filePath = generalPath+fileName;
                }
                string fileContent;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    fileContent = reader.ReadToEnd();
                }

                var calendar = Ical.Net.Calendar.Load(fileContent);

                List<DateTime> dates = new List<DateTime>();

                foreach (var calendarEvent in calendar.Events)
                {
                    var a = calendarEvent.DtStart.AsSystemLocal.Date;
                    var b = calendarEvent.DtEnd.AsSystemLocal.Date;
                    while(a <= b){
                        dates.Add(a);
                            a = a.AddDays(1);
                    }
                }

                return dates;
        }
        public void AddDates(string fileName, DateTime start, DateTime? end){
            this.ManipulateDates(fileName,start,end,"Add");
        }
        public void RemoveDates(string fileName,DateTime start, DateTime? end){
            this.ManipulateDates(fileName,start,end,"Remove");
        }
        public bool CheckDates(string fileName, DateTime start, DateTime? end = null){
            if(string.IsNullOrEmpty(fileName)) return true;
            var dates = this.GetDates(fileName);
            return !dates.Any(x=> x >= start && x < end);
        }
        private void ManipulateDates(string fileName, DateTime start, DateTime? end,string action){
            //Kreiranje novog kalendara
            if(string.IsNullOrEmpty(fileName)) return;
            string filePath = generalPath+fileName;

            var calendar = new Ical.Net.Calendar();

            // Kreiranje novog događaja
            var calendarEvent = new CalendarEvent
            {
                Summary = "Closed",
                Start = new CalDateTime(start),
                End = new CalDateTime(end.Value) 
            };
            string fileContent;
            using (StreamReader reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd();
            }

            var oldCalendar = Ical.Net.Calendar.Load(fileContent);

            if(action.ToLower() == "add")
            {
                oldCalendar.Events.Add(calendarEvent);
            }
            else if(action.ToLower() == "remove")
            {
                oldCalendar.Events.Remove(calendarEvent);
            }

            var serializer = new CalendarSerializer();
            var serializedCalendar = serializer.SerializeToString(oldCalendar);

            System.IO.File.WriteAllText(filePath, serializedCalendar);

        }
        public string CreateCalendar(){
            var guid = Guid.NewGuid() + ".ics";
            var calendar = new Ical.Net.Calendar();
            // Kreirajte događaj
            var evt = new CalendarEvent
            {
                Summary = "Apartment Live",
                Description = "Created Apartment",
                Start = new CalDateTime(DateTime.Now.AddHours(1)),
                End = new CalDateTime(DateTime.Now.AddHours(2)),
                Location = ""
            };

            // Dodajte događaj u kalendar
            calendar.Events.Add(evt);

            // Serijalizujte kalendar u .ics fajl
            var serializer = new CalendarSerializer();
            var serializedCalendar = serializer.SerializeToString(calendar);

            // Sačuvajte .ics fajl na disku
            System.IO.File.WriteAllText(this.generalPath+guid, serializedCalendar);
            return guid;
        }

 
        private async Task<List<DateTime>> GetRemoteDates(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                     if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var calendar = Ical.Net.Calendar.Load(responseBody);

                        List<DateTime> dates = new List<DateTime>();

                        foreach (var calendarEvent in calendar.Events)
                        {
                            var a = calendarEvent.DtStart.AsSystemLocal.Date;
                            var b = calendarEvent.DtEnd.AsSystemLocal.Date;
                            while(a <= b){
                                dates.Add(a);
                                 a = a.AddDays(1);
                            }
                        }

                        return dates;
                    }
                    else
                    {
                       return new List<DateTime>();
                    }
                }
                catch(Exception ex)
                {
                    throw new HttpRequestException();
                }
            }
        }
 
 
    }
}