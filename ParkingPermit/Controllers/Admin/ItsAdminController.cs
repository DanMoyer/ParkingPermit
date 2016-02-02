using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository;
using WebApplicationAuthTest.Helpers;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Admin;

namespace WebApplicationAuthTest.Controllers.Admin
{
	[Authorize(Roles="admin")]
	public class ItsAdminController : Controller
	{
		public ActionResult AddItsSecurityAdmin()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult AddItsSecurityAdmin(FormCollection collection)
		{
			try
			{
				var model = new SecurityAdminsModel();
				UpdateModel(model);

				using (var context = new ApplicationDbContext())
				{
					if (context.Users.Any(u => u.UserName == model.UserName)) RedirectToAction("Index");

					UserRoleHelper.AddUser(context, model.UserName);

					UserRoleHelper.AddUserRole(context, model.UserName, "securityadmin");
				}

				return RedirectToAction("Index");
			}
			catch(Exception ex)
			{
				// ReSharper disable once UnusedVariable
				var msg = ex.Message;
				return View();
			}
		}


		public ActionResult AddItsAdmin()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddItsAdmin(FormCollection collection)
		{
			try
			{
				var model = new ItsAdminsModel();
				UpdateModel(model);

				using (var context = new ApplicationDbContext())
				{
					if (context.Users.Any(u => u.UserName == model.UserName)) RedirectToAction("Index");

					UserRoleHelper.AddUser(context, model.UserName);

					UserRoleHelper.AddUserRole(context, model.UserName, "admin");
					UserRoleHelper.AddUserRole(context, model.UserName, "securityadmin");
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




		public ActionResult ChangeItsAdminPassword()
		{
			var userName = System.Web.HttpContext.Current.User.Identity.Name;
			var model = new ItsAdminsModel {UserName = userName};

			return View(model);
		}

		[HttpPost]
		public ActionResult ChangeItsAdminPassword(FormCollection collection)
		{
			try
			{
				var model = new ItsAdminsModel();
				UpdateModel(model);

				/* AspNetSecurityModel */
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


		public ActionResult ChangeSecurityAdminPassword()
		{
			var userName = System.Web.HttpContext.Current.User.Identity.Name;
			var model = new SecurityAdminsModel { UserName = userName };

			return View(model);
		}

		[HttpPost]
		public ActionResult ChangeSecurityAdminPassword(FormCollection collection)
		{
			try
			{
				var model = new SecurityAdminsModel();
				UpdateModel(model);

				/* AspNetSecurityModel */
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

		public ActionResult Index()
		{
			return View();
		}



		public ActionResult ShowItsAdministrators()
		{
			var models = new List<ItsAdminsModel>();

			/* AspNetSecurityModel */
			using (var db = new ParkingPermitContext())
			{
				//db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

				var itsAdmins = db.AspNetUsers
					.Where(u => u.AspNetRoles.Any(r => r.Name == "admin"))
					.ToList();


				models.AddRange(itsAdmins.Select(admin => new ItsAdminsModel { Id = admin.Id, UserName = admin.UserName }));
			}


			return View(models);
		}

		[HttpPost]
		public ActionResult ShowItsAdministrators(FormCollection collection)
		{
			try
			{
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}


		public ActionResult ShowSecurityAdministrators()
		{
			var models = new List<SecurityAdminsModel>();

			/* AspNetSecurityModel */
			using (var db = new ParkingPermitContext())
			{
				//db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

				var securityAdmins = db.AspNetUsers
					.Where(u => u.AspNetRoles.Any(r => r.Name == "securityadmin"))
					.ToList();


				models.AddRange(securityAdmins.Select(admin => new SecurityAdminsModel {Id = admin.Id, UserName = admin.UserName}));
			}


			return View(models);
		}

		[HttpPost]
		public ActionResult ShowSecurityAdministrators(FormCollection collection)
		{
			try
			{
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}


		public ActionResult DeleteItsAdministrator(string id)
		{
			// AspNetSecurityModel
			using (var db = new ParkingPermitContext())
			{
				var itsAdmin = db.AspNetUsers.FirstOrDefault(u => u.Id == id);

				if (itsAdmin != null)
				{
					var model = new ItsAdminsModel
					{
						Id = itsAdmin.Id,
						UserName = itsAdmin.UserName
					};

					return View(model);
				}
			}

			return View();
		}

		[HttpPost]
		public ActionResult DeleteItsAdministrator(string id, FormCollection collection)
		{
			try
			{
				//var model = new ItsAdminsModel();
				//UpdateModel(model);

				// AspNetSecurityModel
				using (var db = new ParkingPermitContext())
				{
					db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

					//Commented out for debugging
					var securityAdmin = db.AspNetUsers.FirstOrDefault(u => u.Id == id);
					db.AspNetUsers.Remove(securityAdmin);
					db.SaveChanges();
				}


				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}


		public ActionResult DeleteSecurityAdministrator(string id)
		{
			// AspNetSecurityModel
			using (var db = new ParkingPermitContext())
			{
				var securityAdmin = db.AspNetUsers.FirstOrDefault(u => u.Id == id);

				if (securityAdmin != null)
				{
					var model = new SecurityAdminsModel
					{
						Id = securityAdmin.Id,
						UserName = securityAdmin.UserName
					};

					return View(model);
				}
			}

			return View();
		}
		
		[HttpPost]
		public ActionResult DeleteSecurityAdministrator(string id,FormCollection collection)
		{
			try
			{
				//var model = new SecurityAdminsModel();
				//UpdateModel(model);

				// AspNetSecurityModel
				using (var db = new ParkingPermitContext())
				{
					db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

					//Commented out for debugging
					var securityAdmin = db.AspNetUsers.FirstOrDefault(u => u.Id == id);
					db.AspNetUsers.Remove(securityAdmin);
					db.SaveChanges();
				}


				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}


		public ActionResult ResetSecurityAdministratorPassword()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult ResetSecurityAdministratorPassword(FormCollection collection)
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

					var securityAdmin = db.AspNetUsers.FirstOrDefault(u => u.Id == model.Id);

					if (securityAdmin == null) return RedirectToAction("Index");

					securityAdmin.PasswordHash = hasher.HashPassword("Password.1");
					db.AspNetUsers.AddOrUpdate(securityAdmin);
					db.SaveChanges();
				}


				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}


	}
}
