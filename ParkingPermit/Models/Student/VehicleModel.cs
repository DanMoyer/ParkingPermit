using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAuthTest.Models.Student
{
	public class VehicleModel
	{
		[DisplayName("First Name")]
		[Required(ErrorMessage = "Please enter First Name")]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		[Required(ErrorMessage = "Please enter Last Name")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter Student ID")]
		[DisplayName("Student ID")]
		public string StudentId { get; set; }

		[DisplayName("Cell Phone")]
		[Required(ErrorMessage = "Please enter cell phone number or '0' if no number")]
		public string CellPhone { get; set; }

		[DisplayName("Class Year")]
		[Required(ErrorMessage = "Please select your class year")]
		public string ClassYear { get; set; }

		[DisplayName("Student Residence Status")]
		[Required(ErrorMessage = "Please select your residence status")]
		public string ResidenceStatus { get; set; }

		[DisplayName("Make")]
		[Required]
		public string Make { get; set; }

		[DisplayName("Year")]
		[Required]
		public string Year { get; set; }

		[DisplayName("Color")]
		[Required]
		public string Color { get; set; }


		[DisplayName("License Plate No")]
		[Required]
		public string LicensePlate { get; set; }

		[DisplayName("Model")]
		[Required]
		public string Model { get; set; }

		[DisplayName("Vehicle Type")]
		public string VehicleType { get; set; }

		[DisplayName("State")]
		[Required]
		public string State { get; set; }
	}
}