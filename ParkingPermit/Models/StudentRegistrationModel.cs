using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAuthTest.Models
{
	public class StudentRegistrationModel
	{

		public string Id { get; set; }

		[DisplayName("Row ID")]
		public string RowId { get; set; }


		[Required(ErrorMessage = "Please enter Student ID")]
		[DisplayName("Student ID")]
		public string StudentId { get; set; }

		[DisplayName("Tag No.")]
		public string TagNumber { get; set; }

		[DisplayName("Date Tag Issued")]
		public string DateTagIssued { get; set; }


		[DisplayName("Assigned By")]
		public string AssignedBy { get; set; }



		[DisplayName("First Name")]
		[Required(ErrorMessage = "Please enter First Name")]
		public string FirstName { get; set; }


		[DisplayName("Last Name")]
		[Required(ErrorMessage = "Please enter Last Name")]
		public string LastName { get; set; }


		[DisplayName("Phone No")]
		[Required(ErrorMessage = "Please enter cell phone number or '0' if no number")]
		public string Phone { get; set; }

		
		[DisplayName("Vehicle Type")]
		public string VehicleType { get; set; }

		[DisplayName("Make")]
		[Required]
		public string Make { get; set; }

		[DisplayName("Model")]
		[Required]
		public string Model { get; set; }

		
		[DisplayName("Color")]
		[Required]
		public string Color { get; set; }

		[DisplayName("Car Year")]
		[Required]
		public string Year { get; set; }


		[DisplayName("License No")]
		[Required]
		public string LicensePlate { get; set; }
		
		[DisplayName("State")]
		[Required]
		public string State { get; set; }

		[DisplayName("Violation Count")]
		[Required]
		public string ViolationCount { get; set; }

		[DisplayName("Student Type")]
		[Required]
		public string StudentType { get; set; }

		[DisplayName("Class Year")]
		[Required]
		public string ClassYear { get; set; }
	}
}