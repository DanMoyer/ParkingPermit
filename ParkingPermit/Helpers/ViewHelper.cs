using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplicationAuthTest.Helpers
{
	public class ViewHelper
	{
		public static List<SelectListItem> ClassYear()
		{
			var classYear = new List<SelectListItem>()
			{
				new SelectListItem {Text = "Post Secondary", Value = "Post Secondary"},
				new SelectListItem {Text = "Freshman", Value = "Freshman"},
				new SelectListItem {Text = "Sophomore", Value = "Sophomore"},
				new SelectListItem {Text = "Junior", Value = "Junior"},
				new SelectListItem {Text = "Senior", Value = "Senior"},
				new SelectListItem {Text = "Graduate", Value = "Graduate"}
			};

			return classYear;
		}

		public static List<SelectListItem> StudentType()
		{
			var studentType = new List<SelectListItem>
			{
				new SelectListItem {Text = "On Campus", Value = "Oncampus"},
				new SelectListItem {Text = "Off Campus (Commuter)", Value = "Commuter"}
			};

			return studentType;
		}

		public static List<SelectListItem> OfficeLocation()
		{
			var officeLocation = new List<SelectListItem>
			{
				new SelectListItem {Text = "BCHS (BVRHC)", Value = "BCHS"},
				new SelectListItem {Text = "Eastern Farm", Value = "Eastern Farm"},
				new SelectListItem {Text = "Main Campus", Value = "Main Campus"},
				new SelectListItem {Text = "SEEM RTE. 12", Value = "SEEM RTE .12"},
				new SelectListItem {Text = "SODEXO", Value = "SODEXO"},
				new SelectListItem {Text = "Western Farm", Value = "Western Farm"},
				new SelectListItem {Text = "WTS", Value = "WTS"}
			};

			return officeLocation;
		}

		public static List<SelectListItem> CarYear()
		{
			var carYear = new List<SelectListItem>();

			for (var year = 1970; year < 2017; year++)
			{
				var item = new SelectListItem {Text = year.ToString(), Value = year.ToString()};
				carYear.Add(item);
			}

			return carYear;
		}

		public static List<SelectListItem> State()
		{
			var state = new List<SelectListItem>
			{
				new SelectListItem {Text = "AK", Value = "AK"},
				new SelectListItem {Text = "AL", Value = "AL"},
				new SelectListItem {Text = "AR", Value = "AR"},
				new SelectListItem {Text = "AZ", Value = "AZ"},
				new SelectListItem {Text = "CA", Value = "CA"},
				new SelectListItem {Text = "CO", Value = "CO"},
				new SelectListItem {Text = "CT", Value = "CT"},
				new SelectListItem {Text = "DC", Value = "DC"},
				new SelectListItem {Text = "DE", Value = "DE"},
				new SelectListItem {Text = "FL", Value = "FL"},
				new SelectListItem {Text = "GA", Value = "GA"},
				new SelectListItem {Text = "GU", Value = "GU"},
				new SelectListItem {Text = "HI", Value = "HI"},
				new SelectListItem {Text = "IA", Value = "IA"},
				new SelectListItem {Text = "ID", Value = "ID"},
				new SelectListItem {Text = "IL", Value = "IL"},
				new SelectListItem {Text = "IN", Value = "IN"},
				new SelectListItem {Text = "KS", Value = "KS"},
				new SelectListItem {Text = "KY", Value = "KY"},
				new SelectListItem {Text = "LA", Value = "LA"},
				new SelectListItem {Text = "MA", Value = "MA"},
				new SelectListItem {Text = "MD", Value = "MD"},
				new SelectListItem {Text = "ME", Value = "ME"},
				new SelectListItem {Text = "MI", Value = "MI"},
				new SelectListItem {Text = "MN", Value = "MN"},
				new SelectListItem {Text = "MO", Value = "MO"},
				new SelectListItem {Text = "MS", Value = "MS"},
				new SelectListItem {Text = "MT", Value = "MT"},
				new SelectListItem {Text = "NC", Value = "NC"},
				new SelectListItem {Text = "ND", Value = "ND"},
				new SelectListItem {Text = "NE", Value = "NE"},
				new SelectListItem {Text = "NH", Value = "NH"},
				new SelectListItem {Text = "NJ", Value = "NJ"},
				new SelectListItem {Text = "NM", Value = "NM"},
				new SelectListItem {Text = "NY", Value = "NY"},
				new SelectListItem {Text = "OH", Value = "OH"},
				new SelectListItem {Text = "OK", Value = "OK"},
				new SelectListItem {Text = "OR", Value = "OR"},
				new SelectListItem {Text = "PA", Value = "PA"},
				new SelectListItem {Text = "PR", Value = "PR"},
				new SelectListItem {Text = "RI", Value = "RI"},
				new SelectListItem {Text = "SC", Value = "SC"},
				new SelectListItem {Text = "SD", Value = "SD"},
				new SelectListItem {Text = "TN", Value = "TN"},
				new SelectListItem {Text = "TX", Value = "TX"},
				new SelectListItem {Text = "UT", Value = "UT"},
				new SelectListItem {Text = "VA", Value = "VA"},
				new SelectListItem {Text = "VI", Value = "VI"},
				new SelectListItem {Text = "VT", Value = "VT"},
				new SelectListItem {Text = "WA", Value = "WA"},
				new SelectListItem {Text = "WI", Value = "WI"},
				new SelectListItem {Text = "WV", Value = "WV"},
				new SelectListItem {Text = "WY", Value = "WY"},
				new SelectListItem {Text = "NV", Value = "NV"},
				new SelectListItem {Text = "ON", Value = "ON"}
			};

			return state;
		}

		public static string GetFacStaffHeader(string vehicleType)
		{
			return $"<h2>Faculty / Staff Online {vehicleType} Parking Permit Registration</h2>";
		}

		public static string GetFacStaffHeaderText()
		{
			return @"<p>
						Please provide your current and accurate information to register online for a parking pass.
						Your information will be verified, and you will be required to present your Faculty/Staff ID at the Office
						of Security on campus to pick up your pass.
					</p>";
		}


		public static string GetStudentHeader(string vehicleType)
		{
			return $"<h2>Online {vehicleType} Parking Permit Registration</h2>";
		}

		public static string GetStudentHeaderText()
		{
			return @"<p>
						Please provide your current and accurate information to register online for a parking pass.
						Your information will be verified, and you will be required to present your Student ID at the Office
						of Security on campus to pick up your pass.
					</p>";

		}

	}
}