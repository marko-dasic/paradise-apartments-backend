using Apartment.DataAccess;
using API.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Apartment.Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Apartment.Implementation.Validators;
using Apartment.Implementation;
using Apartment.Application.UseCase.Commands.User;
using Apartment.Implementation.UseCase.Commands.Ef.User;
using Apartment.Application.UseCase.Commands.UseCase;
using Apartment.Implementation.UseCase.Commands.Ef.UseCase;
using Apartment.Implementation.Mapper;
using AutoMapper;
using Apartment.Application.UseCase.Queries.User;
using Apartment.Implementation.UseCase.Queries.Queries.User;
using Apartment.Application.UseCase.Queries.Apartment;
using Apartment.Implementation.UseCase.Queries.Ef.Apartment;
using Apartment.Application.UseCase.Commands.Apartment;
using Apartment.Implementation.UseCase.Commands.Ef.Apartment;
using Apartment.Implementation.UseCase.Queries.Ef.User;
using Apartment.Application.UseCase.Commands.City;
using Apartment.Application.UseCase.Commands.Category;
using Apartment.Implementation.UseCase.Commands.Ef.City;
using Apartment.Implementation.UseCase.Commands.Ef.Category;
using Apartment.Application.UseCase.Queries.Category;
using Apartment.Implementation.UseCase.Queries.Ef.Category;
using Apartment.Application.UseCase.Queries.City;
using Apartment.Implementation.UseCase.Queries.Ef.City;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Hosting;
using Apartment.Application.UseCase.Commands.Comment;
using Apartment.Implementation.UseCase.Commands.Ef.Comment;
using Apartment.Application.UseCase.Commands.Rate;
using Apartment.Implementation.UseCase.Commands.Ef.Rate;
using Apartment.Application.UseCase.Queries.Specification;
using Apartment.Implementation.UseCase.Queries.Ef.Specification;
using Apartment.Application.UseCase.Commands.Specification;
using Apartment.Implementation.UseCase.Commands.Ef.Specification;
using Apartment.Implementation.UseCase.UploadImages;
using Apartment.Application.UseCase.Commands.Report;
using Apartment.Implementation.UseCase.Commands.Ef.Report;
using Apartment.Application.UseCase.Queries.Report;
using Apartment.Implementation.UseCase.Queries.Ef.Report;
using Apartment.Implementation.Mail;
using Castle.Core.Smtp;
using API.Core.TokenStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using System.Linq;
using Apartment.Application.UseCase.Commands.Email;
using Apartment.Implementation.UseCase.Commands.Ef.Email;
using Apartment.Application.UseCase.Queries.Room;
using Apartment.Implementation.UseCase.Queries.Ef.Room;
using Apartment.Application.Calendar;
using Apartment.Implementation.UseCase.Calendar;
using Apartment.Application.UseCase.Queries.Blogs;
using Apartment.Application.UseCase.Commands.Blog;

namespace API.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddJwt(this IServiceCollection services, AppSetings settings)
        {

            services.AddTransient<ITokenStorage, InMemoryTokenStorage>();


            services.AddTransient(x =>
            {
                var context = x.GetService<ApartmentContext>();
                var settings = x.GetService<AppSetings>();
                var tokenStorage = x.GetService<ITokenStorage>();
             
                return new JwtManager(context, settings.JwtSettings, tokenStorage);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = false,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };


                cfg.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        //Token dohvatamo iz Authorization header-a

                        var header = context.Request.Headers["Authorization"];
                        var token = header.ToString().Split("Bearer ")[1];
                        var handler = new JwtSecurityTokenHandler();
                        var tokenObj = handler.ReadJwtToken(token);
                        string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;

                        //ITokenStorage
                        ITokenStorage storage = context.HttpContext.RequestServices.GetService<ITokenStorage>();
                        bool isValid = storage.TokenExists(jti);
                        if (!isValid)
                        {
                            context.Fail("Token is not valid.");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            /* services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
             services.AddTransient<IGetUseCaseLogsQuery, GetUseCaseLogsQuery>();
             services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
             services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
             services.AddTransient<IGetSpecificationsQuery, EfGetSpecificationsQuery>();
             services.AddTransient<IFindSpecificationQuery, EfFindSpecificationQuery>();
             services.AddTransient<ICreateSpecificationCommand, EfCreateSpecificationCommand>();
             services.AddTransient<IDeleteSpecificationCommand, EfDeleteSpecificationCommand>();
             services.AddTransient<IUpdateUserUseCasesCommand, EfUpdateUserUseCases>();
             #region Validators
             services.AddTransient<CreateCategoryValidator>();
             services.AddTransient<RegisterUserValidator>();
             services.AddTransient<CreateSpecificationValidator>();
             services.AddTransient<UpdateUserUseCasesValidator>();
             services.AddTransient<SearchUseCaseLogsValidator>();
             #endregion

            */
            services.AddTransient<UseCaseHandler>();

            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IAddUseCaseCommand, AddUseCaseCommand>();
            services.AddTransient<ICreateCityCommand, CreateCityCommand>();
            services.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
            services.AddTransient<ICreateCommentCommand, CreateCommentCommand>();

            services.AddTransient<ICreateRateCommand, CreateRateCommand>();
            services.AddTransient<ICreateSpecificationCommand, CreateSpecificationCommand>();
            services.AddTransient<ICreateApartmentSpecificatonCommand, CreateApartmentSpecification>();
            services.AddTransient<ICreateApartmentCommand, CreateApartmentCommand>();
            services.AddTransient<ICreateReportLineCommand, CreateReportLineCommand>();


            services.AddTransient<ICreateReportCommand, CreateReportCommand>();
            services.AddTransient<ICreateReservationsCommand, CreateReservationCommadn>();
            services.AddTransient<IUpdateApartmentCommand, UpdateApartmentCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<UpdateYourSelfCommand>();

            services.AddTransient<IDeleteApartmentCommand, DeleteApartmentCommand>();
            services.AddTransient<IDeleteCommentCommand, DeleteCommentCommand>();
            services.AddTransient<IDeleteCommentYourSelfCommand, DeleteCommentYourSelfCommand>();
            services.AddTransient<IDeleteReservationCommand, DeleteReservationCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUsetCommand>();
            services.AddTransient<IDeleteBlogCommand, DeleteBlogCommand>();

            services.AddTransient<IDeleteYourSelfCommand, DeleteYourSelfCommand>();
            services.AddTransient<IMarkPaidReservationCommand, MarkPaidReservationCommand>();
            services.AddTransient<IDeleteYorSelfReservationCommand, DeleteYorSelfReservationCommand>();
            services.AddTransient<ICancelledReservationCommand, CancelledReservationCommand>();
            services.AddTransient<ICreateBlogCommand, CreateBlogCommand>();
            services.AddTransient<IUpdateBlogCommand, UpdateBlogCommand>();


            services.AddTransient<IGetOneUserQuery, GetOneUserQuery>();
            services.AddTransient<IGetAllUsersQuery, GetAllUsersQuery>();
            services.AddTransient<IGetAllApartmentsQuery, GetAllApartmentQuery>();
            services.AddTransient<IGetOneApartmentQuery, GetOneApartmentQuery>();
            services.AddTransient<IGetAllCategoriesQuery, GetAllCategoriesQuery>();
           
            services.AddTransient<IGetAllCityQuery, GetAllCityQuery>();
            services.AddTransient<IGetAllSpecificationQuery, GetAllSpecificationQuery>();
            services.AddTransient<IGetAllReportLineQuery, GetAllReportLineQuery>();
            services.AddTransient<IGetAllReportQuery, GetAllReportQuery>();
            services.AddTransient<IGetAllReservationQuery, GetAllReservationQuery>();

            services.AddTransient<IGetRoomsQuery, GetRoomsQuery>();
            services.AddTransient<IGetAllBlogQuery, GetAllBlogQuery>();
            services.AddTransient<IGetOneBlogQuery, GetOneBlogQuery>();

            services.AddTransient<IDeleteCityCommand, DeleteCityCommand>();
            services.AddTransient<IDeleteCategoryCommand, DeleteCategoryCommand>();
            services.AddTransient<GetYourSelfQuery>();
            services.AddTransient<GetYourSelfReservationQuery>();
            services.AddTransient<CancelledReservationYourSelfCommand>();

            services.AddTransient<ISendEmailToAdminCommand, SendEmailToAdminCommand>();
            services.AddTransient<IActivateUser, ActivateUser>();
            services.AddTransient<ICalendarManager, CalendarManager>();
            

            services.AddTransient<CreateUserValidator>();
            services.AddTransient<AddUseCaseValidator>();
            services.AddTransient<CreateApartmentValidator>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<CreateCtiyValidator>();
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<CreateRateValidator>();
            services.AddTransient<SpecificationValidator>();
            services.AddTransient<CreateApartmentSpecificationValidator>();
            services.AddTransient<AddPriceForApartmentValidator>();
            services.AddTransient<UpdateApartmentValidator>();
            services.AddTransient<CreateReportValidator>();
            services.AddTransient<CreateReservationValidator>();
            services.AddTransient<UpdateUserValidator>();


        }

        public static void AddMapper(this IServiceCollection services)
        {
            services.AddTransient(e =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                });

                IMapper mapper = config.CreateMapper();

                return mapper;
            });
           
        }

        public static void AddUser(this IServiceCollection services)
        {
            services.AddTransient<IUser>(x =>
            {
                
                var accessor = x.GetService<IHttpContextAccessor>();

                //var header = accessor.HttpContext.Request.Headers["Authorization"];                

                var claims = accessor?.HttpContext?.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonimousUser();
                }

                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    FirstName = claims.FindFirst("FirstName").Value,
                    LastName = claims.FindFirst("LastName").Value,
               
                    UseCasesIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
        }

        public static void AddApartmentContext(this IServiceCollection services)
        {
            services.AddTransient(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var conString = x.GetService<AppSetings>().ConnectionString;

                optionsBuilder.UseSqlServer(conString);
                optionsBuilder.UseLazyLoadingProxies();

                var options = optionsBuilder.Options;

                return new ApartmentContext(options);
            });
        }
        public static void AddUploadFile(this IServiceCollection services)
        {
            //services.AddTransient<IHostingEnvironment>();
            services.AddTransient<UploaderImages>();
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = int.MaxValue;
            });
        }
    
    
    
    }
}
