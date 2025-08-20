using Apartment.Application.UseCase.Commands.Blog;
using Apartment.Application.UseCase.Commands.Category;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using Apartment.Domain.Entities;
using Apartment.Implementation.UseCase.UploadImages;
using Apartment.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Category
{
    public class UpdateBlogCommand : EfBase, IUpdateBlogCommand
    {
        private UploaderImages uploader;
        public UpdateBlogCommand(UploaderImages uploader,ApartmentContext context) : base(context,null)
        {
            this.uploader = uploader;
        }

        public int Id => 6;

        public string Name => "Update Blog - EF";

        public string Description =>"";

        public void Execute(UpdateBlogDto request)
        {
            var obj = Context.Blogs.Find(request.Id);  
            File file; 
            if(!string.IsNullOrEmpty(request.FileBase64))
            {
                file = uploader.UploadImageForBlog(request.FileBase64);
                obj.File = file;

            }
            obj.Title = request.Title;
            obj.Adress = request.Adress;
            obj.Content = request.Content;
            obj.GoogleMap = request.GoogleMap;
            obj.WorkTime = request.WorkTime;
            Context.SaveChanges();
        }
    }
}
