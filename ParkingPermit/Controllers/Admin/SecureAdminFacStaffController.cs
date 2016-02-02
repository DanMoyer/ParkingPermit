using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.FacStaff;

namespace WebApplicationAuthTest.Controllers.Admin
{
	public class SecureAdminFacStaffController : Controller
	{
		// GET: SecureAdminFacStaff
		public ActionResult Index()
		{
			return RedirectToAction("Index", "SecureAdminStudent");
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
			var repo = new FacStaffParkingPermitRepository();
			var entity = repo.GetByRowId(id);
			var model = GetRegistration(entity);

			return View(model);
		}

		[HttpPost]
		public ActionResult AssignTag(string id, FormCollection collection)
		{
			try
			{
				var model = new FacStaffRegistrationModel();
				UpdateModel(model);

				//TODO   investigate why Id is getting populated, and RowId is being lost
				//       Need to create a viewModel?  Or hide the RowId field in the view?
				model.RowId = model.Id;

				var repo = new FacStaffParkingPermitRepository();
				var entity = repo.UpdateParkingTag(model);
				//var models = GetRegistrations(new List<Admin_Security_ParkingRegistration_FacStaff> { entity });

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


		public ActionResult ManageFacStaffRegistration()
		{
			return View();
		}

		[HttpPost]
		public ActionResult ManageFacStaffRegistration(FormCollection collection)
		{
			try
			{
				var model = new RegistrationLookupModel();
				UpdateModel(model);

				var repo = new FacStaffParkingPermitRepository();

				List<Admin_Security_ParkingRegistration_FacStaff> entities;

				//lookup using selected criteria
				switch (model.SearchBy)
				{
					case SearchByEnum.FacStaffId:
						var entity = repo.GetByFacStaffId(model.KeywordSearch);
						entities = new List<Admin_Security_ParkingRegistration_FacStaff> { entity };
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


		public ActionResult DeleteFacStaffRegistration(string id)
		{
			var repo = new FacStaffParkingPermitRepository();
			var entity = repo.GetByRowId(id);
			var model = GetRegistration(entity);

			return View(model);
		}

		[HttpPost]
		public ActionResult DeleteFacStaffRegistration(string id, FormCollection collection)
		{
			try
			{
				var repo = new StudentParkingPermitRepository();
				//repo.Remove(id);

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				// ReSharper disable once UnusedVariable
				var msg = ex.Message;

				return View();
			}
		}

		public ActionResult EditFacStaffRegistration(string id)
		{
			var repo = new FacStaffParkingPermitRepository();
			var entity = repo.GetByRowId(id);
			var model = GetRegistration(entity);

			return View(model);
		}

		[HttpPost]
		public ActionResult EditFacStaffRegistration(string id, FormCollection collection)
		{
			try
			{
				var model = new FacStaffRegistrationModel();
				UpdateModel(model);

				var repo = new FacStaffParkingPermitRepository();
				var entity = repo.Update(model);

				return RedirectToAction("Details", new {id = entity.RowID});
			}
			catch (Exception ex)
			{
				// ReSharper disable once UnusedVariable
				var msg = ex.Message;

				return View();
			}
		}



		// GET: SecureAdminFacStaff/Details/5
		public ActionResult Details(string id)
		{
			var repo = new FacStaffParkingPermitRepository();
			var entity = repo.GetByRowId(id);
			var model = GetRegistration(entity);

			return View(model);
		}

		// GET: SecureAdminFacStaff/Create
		//public ActionResult Create()
		//{
		//	var model = new FacStaffRegistrationModel();
		//	return View(model);
		//}

		//// POST: SecureAdminFacStaff/Create
		//[HttpPost]
		//public ActionResult Create(FormCollection collection)
		//{
		//	try
		//	{
		//		var model = new FacStaffRegistrationModel();
		//		UpdateModel(model);

		//		//var repo = new FacStaffParkingPermitRepository();
		//		//repo.AddParkingRegistration(model);

		//		return RedirectToAction("Index");
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		//GET: SecureAdminFacStaff/Edit/5
		//public ActionResult Edit(int id)
		//{
		//	return View();
		//}

		//POST: SecureAdminFacStaff/Edit/5
		//[HttpPost]
		//public ActionResult Edit(int id, FormCollection collection)
		//{
		//	try
		//	{
		//		TODO: Add update logic here

		//		return RedirectToAction("Index");
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}



		//      // GET: SecureAdminFacStaff/Delete/5
		//      public ActionResult Delete(int id)
		//      {
		//          return View();
		//      }

		//      // POST: SecureAdminFacStaff/Delete/5
		//      [HttpPost]
		//      public ActionResult Delete(int id, FormCollection collection)
		//      {
		//          try
		//          {
		//              // TODO: Add delete logic here

		//              return RedirectToAction("Index");
		//          }
		//          catch
		//          {
		//              return View();
		//          }
		//      }




		private static List<FacStaffRegistrationModel> GetRegistrations(List<Admin_Security_ParkingRegistration_FacStaff> entities)
		{
			var models = entities.Select(GetRegistration).ToList();

			return models;
		}

		private static FacStaffRegistrationModel GetRegistration(Admin_Security_ParkingRegistration_FacStaff entity)
		{
			var date = entity.DateTagIssued?.ToString("d") ?? DateTime.Now.ToString("d");

			var model = new FacStaffRegistrationModel()
			{
				RowId         = entity.RowID.ToString(),
				AssignedBy    = entity.IssuedBy,
				FacStaffId    = entity.FacStaffID,
				TagNumber     = entity.TagNumber,
				FirstName     = entity.FirstName,
				LastName      = entity.LastName,
				Phone         = entity.Phone,
				Location      = entity.Location,
				VehicleType   = entity.VehicleType,
				Make          = entity.CarMake,
				Color         = entity.Color,
				Year          = entity.CarYear.ToString(),
				LicensePlate  = entity.LicenseNumber,
				State         = entity.State,
				Model         = entity.CarModel,
				DateTagIssued = date
			};

			return model;
		}
	}
}
