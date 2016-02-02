using System;
using System.Web.Mvc;
using WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.FacStaff;

namespace WebApplicationAuthTest.Controllers.FacStaff
{
	public class VehicleFacStaffController : Controller
	{
		public ActionResult ExistingVehicle()
		{
			return View("ExistingVehicleType");
		}



		// GET: Auto/Register
		public ActionResult Register(string id, string firstName, string lastName)
		{
			// Check for record based on studentID and vehicletype in parkingadmin table.
			// if record exist, populate model, and display appropriate form.
			// if record does not exist, populate model with just student name and display vehicle form.

			var repository = new FacStaffParkingPermitRepository();

			var entity = repository.GetByStudentIdAndVehicleType(id, "auto");

			if (entity != null)
			{
				return RedirectToAction("ExistingVehicle");
			}

			//Show the view and populate Get Vehicle Model

			var model = new VehicleFacStaffModel() { FirstName = firstName, LastName = lastName, FacStaffId = id };
			return View("Register", model);
		}

		// POST: Auto/Register
		[HttpPost]
		public ActionResult Register(FormCollection collection)
		{
			try
			{
				var model = new VehicleFacStaffModel();

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
