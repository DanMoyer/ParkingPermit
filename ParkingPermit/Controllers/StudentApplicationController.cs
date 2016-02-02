using System.Web.Mvc;
using WebApplicationAuthTest.DataAccess;
using WebApplicationAuthTest.DataAccess.JenzabarRepository;
using WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Student;

namespace WebApplicationAuthTest.Controllers
{
	public class StudentApplicationController : Controller
	{
		// GET: StudentApplication
		public ActionResult Apply()
		{
			var applyModel = new StudentApplicationModel { StudentId = "", VehicleType = VehicleEnum.Vehicle };

			return View("Apply", applyModel);
		}

		[HttpPost]
		public ActionResult Apply(StudentApplicationModel studentApplicationModel)
		{
			//Validate from JICS that studentID is valid
			// if not valid, show error invalid student id.

			//IStudentRepository repository = new Jenzabar();
			IStudentRepository repository = new StudentRepository();

			var isValidId = repository.VerifyStudentId(studentApplicationModel.StudentId);

			if (!isValidId)
			{
				return View("InvalidStudentId");
			}

			var student = repository.GetApplicant(studentApplicationModel.StudentId);

			//return View("Apply", StudentApplicationModel);
			//TempData["Id"] = StudentApplicationModel.StudentId;
			//TempData["VehicleType"] = StudentApplicationModel.VehicleType.ToString();


			//Redirect to appropriate controller- Vehicle, Bicycle, or Motorcycle
			var controllerName = studentApplicationModel.VehicleType.ToString();

			return RedirectToAction("Register", controllerName, new
			{
				id = student.Id,
				firstName = student.Firstname.Trim(),
				lastName = student.Lastname.Trim()
			});
		}

		// GET: StudentApplication/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: StudentApplication/Register
		public ActionResult Create()
		{
			return View();
		}

		// POST: StudentApplication/Register
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Apply");
			}
			catch
			{
				return View();
			}
		}

		// GET: StudentApplication/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: StudentApplication/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Apply");
			}
			catch
			{
				return View();
			}
		}

		// GET: StudentApplication/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: StudentApplication/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Apply");
			}
			catch
			{
				return View();
			}
		}
	}
}