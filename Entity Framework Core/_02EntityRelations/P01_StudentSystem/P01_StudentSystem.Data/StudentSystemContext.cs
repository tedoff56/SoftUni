using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        private const string CONNECTION_STRING = 
            @"Server=TEDOFF\SQLEXPRESS;
              Database=StudentSystem;
              Intergrated Security=True";
        
        public StudentSystemContext()
        {
            
        }

        public StudentSystemContext(DbContextOptions options)
        :base(options)
        {
            
        }

        public virtual DbSet<Student> Students { get; set; }
        
        public virtual DbSet<Course> Courses { get; set; }
                
        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(CONNECTION_STRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentCourse>(e =>
            {
                e.HasKey(pk => new { pk.CourseId, pk.StudentId });
            });
        }
    }
}