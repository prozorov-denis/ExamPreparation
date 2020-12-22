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

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studying> Studying { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskResult> TaskResult { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.TaskText)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.SolutionText)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Task)
                .WithRequired(e => e.Topic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Student)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Teacher)
                .WithRequired(e => e.User);

            modelBuilder.Entity<UserType>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
