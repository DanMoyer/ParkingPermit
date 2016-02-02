using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAuthTest.Models.FacStaff
{
	public class VehicleFacStaffModel
	{
			[DisplayName("First Name")]
			[Required(ErrorMessage = "Please enter First Name")]
			public string FirstName { get; set; }

			[DisplayName("Last Name")]
			[Required(ErrorMessage = "Please enter Last Name")]
			public string LastName { get; set; }

			[Required(ErrorMessage = "Please enter your Faculty/Staff ID")]
			[DisplayName("Fac/Staff ID")]
			public string FacStaffId { get; set; }

			[DisplayName("Phone")]
			[Required(ErrorMessage = "Please enter phone number or '0' if no number")]
			public string Phone { get; set; }

			[DisplayName("Office Location")]
			[Required(ErrorMessage = "Please select your office location")]
			public string Location { get; set; }

			[DisplayName("Vehicle Type")]
			public string VehicleType { get; set; }

			[DisplayName("Car Make")]
			[Required]
			public string Make { get; set; }

			[DisplayName("Car Model")]
			[Required]
			public string Model { get; set; }

			[DisplayName("Car Color")]
			[Required]
			public string Color { get; set; }

			[DisplayName("Car Year")]
			[Required]
			public string Year { get; set; }

			
			[DisplayName("License Plate No")]
			[Required]
			public string LicensePlate { get; set; }

			[DisplayName("State")]
			[Required]
			public string State { get; set; }
	}
}
