using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AAO_adminstrationspanel.Models
{
    public partial class uclweb_gr3Context : IdentityDbContext<User, Role, int>
    {
        public uclweb_gr3Context()
        {
        }

        public uclweb_gr3Context(DbContextOptions<uclweb_gr3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverLicenseType> DriverLicenseTypes { get; set; }
        public virtual DbSet<DriverQualification> DriverQualifications { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<QualificationType> QualificationTypes { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Scheduler> Schedulers { get; set; }
        public virtual DbSet<Trip> TripUser { get; set; }
        public virtual DbSet<TripUser> TripUsers { get; set; }
        //public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               //optionsBuilder.UseSqlServer("server=sql.insoft.dk;database=uclweb_gr3;user id=uclweb_gr3;password=Odense2021!;");
               //optionsBuilder.UseSqlServer("Server=DESKTOP-F290R19;Database=TESTAdminPanelAAO_db;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Address");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Address__CityID__29572725");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("City");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__City__CountryID__267ABA7A");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Country");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Cvr)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CVR");

                entity.Property(e => e.Fax)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Departmen__Addre__2E1BDC42");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DriverLicenseTypeId).HasColumnName("DriverLicenseTypeID");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.DriverLicenseType)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.DriverLicenseTypeId)
                    .HasConstraintName("FK__Driver__DriverLi__440B1D61");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Driver__UserID__4316F928");
            });

            modelBuilder.Entity<DriverLicenseType>(entity =>
            {
                entity.ToTable("DriverLicenseType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DriverQualification>(entity =>
            {
                entity.HasKey(e => new { e.QualificationTypeId, e.DriverId })
                    .HasName("PK__DriverQu__370CC382AD3C09EB");

                entity.ToTable("DriverQualification");

                entity.Property(e => e.QualificationTypeId).HasColumnName("QualificationTypeID");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.DriverQualifications)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DriverQua__Drive__49C3F6B7");

                entity.HasOne(d => d.QualificationType)
                    .WithMany(p => p.DriverQualifications)
                    .HasForeignKey(d => d.QualificationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DriverQua__Quali__48CFD27E");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QualificationType>(entity =>
            {
                entity.ToTable("QualificationType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Scheduler>(entity =>
            {
                entity.ToTable("Scheduler");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Schedulers)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Scheduler__Depar__3E52440B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Schedulers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Scheduler__UserI__3D5E1FD2");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("Trip");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.EndCountryId).HasColumnName("EndCountryID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartCountryId).HasColumnName("StartCountryID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK__Trip__ContactID__37A5467C");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Trip__Department__38996AB5");

                entity.HasOne(d => d.EndCountry)
                    .WithMany(p => p.TripEndCountries)
                    .HasForeignKey(d => d.EndCountryId)
                    .HasConstraintName("FK__Trip__EndCountry__3A81B327");

                entity.HasOne(d => d.StartCountry)
                    .WithMany(p => p.TripStartCountries)
                    .HasForeignKey(d => d.StartCountryId)
                    .HasConstraintName("FK__Trip__StartCount__398D8EEE");
            });

            modelBuilder.Entity<TripUser>(entity =>
            {
                entity.HasKey(e => new { e.TripId, e.UserId })
                    .HasName("PK__TripUser__80A4FDD410E8D8F1");

                entity.ToTable("TripUser");

                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TripUsers)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TripUser__TripID__4CA06362");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TripUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TripUser__UserID__4D94879B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LoginId).HasColumnName("LoginID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__User__AddressID__34C8D9D1");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__User__LoginID__33D4B598");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__RoleID__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
