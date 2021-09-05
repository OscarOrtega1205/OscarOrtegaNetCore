using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OscarOrtegaMartinez.Models.EntityModels
{
    public partial class OscarOrtegaDBContext : DbContext
    {
        public OscarOrtegaDBContext()
        {
        }

        public OscarOrtegaDBContext(DbContextOptions<OscarOrtegaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClassRoom> ClassRoom { get; set; }
        public virtual DbSet<ClassRoomCourse> ClassRoomCourse { get; set; }
        public virtual DbSet<ClassRoomStudent> ClassRoomStudent { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MXZAPM8LT160\\SQLEXPRESS;Database=OscarOrtegaDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoom>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.ClassRoom)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__ClassRoom__Enabl__2F10007B");
            });

            modelBuilder.Entity<ClassRoomCourse>(entity =>
            {
                entity.ToTable("ClassRoom_Course");

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.HasOne(d => d.ClassRoom)
                    .WithMany(p => p.ClassRoomCourse)
                    .HasForeignKey(d => d.ClassRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassRoom__Enabl__37A5467C");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.ClassRoomCourse)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassRoom__Cours__38996AB5");
            });

            modelBuilder.Entity<ClassRoomStudent>(entity =>
            {
                entity.ToTable("ClassRoom_Student");

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.HasOne(d => d.ClassRoom)
                    .WithMany(p => p.ClassRoomStudent)
                    .HasForeignKey(d => d.ClassRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassRoom__Enabl__31EC6D26");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassRoomStudent)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassRoom__Stude__32E0915F");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Updated).HasColumnType("datetime");
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.Property(e => e.CourseName).HasMaxLength(75);

                entity.Property(e => e.Marks).HasMaxLength(45);

                entity.Property(e => e.StudentLastName).HasMaxLength(75);

                entity.Property(e => e.StudentName).HasMaxLength(75);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Results__CourseI__3C69FB99");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Results__Enabled__3B75D760");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Updated).HasColumnType("datetime");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.ControlNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Student__Enabled__29572725");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Teacher__Enabled__2C3393D0");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__Enabled__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
