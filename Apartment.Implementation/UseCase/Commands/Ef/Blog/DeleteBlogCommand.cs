using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Blog;
using Apartment.Application.UseCase.Commands.Category;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
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
    public class DeleteBlogCommand : EfBase, IDeleteBlogCommand
    {
        public DeleteBlogCommand(ApartmentContext context) : base(context,null)
        {
        }

        public int Id => 6;

        public string Name => "Delete Blog - EF";

        public string Description =>"";

        public void Execute(int request)
        {
            var obj = Context.Blogs.Find(request);
            if (obj == null) throw new EntityNotFoundException("Blog", request);
            Context.Blogs.Remove(obj);
            Context.SaveChanges();
        }
    }
}
