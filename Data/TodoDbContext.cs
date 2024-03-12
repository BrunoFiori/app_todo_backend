﻿using App_Todo_Backend.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;

namespace App_Todo_Backend.Data
{
    public class TodoDbContext : IdentityDbContext<User>
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }        

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TodoConfiguration());        
        }
    }
}
