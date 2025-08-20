using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Comment;
using Apartment.DataAccess;
using Apartment.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Comment
{
    public class DeleteCommentYourSelfCommand : EfBase, IDeleteCommentYourSelfCommand
    {
        IUser user;
        public DeleteCommentYourSelfCommand(ApartmentContext context, IMapper mapper, IUser user) : base(context, mapper)
        {
            this.user = user;
        }

        public int Id =>54;

        public string Name => "User Delete his comment - Ef";

        public string Description => "Deleteing comment and all his children!";

        public void Execute(int request)
        {
            var comment = Context.Comments.Find(request);
            if (comment == null) throw new EntityNotFoundException("Comment",request);
            if(comment.UserId != user.Id) throw new ForbiddenUseCaseExec(Name,user.FirstName + " " + user.LastName);

            var children = comment.ChildComments.ToList();


            if (children.Count == 0)
            {
                Context.Comments.Remove(comment);
            }
            else
            {
                DeleteChildComment(children,Context);
                Context.Comments.Remove(comment);
            }

            Context.SaveChanges();

        }
        
        public static void DeleteChildComment(IEnumerable<Domain.Entities.Comment> comments, ApartmentContext Context)
        {
            foreach (var child in comments)
            {
                if (child.ChildComments.Count > 0)
                {
                    Context.Comments.Remove(child);
                }
                else
                {
                    DeleteCommentYourSelfCommand.DeleteChildComment(child.ChildComments, Context);
                    Context.Comments.Remove(child);
                }
            }
        }
    }
}
