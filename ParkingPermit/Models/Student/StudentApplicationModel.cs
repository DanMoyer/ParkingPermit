using System.ComponentModel;

namespace WebApplicationAuthTest.Models.Student
{
	public class StudentApplicationModel
	{
		[DisplayName("Student ID")]
		public string StudentId { get; set; }
		[DisplayName("Vehicle Type")]
		public VehicleEnum VehicleType { get; set; }
	}
}