
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAuthTest.Models
{
	public class RegistrationLookupModel
	{
		[DisplayName("Keyword Search:")]
		[Required]
		public string KeywordSearch { get; set; }

		[DisplayName("Search By:")]
		[Required]
		public SearchByEnum SearchBy { get; set; }
	}
}