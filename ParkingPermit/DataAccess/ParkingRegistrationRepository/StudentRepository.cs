using System;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Student;

namespace WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository
{
	public class StudentRepository : ParkingPermitRepository<Student>, IStudentRepository
	{
		public bool VerifyStudentId(string id)
		{
			var rec = DbSet.Find(Convert.ToInt32(id));

			return rec != null;
		}

		public ApplicantModel GetApplicant(string id)
		{
			var applicant = new ApplicantModel();

			var student = DbSet.Find(Convert.ToInt32(id));

			applicant.Id        = student.Id.ToString();
			applicant.Firstname = student.FirstName;
			applicant.Lastname  = student.LastName;

			return applicant;
		}
	}
}