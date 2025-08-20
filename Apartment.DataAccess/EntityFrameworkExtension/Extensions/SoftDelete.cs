using Apartment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameworkExtension.Extensions
{

    public static class SoftDelete
    {
        public static void SetAuditProperties(this ChangeTracker changeTracker)
        {
            changeTracker.DetectChanges();
            IEnumerable<EntityEntry> entities =
                changeTracker
                    .Entries()
                    .Where(t => t.State == EntityState.Deleted);

            if (entities.Any())
            {
                foreach (EntityEntry entry in entities)
                {
                    var entity = entry.Entity as Entity;
                    if (entity != null)
                    {
                        entity.DeletedAt = DateTime.UtcNow;
                        entry.State = EntityState.Modified;
                    }
                }
            }
        }

       public static  LambdaExpression GetSoftDeleteFilter(Type type)
        {
            var parameter = Expression.Parameter(type, "e");
            var property = Expression.Property(parameter, "DeletedAt");
            var condition = Expression.Equal(property, Expression.Constant(null));
            var lambda = Expression.Lambda(condition, parameter);
            return lambda;
        }

    }

}