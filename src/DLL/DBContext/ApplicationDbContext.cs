﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using DLL.Model;
using DLL.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DLL.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        private const string IsDeletedProperty = "IsDeleted";

        private static readonly MethodInfo _propertyMethod = typeof(EF)
            .GetMethod(nameof(EF.Property), BindingFlags.Static | BindingFlags.Public)?.MakeGenericMethod(typeof(bool));
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
            
        }

        private static LambdaExpression GetIsDeletedRestriction(Type type)
        {
            var parm = Expression.Parameter(type, "it");
            var prop = Expression.Call(_propertyMethod, parm, Expression.Constant(IsDeletedProperty));
            var condition = Expression.MakeBinary(ExpressionType.Equal, prop, Expression.Constant(false));
            var lambda = Expression.Lambda(condition, parm);
            return lambda;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entity.ClrType) == true)
                {
                    entity.AddProperty(IsDeletedProperty, typeof(bool));
                    modelBuilder.Entity(entity.ClrType).HasQueryFilter(GetIsDeletedRestriction(entity.ClrType));
                }
            }
            base.OnModelCreating(modelBuilder);
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSavingData();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void OnBeforeSavingData()
        {
            var enteries = ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Detached && x.State != EntityState.Unchanged);
            foreach (var entry in enteries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                   
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            trackable.CreatedAt = DateTimeOffset.Now;
                            trackable.LastUpdatedAt = DateTimeOffset.Now;
                            break;
                        case EntityState.Modified :
                            trackable.LastUpdatedAt = DateTimeOffset.Now;
                            break;
                        case EntityState.Deleted:
                            entry.Property(IsDeletedProperty).CurrentValue = true;
                            entry.State = EntityState.Modified;
                            break;
                    } 
                }

            }
        } 

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSavingData();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}