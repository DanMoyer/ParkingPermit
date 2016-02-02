using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository
{
	public class Admin_Security_ParkingRegistration
	{
		[Key]
		public int RowID { get; set; }

		[StringLength(90)]
		public string TagNumber { get; set; }

		[Column(TypeName = "smalldatetime")]
		public DateTime? DateTagIssued { get; set; }

		[StringLength(50)]
		public string IssuedBy { get; set; }

		[StringLength(90)]
		public string StudentID { get; set; }

		[StringLength(50)]
		public string ClassYear { get; set; }

		[StringLength(90)]
		public string FirstName { get; set; }

		[StringLength(90)]
		public string LastName { get; set; }

		[StringLength(90)]
		public string Phone { get; set; }

		[StringLength(50)]
		public string StudentType { get; set; }

		[StringLength(90)]
		public string CarMake { get; set; }

		[StringLength(50)]
		public string CarModel { get; set; }

		[StringLength(90)]
		public string Color { get; set; }

		[StringLength(90)]
		public string LicenseNumber { get; set; }

		[StringLength(90)]
		public string State { get; set; }

		public int? CarYear { get; set; }

		public DateTime? CreatedDate { get; set; }

		public DateTime? ModifiedDate { get; set; }

		public byte? ViolationCount { get; set; }

		[StringLength(50)]
		public string VehicleType { get; set; }
	}
}