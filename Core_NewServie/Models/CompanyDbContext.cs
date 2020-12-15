using System;
using Microsoft.EntityFrameworkCore;

namespace Core_NewServie.Models
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Read the Connection String from the DI Container
        /// from the ConfigureServices() method of the Startup class
        /// </summary>
        /// <param name="options"></param>
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Department)  // Emp has One Dept
                        .WithMany(e => e.Employees) // One Dept Contans Miltiple Emps
                        .HasForeignKey(e => e.DeptNo); // ForeignKey as DeptNo
        }
    }
}
