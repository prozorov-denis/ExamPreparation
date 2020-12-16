using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class ExamPreparationDb : DbContext
    {
        public ExamPreparationDb()
            : base("name=ExamPreparationDb")
        {
        }

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<User_Type> User_Type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(e => e.Message_Text)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Solution_Text)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Message)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Module)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Result)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Task_Text)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.Result)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Message)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Theory_Text)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Module)
                .WithRequired(e => e.Topic)
                .WillCascadeOnDelete(false);

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
                .Property(e => e.Second_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Student)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Teacher)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User_Type>()
                .Property(e => e.User_Type1)
                .IsUnicode(false);

            modelBuilder.Entity<User_Type>()
                .HasMany(e => e.User)
                .WithRequired(e => e.User_Type)
                .WillCascadeOnDelete(false);
        }
    }
}
