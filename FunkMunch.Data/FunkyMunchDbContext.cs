using FunkyMunch.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunkyMunch.Data
{
    public class FunkyMunchDbContext : DbContext
    {
        public FunkyMunchDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
