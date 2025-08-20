using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.Calendar
{
    public interface ICalendarManager 
    {
        public List<DateTime> GetDates(string filePath);
        public void AddDates(string filePath,DateTime start, DateTime? end);
        public void RemoveDates(string filePath,DateTime start, DateTime? end);
        public bool CheckDates(string filePath ,DateTime start, DateTime? end = null);
        public string CreateCalendar();
    }
}