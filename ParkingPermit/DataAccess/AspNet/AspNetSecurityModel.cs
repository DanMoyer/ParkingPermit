using System.Data.Entity;

namespace WebApplicationAuthTest.DataAccess.AspNet
{
	//public partial class AspNetSecurityModel : DbContext
	//{
	//	public AspNetSecurityModel()
	//		: base("name=ParkingPermitContext")
	//	{
	//	}

	//	public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
	//	public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

	//	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	//	{
	//		modelBuilder.Entity<AspNetRole>()
	//			.HasMany(e => e.AspNetUsers)
	//			.WithMany(e => e.AspNetRoles)
	//			.Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));
	//	}
	//}
}
