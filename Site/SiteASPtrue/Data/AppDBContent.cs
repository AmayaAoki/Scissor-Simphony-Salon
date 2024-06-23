

using Microsoft.EntityFrameworkCore;
using SiteASP.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteASP.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) :base(options) { }
         // Указываем имя таблицы
        public DbSet<Services> Service {  get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }
        //добавление записи
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Contact> Contact { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Указываем имя таблицы для модели Services
            modelBuilder.Entity<Services>().ToTable("ListOfServices");
            // Указываем имя таблицы для модели Category
            modelBuilder.Entity<Category>().ToTable("ServicesCategory");
            // Указываем имя таблицы для модели User
            modelBuilder.Entity<User>().ToTable("Clients");
            //Указываем имя таблицы для модели Employee
            modelBuilder.Entity<Employee>().ToTable("Employee");
            //Указываем имя таблицы для модели Records
            modelBuilder.Entity<Contact>().ToTable("FAQ");
        }
        
    }
}
