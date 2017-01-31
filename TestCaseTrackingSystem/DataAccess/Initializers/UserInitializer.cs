﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Initializers
{
    internal class UserInitializer : EntityInitializerBase<User>
    {
        protected override IEnumerable<User> BuiltInEntities => new[]
        {
            new User
            {
                ID = 1,
                RoleID = 1,
                Login = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@tcts.by",
                Password = "admin",
                LastLogin = null,
                CreatedDate = DateTime.Now,
                Locked = false
            } 
        };

        public override void InitializeData(TestCaseDataContext dbContext)
        {
            // User roles need to be initialized prior to adding new user
            TestCaseDataContextInitializer.Instance[typeof(UserRolesInitializer)].InitializeData(dbContext);

            base.InitializeData(dbContext);
        }

        public override void InitializeModel(DbModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<User>();

            entity.HasKey(t => t.ID).Property(t => t.ID).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            entity.Property(t => t.RoleID).IsRequired();
            entity.Property(t => t.Login).IsRequired();
            entity.Property(t => t.FirstName).IsRequired();
            entity.Property(t => t.LastName).IsRequired();
            entity.Property(t => t.Email).IsRequired();
            entity.Property(t => t.Password).IsRequired();
            entity.Property(t => t.LastLogin).IsOptional();
            entity.Property(t => t.CreatedDate).IsRequired();
            entity.Property(t => t.Locked).IsRequired();
        }
    }
}
