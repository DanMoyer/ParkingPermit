using System;
using System.Web.Mvc;
using WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Student;

namespace WebApplicationAuthTest.Controllers.Student
{
	public class MotorcycleController : Controller
	{

		public ActionResult ExistingVehicleType()
		{
			return View();
		}

		// GET: Motorcycle/Register
		public ActionResult Register(string id, string firstName, string lastName)
		{
			// Check for record based on studentID and vehicle type in parkingadmin table.
			// if record exist, populate model, and display appropriate form.
			// if record does not exist, populate model with just student name and display vehicle form.

			var repository = new StudentParkingPermitRepository();

			var entity = repository.GetByStudentIdAndVehicleType(id, "motorcycle");

			if (entity != null)
			{
				return RedirectToAction("ExistingVehicleType");
			}

			//Populate Get Vehicle Model
			var model = new MotorcycleModel() { FirstName = firstName, LastName = lastName, StudentId = id };

			return View("Register", model);
		}

		// POST: Motorcycle/Register
		[HttpPost]
		public ActionResult Register(FormCollection collection)
		{
			try
			{
				var model = new MotorcycleModel();

				UpdateModel(model);

				var repository = new StudentParkingPermitRepository();

				//Update database with create
				repository.AddParkingRegistration(model);

				//if no errors, show registration complete
				return View("RegisterationComplete");
			}
			catch (Exception ex)
			{
				var msg = ex.Message;

				return View();
			}
		}
	
	}
}