﻿using CrudEcole.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEcole.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TaskItem> TaskItems { get; set; }

    }
}
