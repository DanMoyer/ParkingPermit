using System;
using System.Web.Mvc;
using WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.FacStaff;

namespace WebApplicationAuthTest.Controllers.FacStaff
{
	public class BicycleFacStaffController : Controller
	{
		public ActionResult ExistingVehicleType()
		{
			return View();
		}
		// GET: Bicycle/Register
		public ActionResult Register(string id, string firstName, string lastName)
		{
			var repository = new FacStaffParkingPermitRepository();

			var entity = repository.GetByStudentIdAndVehicleType(id, VehicleEnum.Bicycle.ToString().ToLower());

			if (entity != null)
			{
				return RedirectToAction("ExistingVehicleType");
			}

			//Show the view and populate Get Vehicle Model

			var model = new BicycleFacStaffModel { FirstName = firstName, LastName = lastName, FacStaffId = id };
			return View("Register", model);

		}

		// POST: Bicycle/Register
		[HttpPost]
		public ActionResult Register(FormCollection collection)
		{
			try
			{
				var model = new BicycleFacStaffModel();

				UpdateModel(model);

				var repository = new FacStaffParkingPermitRepository();

				//Update database with create
				repository.AddParkingRegistration(model);

				//if no errors, show registration complete

				return View("RegistrationComplete");
			}
			catch (Exception ex)
			{
				// ReSharper disable once UnusedVariable
				var msg = ex.Message;
				return View();
			}
		}
	}
}