using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DB1_AcmeInstituteofLooning.AcmeModels;

namespace DB1_AcmeInstituteofLooning.AcmeData
{
    public partial class AcmeContext : DbContext
    {
        public AcmeContext()
        {
        }

        public AcmeContext(DbContextOptions<AcmeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcmeAdministrator> AcmeAdministrators { get; set; } = null!;
        public virtual DbSet<AcmeClass> AcmeClasses { get; set; } = null!;
        public virtual DbSet<AcmeClassRoom> AcmeClassRooms { get; set; } = null!;
        public virtual DbSet<AcmeCourse> AcmeCourses { get; set; } = null!;
        public virtual DbSet<AcmeCourseGrade> AcmeCourseGrades { get; set; } = null!;
        public virtual DbSet<AcmeDept> AcmeDepts { get; set; } = null!;
        public virtual DbSet<AcmePerson> AcmePeople { get; set; } = null!;
        public virtual DbSet<AcmeStudent> AcmeStudents { get; set; } = null!;
        public virtual DbSet<AcmeTeacher> AcmeTeachers { get; set; } = null!;
        public virtual DbSet<ApcontactInfo> ApcontactInfos { get; set; } = null!;
        public virtual DbSet<ContactIce> ContactIces { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=FIZZYGOOD_3060\\; Initial Catalog=Acme_InstitutionofLooning;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcmeAdministrator>(entity =>
            {
                entity.HasKey(e => e.AadminId);

                entity.ToTable("AcmeAdministrator");

                entity.Property(e => e.AadminId).HasColumnName("AAdminID");

                entity.Property(e => e.AadminMail)
                    .HasMaxLength(80)
                    .HasColumnName("AAdminMail");

                entity.Property(e => e.EndofService).HasColumnType("date");

                entity.Property(e => e.FkApid).HasColumnName("FK_APID");

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.FkAp)
                    .WithMany(p => p.AcmeAdministrators)
                    .HasForeignKey(d => d.FkApid)
                    .HasConstraintName("FK_AcmeAdministrator_AcmePerson");
            });

            modelBuilder.Entity<AcmeClass>(entity =>
            {
                entity.HasKey(e => e.AclassId);

                entity.ToTable("AcmeClass");

                entity.Property(e => e.AclassId).HasColumnName("AClassID");

                entity.Property(e => e.ClassName).HasMaxLength(20);

                entity.Property(e => e.FkAteacherId).HasColumnName("FK_ATeacherID");

                entity.Property(e => e.GraduationDate).HasColumnType("date");

                entity.Property(e => e.YearGroup).HasColumnType("date");
            });

            modelBuilder.Entity<AcmeClassRoom>(entity =>
            {
                entity.HasKey(e => e.AcroomId);

                entity.ToTable("AcmeClassRoom");

                entity.Property(e => e.AcroomId).HasColumnName("ACRoomID");

                entity.Property(e => e.FkAadminId).HasColumnName("FK_AAdminID");

                entity.Property(e => e.FkAclassId).HasColumnName("FK_AClassID");

                entity.Property(e => e.FkAcourseId).HasColumnName("FK_ACourseID");

                entity.Property(e => e.FkAdeptIdlocation).HasColumnName("FK_ADeptIDLocation");

                entity.HasOne(d => d.FkAadmin)
                    .WithMany(p => p.AcmeClassRooms)
                    .HasForeignKey(d => d.FkAadminId)
                    .HasConstraintName("FK_AcmeClassRoom_AcmeAdministrator");

                entity.HasOne(d => d.FkAclass)
                    .WithMany(p => p.AcmeClassRooms)
                    .HasForeignKey(d => d.FkAclassId)
                    .HasConstraintName("FK_AcmeClassRoom_AcmeClass");

                entity.HasOne(d => d.FkAcourse)
                    .WithMany(p => p.AcmeClassRooms)
                    .HasForeignKey(d => d.FkAcourseId)
                    .HasConstraintName("FK_AcmeClassRoom_AcmeCourse");

                entity.HasOne(d => d.FkAdeptIdlocationNavigation)
                    .WithMany(p => p.AcmeClassRooms)
                    .HasForeignKey(d => d.FkAdeptIdlocation)
                    .HasConstraintName("FK_AcmeClassRoom_AcmeDept");
            });

            modelBuilder.Entity<AcmeCourse>(entity =>
            {
                entity.HasKey(e => e.AcourseId);

                entity.ToTable("AcmeCourse");

                entity.Property(e => e.AcourseId).HasColumnName("ACourseID");

                entity.Property(e => e.CourseEnd).HasColumnType("date");

                entity.Property(e => e.CourseStart).HasColumnType("date");

                entity.Property(e => e.FkAteacherId).HasColumnName("FK_ATeacherID");

                entity.Property(e => e.Subject).HasMaxLength(30);

                entity.HasOne(d => d.FkAteacher)
                    .WithMany(p => p.AcmeCourses)
                    .HasForeignKey(d => d.FkAteacherId)
                    .HasConstraintName("FK_AcmeCourse_AcmeTeacher");
            });

            modelBuilder.Entity<AcmeCourseGrade>(entity =>
            {
                entity.HasKey(e => e.AgradeId);

                entity.ToTable("AcmeCourseGrade");

                entity.Property(e => e.AgradeId).HasColumnName("AGradeID");

                entity.Property(e => e.DateSet).HasColumnType("datetime");

                entity.Property(e => e.FkAcourseId).HasColumnName("FK_ACourseID");

                entity.Property(e => e.FkAstudentId).HasColumnName("FK_AStudentID");

                entity.Property(e => e.FkAteacherId).HasColumnName("FK_ATeacherID");

                entity.HasOne(d => d.FkAcourse)
                    .WithMany(p => p.AcmeCourseGrades)
                    .HasForeignKey(d => d.FkAcourseId)
                    .HasConstraintName("FK_AcmeCourseGrade_AcmeCourse");

                entity.HasOne(d => d.FkAstudent)
                    .WithMany(p => p.AcmeCourseGrades)
                    .HasForeignKey(d => d.FkAstudentId)
                    .HasConstraintName("FK_AcmeCourseGrade_AcmeStudent1");

                entity.HasOne(d => d.FkAteacher)
                    .WithMany(p => p.AcmeCourseGrades)
                    .HasForeignKey(d => d.FkAteacherId)
                    .HasConstraintName("FK_AcmeCourseGrade_AcmeTeacher1");
            });

            modelBuilder.Entity<AcmeDept>(entity =>
            {
                entity.HasKey(e => e.AdeptId);

                entity.ToTable("AcmeDept");

                entity.Property(e => e.AdeptId).HasColumnName("ADeptID");

                entity.Property(e => e.DeptBudget).HasColumnType("money");

                entity.Property(e => e.DeptName).HasMaxLength(30);
            });

            modelBuilder.Entity<AcmePerson>(entity =>
            {
                entity.HasKey(e => e.Apid);

                entity.ToTable("AcmePerson");

                entity.Property(e => e.Apid).HasColumnName("APID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Concern).HasMaxLength(25);

                entity.Property(e => e.FkAdeptId).HasColumnName("FK_ADeptID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(30)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(30)
                    .HasColumnName("LName");

                entity.HasOne(d => d.FkAdept)
                    .WithMany(p => p.AcmePeople)
                    .HasForeignKey(d => d.FkAdeptId)
                    .HasConstraintName("FK_AcmePerson_AcmeDept");
            });

            modelBuilder.Entity<AcmeStudent>(entity =>
            {
                entity.HasKey(e => e.AstudentId);

                entity.ToTable("AcmeStudent");

                entity.Property(e => e.AstudentId).HasColumnName("AStudentID");

                entity.Property(e => e.AdmissionDate).HasColumnType("date");

                entity.Property(e => e.AstudentMail)
                    .HasMaxLength(80)
                    .HasColumnName("AStudentMail");

                entity.Property(e => e.FkAclassId).HasColumnName("FK_AClassID");

                entity.Property(e => e.FkApid).HasColumnName("FK_APID");

                entity.Property(e => e.GraduationDate).HasColumnType("date");

                entity.HasOne(d => d.FkAclass)
                    .WithMany(p => p.AcmeStudents)
                    .HasForeignKey(d => d.FkAclassId)
                    .HasConstraintName("FK_AcmeStudent_AcmeClass");

                entity.HasOne(d => d.FkAp)
                    .WithMany(p => p.AcmeStudents)
                    .HasForeignKey(d => d.FkApid)
                    .HasConstraintName("FK_AcmeStudent_AcmePerson");
            });

            modelBuilder.Entity<AcmeTeacher>(entity =>
            {
                entity.HasKey(e => e.AteacherId);

                entity.ToTable("AcmeTeacher");

                entity.Property(e => e.AteacherId).HasColumnName("ATeacherID");

                entity.Property(e => e.AteacherMail)
                    .HasMaxLength(80)
                    .HasColumnName("ATeacherMail");

                entity.Property(e => e.FkApid).HasColumnName("FK_APID");

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.FkAp)
                    .WithMany(p => p.AcmeTeachers)
                    .HasForeignKey(d => d.FkApid)
                    .HasConstraintName("FK_AcmeTeacher_AcmePerson");
            });

            modelBuilder.Entity<ApcontactInfo>(entity =>
            {
                entity.HasKey(e => e.AcontactId);

                entity.ToTable("APContactInfo");

                entity.Property(e => e.AcontactId).HasColumnName("AContactID");

                entity.Property(e => e.Address).HasMaxLength(30);

                entity.Property(e => e.AltTel).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .HasColumnName("EMail");

                entity.Property(e => e.FkApid).HasColumnName("FK_APID");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.PostalCode).HasMaxLength(15);

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.HasOne(d => d.FkAp)
                    .WithMany(p => p.ApcontactInfos)
                    .HasForeignKey(d => d.FkApid)
                    .HasConstraintName("FK_APContactInfo_AcmePerson");
            });

            modelBuilder.Entity<ContactIce>(entity =>
            {
                entity.HasKey(e => e.Iceid);

                entity.ToTable("ContactICE");

                entity.Property(e => e.Iceid).HasColumnName("ICEID");

                entity.Property(e => e.AltTel).HasMaxLength(20);

                entity.Property(e => e.Connection).HasMaxLength(20);

                entity.Property(e => e.FkAcontactId).HasColumnName("FK_AContactID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(30)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(30)
                    .HasColumnName("LName");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.HasOne(d => d.FkAcontact)
                    .WithMany(p => p.ContactIces)
                    .HasForeignKey(d => d.FkAcontactId)
                    .HasConstraintName("FK_ContactICE_APContactInfo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
