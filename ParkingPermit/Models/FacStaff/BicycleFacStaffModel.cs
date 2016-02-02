using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAuthTest.Models.FacStaff
{
	public class BicycleFacStaffModel
	{
		[DisplayName("First Name")]
		[Required(ErrorMessage = "Please enter First Name")]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		[Required(ErrorMessage = "Please enter Last Name")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter Student ID")]
		[DisplayName("Fac/Staff ID")]
		public string FacStaffId { get; set; }

		[DisplayName(" Phone")]
		[Required(ErrorMessage = "Please enter phone number or '0' if no number")]
		public string Phone { get; set; }

		[DisplayName("Office Location")]
		[Required(ErrorMessage = "Please select your office location")]
		public string Location { get; set; }

		[DisplayName("Bicycle Make")]
		[Required]
		public string Make { get; set; }


		[DisplayName("Bicycle Color")]
		[Required]
		public string Color { get; set; }


		[DisplayName("Bicycle Serial No")]
		[Required]
		public string LicensePlate { get; set; }

		[DisplayName("State")]
		[Required]
		public string State { get; set; }
	}
}