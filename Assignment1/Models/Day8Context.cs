using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Assignment1.Models
{
    public partial class Day8Context : DbContext
    {
        public Day8Context()
        {
        }

        public Day8Context(DbContextOptions<Day8Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cust> Cust { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
