using System;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Student;

namespace WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository
{
	public class FacStaffRepository : ParkingPermitRepository<FacStaff>, IFacStaffRepository
	{
		public bool VerifyFacStaffId(string id)
		{
			var rec = DbSet.Find(Convert.ToInt32(id));
			return rec != null;
		}

		public ApplicantModel GetApplicant(string id)
		{
			var applicant = new ApplicantModel();

			var facStaff = DbSet.Find(Convert.ToInt32(id));

			applicant.Id = facStaff.Id.ToString();
			applicant.Firstname = facStaff.FirstName;
			applicant.Lastname = facStaff.LastName;

			return applicant;
		}
	}
}