using System;
using EFCore2DBFirst.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace EFCore2DBFirst
{
    public partial class helloappContext : DbContext
    {
        public helloappContext()
        {
        }

        public helloappContext(DbContextOptions<helloappContext> options)
            : base(options)
        {
	        Database.EnsureDeleted();
	        Database.EnsureCreated();

	        var ableToConnect = Database.CanConnect();
        }

        public virtual DbSet<User> Users { get; set; } = null!;

        public DbSet<Company> Companies { get; set; }

        public DbSet<ColorReferenceBook> Colours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
				#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=G:\\\\\\\\LEARNING\\\\\\\\NET\\\\\\\\EntityFrameworkCore\\\\\\\\MetanitLearning\\\\\\\\EFCore2DBFirst\\\\\\\\helloapp.db");
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
                //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Trace);
                optionsBuilder.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted }); // надо вывести только выполняемые команды SQL
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.ApplyConfiguration(new ColorReferenceBookConfiguration());
            modelBuilder.Entity<User>().Ignore(x => x.SomePrtyThatShouldBeIgnored);
            modelBuilder.Entity<User>().HasCheckConstraint("Age", "Age > 0 AND Age < 120");
            //modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasDefaultValueSql("DATETIME('now')");
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
