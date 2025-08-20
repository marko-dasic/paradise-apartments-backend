using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Comment;
using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Comment
{
    public class DeleteCommentCommand : EfBase, IDeleteCommentCommand
    {
        public DeleteCommentCommand(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 29;

        public string Name => "Delete comment from Admin - EF";

        public string Description => "Admin can delete comment from everyone!";

        public void Execute(int request)
        {
            var comment = Context.Comments.Find(request);
            if(comment == null) { throw new EntityNotFoundException("Comment", request); }

            var children = comment.ChildComments.ToList();

            if(children.Count() == 0)
            {
                Context.Comments.Remove(comment);
            }
            else
            {
                DeleteCommentYourSelfCommand.DeleteChildComment(children, Context);
                Context.Comments.Remove(comment);
            }

            Context.SaveChanges();


        }
    }
}
