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
    public class CreateBlogCommand : EfBase, ICreateBlogCommand
    {
        private UploaderImages uploader;
        public CreateBlogCommand(UploaderImages uploader,ApartmentContext context) : base(context,null)
        {
            this.uploader = uploader;
        }

        public int Id => 6;

        public string Name => "Create Blog - EF";

        public string Description =>"";

        public void Execute(CreateBlogDto request)
        {
            var obj = new Domain.Entities.Blog
            {
                Content = request.Content,
                Title = request.Title,
                GoogleMap = request.GoogleMap,
                Adress = request.Adress,
                WorkTime = request.WorkTime
            };
            if(!string.IsNullOrEmpty(request.FileBase64))  
            {
                File file;
                file = uploader.UploadImageForBlog(request.FileBase64);
                obj.File = file;
            }
            Context.Blogs.Add(obj);
            Context.SaveChanges();
        }
    }
}
