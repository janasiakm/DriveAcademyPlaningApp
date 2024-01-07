using Domain.Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorCategoryModel> InstructorCategory { get; set; }
    }
}