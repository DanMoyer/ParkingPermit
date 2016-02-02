using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Admin;

namespace WebApplicationAuthTest.Controllers.Admin
{
	[Authorize(Roles="admin, secureadmin")]
	public class SecureAdminStudentController : Controller
	{
		// GET: SecureAdmin
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult ShowRegistrations()
		{
			var models = TempData["Registrations"];

			return View(models);
		}

		[HttpPost]
		public ActionResult ShowRegistrations(FormCollection collection)
		{
			return View();
		}

		public ActionResult AssignTag(string id)
		{
			var repo = new StudentParkingPermitRepository();
			var entity = repo.GetByRowId(id);
			var model = GetRegistration(entity);

			return View(model);
		}

		[HttpPost]
		public ActionResult AssignTag(FormCollection collection)
		{
			try
			{
				var model = new StudentRegistrationModel();
				UpdateModel(model);

				//TODO   investigate why Id is getting populated, and RowId is being lost
				//       Need to create a viewModel?  Or hide the RowId field in the view?
				model.RowId = model.Id;

				var repo = new StudentParkingPermitRepository();
				var entity = repo.UpdateParkingTag(model);
				//var models = GetRegistrations(new List<Admin_Security_ParkingRegistration> { entity });

				//TempData["Registrations"] = models;

				return RedirectToAction("Details", new {id = entity.RowID});
			}
			catch (Exception ex)
			{
				// ReSharper disable once UnusedVariable
				var msg = ex.Message;
				return View();
			}

		}

		public ActionResult ManageStudentRegistration()
		{
			return View();
		}

		[HttpPost]
		public ActionResult ManageStudentRegistration(FormCollection collection)
		{
			try
			{
				var model = new RegistrationLookupModel();
				UpdateModel(model);

				var repo = new StudentParkingPermitRepository();

				List<Admin_Security_ParkingRegistration> entities;

				//lookup using selected criteria
				switch (model.SearchBy)
				{
					case SearchByEnum.FacStaffId:
						var entity = repo.GetByStudentId(model.KeywordSearch);
						entities = new List<Admin_Security_ParkingRegistration> {entity};
						break;

					case SearchByEnum.LastName:
						entities = repo.GetByLastName(model.KeywordSearch);
						break;

					case SearchByEnum.FirstName:
						entities = repo.GetByFirstName(model.KeywordSearch);
						break;

					case SearchByEnum.LicenseNumber:
						entities = repo.GetbyLicenseNumber(model.KeywordSearch);
						break;

					case SearchByEnum.TagNumber:
						entities = repo.GetByTagNumber(model.KeywordSearch);

						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				//populate model
				var registrations = GetRegistrations(entities);

				//redirect to display results
				TempData["Registrations"] = registrations;
				return RedirectToAction("ShowRegistrations");
			}
			catch (Exception ex)
			{
				// ReSharper disable once UnusedVariable
				var msg = ex.Message;
				return View();
			}
		}


		//public ActionResult ManageFacStaffRegistration()
		//{
		//	return View();
		//}

		//[HttpPost]
		//public ActionResult ManageFacStaffRegistration(FormCollection collection)
		//{
		//	try
		//	{
		//		var model = new RegistrationLookupModel();
		//		UpdateModel(model);

		//		var repo = new StudentParkingPermitRepository();

		//		List<Admin_Security_ParkingRegistration> entities;

		//		//lookup using selected criteria
		//		switch (model.SearchBy)
		//		{
		//			case SearchByEnum.FacStaffId:
		//				var entity = repo.GetByStudentId(model.KeywordSearch);
		//				entities = new List<Admin_Security_ParkingRegistration> { entity };
		//				break;

		//			case SearchByEnum.LastName:
		//				entities = repo.GetByLastName(model.KeywordSearch);
		//				break;

		//			case SearchByEnum.FirstName:
		//				entities = repo.GetByFirstName(model.KeywordSearch);
		//				break;

		//			case SearchByEnum.LicenseNumber:
		//				entities = repo.GetbyLicenseNumber(model.KeywordSearch);
		//				break;

		//			case SearchByEnum.TagNumber:
		//				entities = repo.GetByTagNumber(model.KeywordSearch);

		//				break;
		//			default:
		//				throw new ArgumentOutOfRangeException();
		//		}

		//		//populate model
		//		var registrations = GetRegistrations(entities);

		//		//redirect to display results
		//		TempData["Registrations"] = registrations;
		//		return RedirectToAction("ShowRegistrations");
		//	}
		//	catch (Exception ex)
		//	{
		//		// ReSharper disable once UnusedVariable
		//		var msg = ex.Message;
		//		return View();
		//	}
		//}

		public ActionResult ChangePassword()
		{
			var userName = System.Web.HttpContext.Current.User.Identity.Name;
			var model = new SecurityAdminsModel {UserName = userName};

			return View(model);
		}

		[HttpPost]
		public ActionResult ChangePassword(FormCollection collection)
		{
			try
			{
				var model = new SecurityAdminsModel();
				UpdateModel(model);

				//AspNetSecurityModel
				using (var db = new ParkingPermitContext())
				{
					//db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

					var hasher = new PasswordHasher();

					var securityAdmin = db.AspNetUsers.FirstOrDefault(u => u.UserName == model.UserName);

					if (securityAdmin == null) return RedirectToAction("Index");

					securityAdmin.PasswordHash = hasher.HashPassword(model.Password);
					db.AspNetUsers.AddOrUpdate(securityAdmin);
					db.SaveChanges();
				}

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				// ReSharper disable once UnusedVariable
				var msg = ex.Message;
				return View();
			}
		}

		public ActionResult DeleteStudentRegistration(string id)
		{
			var repo = new StudentParkingPermitRepository();
			var entity = repo.GetByRowId(id);
			var model = GetRegistration(entity);
			
			return View(model);
		}

		[HttpPost]
		public ActionResult DeleteStudentRegistration(string id, FormCollection collection)
		{
			try
			{
				var repo = new StudentParkingPermitRepository();
				repo.Remove(id);

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				// ReSharper disable once UnusedVariable
				var msg = ex.Message;

				return View();
			}
		}

		public ActionResult EditStudentRegistration(string id)
		{
			var repo = new StudentParkingPermitRepository();
			var entity = repo.GetByRowId(id);
			var model = GetRegistration(entity);

			return View(model);
		}

		[HttpPost]
		public ActionResult EditStudentRegistration(string id, FormCollection collection)
		{
			try
			{
				var model = new StudentRegistrationModel();
				UpdateModel(model);

				var repo = new StudentParkingPermitRepository();
				var entity = repo.Update(model);

				//var models = GetRegistrations(new List<Admin_Security_ParkingRegistration> {entity});

				//TempData["Registrations"] = models;

				//return RedirectToAction("ShowRegistrations");
				return RedirectToAction("Details", new {id = entity.RowID});
			}
			catch (Exception ex)
			{
				// ReSharper disable once UnusedVariable
				var msg = ex.Message;

				return View();
			}
		}

		public ActionResult Details(string id)
		{
			var repo = new StudentParkingPermitRepository();
			var entity = repo.GetByRowId(id);
			var model = GetRegistration(entity);

			return View(model);
		}
		private static List<StudentRegistrationModel> GetRegistrations(List<Admin_Security_ParkingRegistration> entities)
		{
			var models = entities.Select(GetRegistration).ToList();

			return models;
		}

		private static StudentRegistrationModel GetRegistration(Admin_Security_ParkingRegistration entity)
		{
			var date = entity.DateTagIssued?.ToString("d") ?? DateTime.Now.ToString("d");

			var model = new StudentRegistrationModel
			{
				RowId          = entity.RowID.ToString(),
				AssignedBy     = entity.IssuedBy,
				StudentId      = entity.StudentID,
				TagNumber      = entity.TagNumber,
				FirstName      = entity.FirstName,
				LastName       = entity.LastName,
				Phone          = entity.Phone,
				VehicleType    = entity.VehicleType,
				Make           = entity.CarMake,
				Color          = entity.Color,
				Year           = entity.CarYear.ToString(),
				LicensePlate   = entity.LicenseNumber,
				State          = entity.State,
				Model          = entity.CarModel,
				StudentType    = entity.StudentType,
				ClassYear      = entity.ClassYear,
				ViolationCount = entity.ViolationCount.ToString(),
				DateTagIssued  = date
			};

			return model;
		}
	}
}
