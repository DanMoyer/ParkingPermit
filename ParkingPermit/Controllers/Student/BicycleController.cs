using System;
using System.Web.Mvc;
using WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Student;

namespace WebApplicationAuthTest.Controllers.Student
{
	public class BicycleController : Controller
	{

		public ActionResult ExistingVehicleType()
		{
			return View();
		}
		// GET: Bicycle/Register
		public ActionResult Register(string id, string firstName, string lastName)
		{
			var repository = new StudentParkingPermitRepository();

			var entity = repository.GetByStudentIdAndVehicleType(id, VehicleEnum.Bicycle.ToString().ToLower());

			if (entity != null)
			{
				return RedirectToAction("ExistingVehicleType");
			}

			//Show the view and populate Get Vehicle Model

			var model = new BicycleModel { FirstName = firstName, LastName = lastName, StudentId = id };
			return View("Register", model);

		}

		// POST: Bicycle/Register
		[HttpPost]
		public ActionResult Register(FormCollection collection)
		{
			try
			{
				var model = new BicycleModel();

				UpdateModel(model);

				var repository = new StudentParkingPermitRepository();

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