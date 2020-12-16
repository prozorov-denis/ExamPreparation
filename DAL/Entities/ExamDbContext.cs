using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class ExamDbContext : DbContext
    {
        public ExamDbContext()
            : base("name=ExamDbContext")
        {
        }

        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Task)
                .WithRequired(e => e.Topic)
                .WillCascadeOnDelete(false);
        }
    }
}
