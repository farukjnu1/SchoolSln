using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataModels.EntityModels.SchoolModel
{
    public partial class AdmissionContext : DbContext
    {
        public AdmissionContext()
        {
        }

        public AdmissionContext(DbContextOptions<AdmissionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual DbSet<InvoiceType> InvoiceType { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentPosition> StudentPosition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Admission;User Id=sa; Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceTotal).HasColumnName("invoice_total");

                entity.Property(e => e.PaidAmount).HasColumnName("paid_amount");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("invoice_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.Unit).HasColumnName("unit");
            });

            modelBuilder.Entity<InvoiceType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("invoice_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("section");

                entity.Property(e => e.SectionId).HasColumnName("section_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("shift");

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasColumnName("bloodGroup")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile).HasColumnName("mobile");

                entity.Property(e => e.Religion)
                    .HasColumnName("religion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentPosition>(entity =>
            {
                entity.ToTable("student_position");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdmissionDate)
                    .HasColumnName("admission_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.LastSchoolName)
                    .HasColumnName("last_School_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RollNo).HasColumnName("roll_No");

                entity.Property(e => e.SectionEndDate)
                    .HasColumnName("section_End_Date")
                    .HasColumnType("date");

                entity.Property(e => e.SectionId).HasColumnName("section_id");

                entity.Property(e => e.SectionStartDate)
                    .HasColumnName("sectionStart_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
