using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Category;
using Apartment.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apartment.Implementation.UseCase.Commands.Ef.Category
{
    public class DeleteCategoryCommand : EfBase, IDeleteCategoryCommand
    {
        public DeleteCategoryCommand(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 72;

        public string Name => "Delete Category - EF";

        public string Description => "";

        public void Execute(int request)
        {
            var obj = Context.Categories.Find(request);
            if (obj == null) throw new EntityNotFoundException("Category", request);
            Context.Categories.Remove(obj);
            Context.SaveChanges();
        }
    }
}
