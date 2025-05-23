using Microsoft.EntityFrameworkCore;
using UsersTasks.API.Data.Models;

namespace UsersTasks.API.Data
{
	public class AppDBContext : DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<AppTask> AppTasks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(builder =>
			{
				builder.HasKey(u => u.Id);

				builder.Property(e => e.CreatedAt)
					.HasDefaultValueSql("GETDATE()");

				builder.HasMany(u => u.Tasks)
					.WithOne(t => t.User)
					.HasForeignKey(t => t.UserId)
					.OnDelete(DeleteBehavior.SetNull);
			});

			modelBuilder.Entity<AppTask>(builder =>
			{
				builder.HasKey(u => u.Id);

				builder.Property(e => e.CreatedAt)
					.HasDefaultValueSql("GETDATE()");
			});
		}
	}
}
