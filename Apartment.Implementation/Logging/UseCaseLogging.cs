using Apartment.Application.UseCase;
using Apartment.DataAccess;
using Apartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.Logging
{
    public class UseCaseLogging : IUseCaseLogger
    {
        private ApartmentContext _context;
       
        public UseCaseLogging(ApartmentContext context) 
        {
            _context = context;

        }
        public IEnumerable<UseCaseLog> GetLogs(UseCaseLogSearch search)
        {
            return _context.UseCaseLogs.ToList();
        }

        public void Log(UseCaseLog log)
        {
            _context.UseCaseLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
