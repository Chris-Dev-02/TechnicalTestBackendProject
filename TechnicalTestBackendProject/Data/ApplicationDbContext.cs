using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechnicalTestBackendProject.Models;
using TaskModel = TechnicalTestBackendProject.Models.TaskModel;

namespace TechnicalTestBackendProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<BoardModel> Boards { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
