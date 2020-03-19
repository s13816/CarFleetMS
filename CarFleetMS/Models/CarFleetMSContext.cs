using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CarFleetMS.Models;

namespace CarFleetMS.Models
{
    public partial class CarFleetMSContext : IdentityDbContext
    {
        public CarFleetMSContext()
        {
        }

        public CarFleetMSContext(DbContextOptions<CarFleetMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Ensurance> Ensurance { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<PersonCompany> PersonCompany { get; set; }
        public virtual DbSet<Repair> Repair { get; set; }
        public virtual DbSet<TechnicalExamination> TechnicalExamination { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleAnnotations> VehicleAnnotations { get; set; }
        public virtual DbSet<VehicleCategory> VehicleCategory { get; set; }
        public virtual DbSet<Rent> Rent { get; set; }
        public virtual DbSet<VehicleType> VehicleType { get; set; }
        public virtual DbSet<FuelType> FuelType { get; set; } //--------------------------------------------
        public virtual DbSet<Institution> Institution { get; set; } //--------------------------------------------

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarFleetMSV2;Trusted_Connection=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.Property(e => e.InstitutionId);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.DriverId);

                entity.HasOne(d => d.PersonCompany)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.PersonCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Driver_Person_Company");
            });

            modelBuilder.Entity<Ensurance>(entity =>
            {
                entity.Property(e => e.EnsuranceId);

                entity.Property(e => e.OCAmount).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ACAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.EnsuranceNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NameOfTheCompany)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.PersonCompany)
                    .WithMany(p => p.Ensurance)
                    .HasForeignKey(d => d.PersonCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ensurance_Person_Company");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Ensurance)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VehicleEnsurance_Vehicle");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.FuelInvoiceId);

                entity.Property(e => e.FuelInvoiceId);

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FuelInvoice_Vehicle");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.ModelId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Model_Brand");
            });

            modelBuilder.Entity<PersonCompany>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.PersonId);

                entity.Property(e => e.Pesel).HasColumnName("PESEL");

                entity.Property(e => e.NIP).HasColumnName("REGON");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.PersonCompany)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Person_Address");
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.Property(e => e.RepairId);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Note).IsRequired();

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Repair)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Repair_Vehicle");
            });

            modelBuilder.Entity<TechnicalExamination>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.Property(e => e.ServiceId);

                entity.Property(e => e.DateOfExam).HasColumnType("date");

                entity.Property(e => e.Validity).HasColumnType("date");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.TechnicalExamination)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Service_Vehicle");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.VehicleId);

                entity.Property(e => e.DateOfFirstRegistration).HasColumnType("date");

                //entity.Property(e => e.FuelType)
                //    .IsRequired()
                //    .HasMaxLength(50);

                entity.Property(e => e.RegistrationEndDate).HasColumnType("date");

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.RegistrationReleaseDate).HasColumnType("date");

                entity.Property(e => e.VehicleTypeApprovalCertificateNumber).HasMaxLength(20);

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasColumnName("VIN")
                    .HasMaxLength(17);

                entity.HasOne(d => d.Holder)
                    .WithMany(p => p.VehicleHolder)
                    .HasForeignKey(d => d.HolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VehicleOwner");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vehicle_Model");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.VehicleOwner)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VehicleHolder");

                entity.HasOne(d => d.VehicleCategory)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vehicle_VehicleCategory");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vehicle_VehicleType");

                entity.HasOne(d => d.FuelType) //------------------------------------------
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.FuelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vehicle_FuelType");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VehicleInstitution");

            });

            modelBuilder.Entity<VehicleAnnotations>(entity =>
            {
                entity.HasKey(e => e.VehicleAnnotationId);

                entity.Property(e => e.VehicleAnnotationId);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehicleAnnotations)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AdditionalVehicleInfo_Vehicle");
            });

            modelBuilder.Entity<VehicleCategory>(entity =>
            {
                entity.Property(e => e.VehicleCategoryId);
            });

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.Property(e => e.FuelTypeId);
            });



            modelBuilder.Entity<Rent>(entity =>
            {
                entity.ToTable("Rent");

                entity.Property(e => e.RentId);

                entity.Property(e => e.StartDate).IsRequired();

                entity.Property(e => e.EndDate).IsRequired();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Rent)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rent_Driver");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Rent)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rent_Vehicle");
            });


            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.Property(e => e.VehicleTypeId);
            });
        }

        public DbSet<CarFleetMS.Models.VehicleKind> VehicleKind { get; set; }
    }
}
