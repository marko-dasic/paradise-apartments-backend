using Apartment.Application.Exceptions;
using Apartment.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.UploadImages
{
    public class UploaderImages
    {
        private string uploadsFolder;
        private readonly IWebHostEnvironment _environment;
        private readonly ApartmentContext Context;
        IHttpContextAccessor httpContextAccessor;
        public UploaderImages(IWebHostEnvironment _environment, IHttpContextAccessor httpContextAccessor, ApartmentContext Context)
        {
            this._environment = _environment;
            this.uploadsFolder = "uploads";
            this.Context = Context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public  void UploadImages(IEnumerable<string> request, Domain.Entities.Apartment apartment, bool isThumb )
        {
            if (request == null) throw new BadRequestException();
            if (!request.Any()) throw new BadRequestException();
         

            foreach (var file in request)
            {
                if (file == null || file.Length == 0)
                {
                    throw new BadRequestException();
                }
                byte[] imageBytes = Convert.FromBase64String(file);

                string extension = GetImageExtensionFromBase64(file);

                string uniqueFileName = Guid.NewGuid().ToString() + "." + extension;

                string fileName = Path.Combine(_environment.ContentRootPath, uploadsFolder, uniqueFileName);


                string[] allowedExtensions = { "jpg", "jpeg", "png", "gif" };

                if (!allowedExtensions.Contains(extension))
                {
                    throw new WrongFileExtensionsException("Neispravan format fajla. Podrzani formati su: JPG, JPEG, PNG, GIF");
                }

                double fileSizeKB = Math.Round(imageBytes.Length / 1024.0, 2);

                if (fileSizeKB > 4048)
                {
                    throw new BadRequestException("Slika nesme biti veca od 4 MB!");
                }

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                System.IO.File.WriteAllBytes(fileName, imageBytes);


                // Proverava se da li se dodaje thumb slika ili opsta slika 
                if (isThumb)
                {
                    //Context.Files.Remove(Context.Files.Where(x => x.Id == apartment.FileId).FirstOrDefault());
                    apartment.Thumb = new Domain.Entities.File
                    {
                        Path = uniqueFileName,
                        Alt = uniqueFileName,
                        Extension = extension,
                        Size = fileSizeKB
                    };
                }
                else
                {
                    //   Context.Images.RemoveRange(Context.Images.Where(x => x.ApartmentId == apartment.Id).ToList());
                    Context.Images.Add(new Domain.Entities.Image
                    {
                        File = new Domain.Entities.File
                        {
                            Path = uniqueFileName,
                            Alt = uniqueFileName,
                            Extension = extension,
                            Size = fileSizeKB
                        },
                        Apartment = apartment
                    });
                  
                }
                


            }


        }
        public Domain.Entities.File UploadImageForBlog(string file){
            if (file == null || file.Length == 0)
                {
                    throw new BadRequestException();
                }
                byte[] imageBytes = Convert.FromBase64String(file);

                string extension = GetImageExtensionFromBase64(file);

                string uniqueFileName = Guid.NewGuid().ToString() + "." + extension;

                string fileName = Path.Combine(_environment.ContentRootPath, uploadsFolder, uniqueFileName);


                string[] allowedExtensions = { "jpg", "jpeg", "png", "gif" };

                if (!allowedExtensions.Contains(extension))
                {
                    throw new WrongFileExtensionsException("Neispravan format fajla. Podrzani formati su: JPG, JPEG, PNG, GIF");
                }

                double fileSizeKB = Math.Round(imageBytes.Length / 1024.0, 2);

                if (fileSizeKB > 4048)
                {
                    throw new BadRequestException("Slika nesme biti veca od 4 MB!");
                }

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                System.IO.File.WriteAllBytes(fileName, imageBytes);

                 Domain.Entities.File obj = new Domain.Entities.File
                {
                    Path = uniqueFileName,
                    Alt = uniqueFileName,
                    Extension = extension,
                    Size = fileSizeKB
                };
                return obj;

        }
        private  string GetImageExtensionFromBase64(string base64Image)
        {

            var data = base64Image.Substring(0, 5).ToUpper();

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "/9J/2":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return string.Empty;
            }

        }
        
    
    }
}
