using System.ComponentModel;

namespace WebApplicationAuthTest.Models.FacStaff
{
	public class FacStaffApplicationModel
	{
		[DisplayName("UF ID")]
		public string FacStaffId { get; set; }
		[DisplayName("Vehicle Type")]
		public VehicleEnum VehicleType { get; set; }
	}
}