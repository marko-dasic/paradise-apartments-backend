using Apartment.Application.Exceptions;
using Apartment.Application.Logging;
using Apartment.Application.UseCase;
using Apartment.Domain;
using Apartment.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation
{
    public class UseCaseHandler 
    {
        private IUseCaseLogger useCaseLogger;
        private IExceptionLoger exceptionLogger;
        private IUser user;

        public UseCaseHandler(IUseCaseLogger useCaseLogger, IExceptionLoger exceptionLogger, IUser user)
        {
            this.useCaseLogger = useCaseLogger;
            this.exceptionLogger = exceptionLogger;
            this.user = user;
        }


        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(command, data,true);
                
                command.Execute(data);
            }
            catch (Exception ex)
            {
                exceptionLogger.Log(ex);
                throw;
            }
        }

        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(query, data,false);
                 return query.Execute(data);
            }
            catch (Exception ex)
            {
                exceptionLogger.Log(ex);
                throw;
            }
        }


        private void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data,bool isLogging)
        {
            var isAuthorized = user.UseCasesIds.Contains(useCase.Id);
            // var isAuthorized = true;
            if (isLogging)
            {
                var log = new UseCaseLog
                {
                    User = user.Email,
                    ExecutionDateTime = DateTime.UtcNow,
                    UseCaseName = useCase.Name,
                    UserId = user.Id,
                    Data = JsonConvert.SerializeObject(user),
                    IsAuthorized = isAuthorized
                };

                useCaseLogger.Log(log);
            }

            if (!isAuthorized)
            {
                throw new ForbiddenUseCaseExec(useCase.Name, user.FirstName + " " + user.LastName);
            }
        }



    }
}
