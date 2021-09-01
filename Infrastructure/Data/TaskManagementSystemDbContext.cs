using ApplicationCore.Entities;
using TaskEntity = ApplicationCore.Entities.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class TaskManagementSystemDbContext : DbContext
    {
        public TaskManagementSystemDbContext(DbContextOptions<TaskManagementSystemDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<TaskHistory> TaskHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(ConfigureUserTable);
            modelBuilder.Entity<TaskEntity>(ConfigureTaskTable);
            modelBuilder.Entity<TaskHistory>(ConfigureTaskHistory);
        }

        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(u => u.Password).HasMaxLength(10).IsRequired().HasColumnType("varchar");
            builder.Property(u => u.FullName).HasMaxLength(50).HasColumnType("varchar");
            builder.Property(u => u.MobileNo).HasMaxLength(50).HasColumnType("varchar");
        }

        private void ConfigureTaskTable(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(t => t.Description).HasColumnType("varchar").HasMaxLength(500);
            builder.Property(t => t.DueDate).HasColumnType("datetime");
            builder.Property(t => t.Priority).HasColumnType("char");
            builder.Property(t => t.Remarks).HasColumnType("varchar").HasMaxLength(500);
        }

        private void ConfigureTaskHistory(EntityTypeBuilder<TaskHistory> builder)
        {
            builder.ToTable("Task_History");
            builder.HasKey(t => t.TaskId);
            builder.Property(t => t.Title).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(t => t.Description).HasColumnType("varchar").HasMaxLength(500);
            builder.Property(t => t.DueDate).HasColumnType("datetime");
            builder.Property(t => t.Completed).HasColumnType("datetime");
            builder.Property(t => t.Remarks).HasColumnType("varchar").HasMaxLength(500);
        }
    }
}
