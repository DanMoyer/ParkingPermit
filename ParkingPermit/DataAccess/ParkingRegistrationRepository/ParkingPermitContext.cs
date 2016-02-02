using System.Data.Entity;

namespace WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository
{
	public partial class ParkingPermitContext : DbContext
	{
		public ParkingPermitContext()
			: base("name=ParkingPermitContext")
		{
		}

		public virtual DbSet<Admin_Security_ParkingRegistration> Admin_Security_ParkingRegistration { get; set; }
		public virtual DbSet<Admin_Security_ParkingRegistration_FacStaff> Admin_Security_ParkingRegistration_FacStaff { get; set; }
		public virtual DbSet<FacStaff> FacStaffs { get; set; }
		public virtual DbSet<Student> Students { get; set; }


		public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
		public virtual DbSet<AspNetUser> AspNetUsers { get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.IssuedBy)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.StudentID)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.ClassYear)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.FirstName)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.LastName)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.Phone)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.StudentType)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.CarMake)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.CarModel)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.Color)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.LicenseNumber)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.State)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration>()
				.Property(e => e.VehicleType)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration_FacStaff>()
				.Property(e => e.IssuedBy)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration_FacStaff>()
				.Property(e => e.FacStaffID)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration_FacStaff>()
				.Property(e => e.FirstName)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration_FacStaff>()
				.Property(e => e.LastName)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration_FacStaff>()
				.Property(e => e.Phone)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration_FacStaff>()
				.Property(e => e.CarMake)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration_FacStaff>()
				.Property(e => e.CarModel)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration_FacStaff>()
				.Property(e => e.Color)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration_FacStaff>()
				.Property(e => e.LicenseNumber)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration_FacStaff>()
				.Property(e => e.State)
				.IsUnicode(false);

			modelBuilder.Entity<Admin_Security_ParkingRegistration_FacStaff>()
				.Property(e => e.VehicleType)
				.IsUnicode(false);

			modelBuilder.Entity<FacStaff>()
				.Property(e => e.FirstName)
				.IsUnicode(false);

			modelBuilder.Entity<FacStaff>()
				.Property(e => e.LastName)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.FirstName)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.LastName)
				.IsUnicode(false);


			modelBuilder.Entity<AspNetRole>()
				.HasMany(e => e.AspNetUsers)
				.WithMany(e => e.AspNetRoles)
				.Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));
		}
	}
}