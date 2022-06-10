using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IBM.Models;

namespace IBM.Data
{
    public partial class IBMContext : DbContext
    {
        public IBMContext()
        {
        }

        public IBMContext(DbContextOptions<IBMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactDetail> ContactDetails { get; set; } = null!;
        public virtual DbSet<PersonalDetail> PersonalDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<ContactDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contact_details");

                entity.HasIndex(e => e.EmergencyContact, "Emergency_contact_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "Phone_number_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.TelephoneNumber, "Telephone_number_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.BaseLocation)
                    .HasMaxLength(30)
                    .HasColumnName("Base_location");

                entity.Property(e => e.CurrentAddress)
                    .HasMaxLength(45)
                    .HasColumnName("Current_address");

                entity.Property(e => e.CurrentLocation)
                    .HasMaxLength(45)
                    .HasColumnName("Current_location");

                entity.Property(e => e.EmergencyContact).HasColumnName("Emergency_contact");

                entity.Property(e => e.EmergencyContactName).HasColumnName("Emergency_contact_name");

                entity.Property(e => e.IbmAddress)
                    .HasMaxLength(45)
                    .HasColumnName("IBM_address");

                entity.Property(e => e.LocationChangeDate).HasColumnName("Location_change_date");

                entity.Property(e => e.Organisation).HasMaxLength(45);

                entity.Property(e => e.PermanentAddress)
                    .HasMaxLength(45)
                    .HasColumnName("Permanent_address");

                entity.Property(e => e.PhoneNumber).HasColumnName("Phone_number");

                entity.Property(e => e.TelephoneNumber).HasColumnName("Telephone_number");
            });

            modelBuilder.Entity<PersonalDetail>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PRIMARY");

                entity.ToTable("personal_details");

                entity.HasIndex(e => e.EmployeeId, "Employee_ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IbmEmailId, "IBM_Email_ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.NylEmailId, "NYL_Email_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Employee_ID");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(45)
                    .HasColumnName("Employee_name");

                entity.Property(e => e.EmployeeType)
                    .HasMaxLength(45)
                    .HasColumnName("Employee_type");

                entity.Property(e => e.ExpectedClientRole)
                    .HasMaxLength(45)
                    .HasColumnName("Expected_client_role");

                entity.Property(e => e.ExpectedIbmRole)
                    .HasMaxLength(45)
                    .HasColumnName("Expected_IBM_role");

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.IbmEmailId)
                    .HasMaxLength(45)
                    .HasColumnName("IBM_Email_ID");

                entity.Property(e => e.NylEmailId)
                    .HasMaxLength(45)
                    .HasColumnName("NYL_Email_ID");

                entity.Property(e => e.PeopleManager)
                    .HasMaxLength(45)
                    .HasColumnName("People_Manager");

                entity.Property(e => e.PrimaryNylTeam)
                    .HasMaxLength(45)
                    .HasColumnName("Primary_NYL_team");

                entity.Property(e => e.PrimaryVertical)
                    .HasMaxLength(45)
                    .HasColumnName("Primary_vertical");

                entity.Property(e => e.StartDateInIbm).HasColumnName("Start_date_in_IBM");

                entity.Property(e => e.StartDateInNyl).HasColumnName("Start_date_in_NYL");

                entity.Property(e => e.T57Id)
                    .HasMaxLength(15)
                    .HasColumnName("T57_ID");

                entity.Property(e => e.TotalExperienceInInsurance)
                    .HasMaxLength(45)
                    .HasColumnName("Total_experience_in_insurance");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}