using System.Web.Mvc;
using WebApplicationAuthTest.DataAccess;
using WebApplicationAuthTest.DataAccess.JenzabarRepository;
using WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.FacStaff;

namespace WebApplicationAuthTest.Controllers
{
	public class FacStaffApplicationController : Controller
	{

		public ActionResult Apply()
		{
			var applyModel = new FacStaffApplicationModel { FacStaffId = "", VehicleType = VehicleEnum.Vehicle };

			return View("Apply", applyModel);
		}

		[HttpPost]
		public ActionResult Apply(FacStaffApplicationModel facStaffApplicationModel)
		{
			//Validate from JICS that studentID is valid
			// if not valid, show error invalid student id.

			//IFacStaffRepository repository = new Jenzabar();

			IFacStaffRepository repository = new FacStaffRepository();

			var isValidId = repository.VerifyFacStaffId(facStaffApplicationModel.FacStaffId);

			if (!isValidId)
			{
				return View("InvalidStudentId");
			}

			//TODO  rename ApplicantModel to UFPersonModel.   Change GetApplicant to GetUFPerson
			var student = repository.GetApplicant(facStaffApplicationModel.FacStaffId);

			//return View("Apply", StudentApplicationModel);
			//TempData["Id"] = StudentApplicationModel.StudentId;
			//TempData["VehicleType"] = StudentApplicationModel.VehicleType.ToString();


			//Redirect to appropriate controller- Vehicle, Bicycle, or Motorcycle
			var controllerName = facStaffApplicationModel.VehicleType.ToString();

			//  Vehicle -> VehicleFacStaff   Bicycle -> BicycleFacStaff   MotorCycle -> MotorCycleFacStaff
			controllerName = controllerName + "FacStaff";

			return RedirectToAction("Register", controllerName, new
			{
				id = student.Id,
				firstName = student.Firstname.Trim(),
				lastName = student.Lastname.Trim()
			});
		}


































		// GET: FacStaffApplication
		public ActionResult Index()
		{
			return View();
		}

		// GET: FacStaffApplication/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: FacStaffApplication/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: FacStaffApplication/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: FacStaffApplication/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: FacStaffApplication/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: FacStaffApplication/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: FacStaffApplication/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
