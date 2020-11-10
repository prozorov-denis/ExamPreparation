namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ExamPreparationDb : DbContext
    {
        public ExamPreparationDb()
            : base("name=ExamPreparationDb")
        {
        }

        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<Plans> Plans { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Solutions> Solutions { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Theory> Theory { get; set; }
        public virtual DbSet<Topics> Topics { get; set; }
        public virtual DbSet<User_Types> User_Types { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Messages>()
                .Property(e => e.Message_Text)
                .IsUnicode(false);

            modelBuilder.Entity<Plans>()
                .HasMany(e => e.Modules)
                .WithRequired(e => e.Plans)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Solutions>()
                .Property(e => e.Solution_Text)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Students)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.Plans)
                .WithRequired(e => e.Students)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Students)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tasks>()
                .Property(e => e.Task_Text)
                .IsUnicode(false);

            modelBuilder.Entity<Tasks>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<Tasks>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Tasks)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tasks>()
                .HasOptional(e => e.Solutions)
                .WithRequired(e => e.Tasks);

            modelBuilder.Entity<Teachers>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Teachers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topics>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Topics>()
                .HasMany(e => e.Modules)
                .WithRequired(e => e.Topics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topics>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Topics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topics>()
                .HasMany(e => e.Theory)
                .WithRequired(e => e.Topics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_Types>()
                .Property(e => e.User_Type)
                .IsUnicode(false);

            modelBuilder.Entity<User_Types>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.User_Types)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Second_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasOptional(e => e.Students)
                .WithRequired(e => e.Users);

            modelBuilder.Entity<Users>()
                .HasOptional(e => e.Teachers)
                .WithRequired(e => e.Users);
        }
    }
}
