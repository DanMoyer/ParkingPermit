using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Student;

namespace WebApplicationAuthTest.DataAccess
{
	public interface IFacStaffRepository
	{
		bool VerifyFacStaffId(string facStaffId);

		ApplicantModel GetApplicant(string id);
	}
}