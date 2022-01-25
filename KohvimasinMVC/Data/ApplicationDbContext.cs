using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using KohvimasinMVC.Models;
using KohvimasinMVC.Data;

namespace KohvimasinMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<KohvimasinMVC.Data.Kohvimasin> Kohvimasin { get; set; }
    }
}
