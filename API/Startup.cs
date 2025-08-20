using Apartment.Application.Logging;
using Apartment.Application.UseCase;
using Apartment.DataAccess;
using Apartment.Implementation.Logging;
using Apartment.Implementation.Mail;
using ASPNedelja3Vezbe.Api.Core;
using Castle.Core.Smtp;
using API.Core;
using API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace API
{
    public class Startup
    {
        string myDefaultOrigins = "MyDefaultOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("120.0.0.1"));
            });

            services.AddHttpContextAccessor();
            services.AddCors(options =>
            {
                options.AddPolicy(name: myDefaultOrigins,
                    builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            var settings = new AppSetings();
            Configuration.GetSection("AppSettings").Bind(settings);




          /*  settings.ConnectionString = @"Data Source=KOMP\SQLEXPRESS01; Initial Catalog = Apartment; Integrated Security = true; TrustServerCertificate=true";
            settings.JwtSettings = new JwtSettings();
            settings.JwtSettings.Minutes = 245;
            settings.JwtSettings.SecretKey = "1234asdsadsaffasfkjljasjdlsdjlksdfjlkjlsdjlkfsdhlkdhfdsh56789";
            settings.JwtSettings.Issuer = "Marko Dasic";*/

            services.AddTransient<Apartment.Application.Mail.IEmailSend>(x =>
            new SmtpEmailSender(settings.MailOptions.FromEmail,
                             settings.MailOptions.Password,
                             settings.MailOptions.Port,
                             settings.MailOptions.Host));


          


            services.AddSingleton(settings);
            services.AddJwt(settings);
            services.AddUseCases();
            services.AddAuthorization();

            services.AddApartmentContext();
            services.AddTransient<IExceptionLoger, ConsoleLogging>();
            services.AddTransient<IUseCaseLogger, UseCaseLogging>();

            services.AddControllers();
            services.AddTransient<ApartmentContext>();
            services.AddMapper();
            services.AddUser();
            services.AddUploadFile();


            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Apartment API", Version = "v1" });

                // Konfigurirajte Swagger da koristi JWT autentifikaciju
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                //Dokumentacija xml-a
                var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, xmlFilename));

              

                // Dodajte globalni filter za autorizaciju
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
              //  app.UseHttpsRedirection();
            }
            
            // app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "uploads")),
                RequestPath = "/api/uploads"
            });
            app.UseCors(myDefaultOrigins);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Apartment API");
                });
            }

          //  app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthorization();



            /*MIDDLEWERE*/
            app.UseMiddleware<GlobalExceptionHandler>();
           // app.UseMiddleware<RefreshTokenMiddleware>(); Middleware za refresh token trenutno nije moguce inmplementirati jer je potrebno u response zahteva vratiti novi token tako da za to postoji poseban endpoint (/api/user/refreshtoken)

            /*END MIDDLEWERE*/


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

