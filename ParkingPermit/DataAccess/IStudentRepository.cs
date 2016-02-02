using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Student;

namespace WebApplicationAuthTest.DataAccess
{
	public interface IStudentRepository
	{
		bool VerifyStudentId(string studentId);
		ApplicantModel GetApplicant(string id);
	}
}