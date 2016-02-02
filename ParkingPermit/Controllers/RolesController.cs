using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplicationAuthTest.Models;


namespace WebApplicationAuthTest.Controllers
{
	public class RolesController : Controller
	{

		ApplicationDbContext _context = new ApplicationDbContext();

		// GET: Roles
		public ActionResult Index()
		{
			var roles = _context.Roles.ToList();
			return View(roles);
		}

		// GET: Roles/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Roles/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Roles/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				_context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
				{
					Name = collection["RoleName"]
				});

				_context.SaveChanges();

				ViewBag.ResultMessage = "Role created successfully !";

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Roles/Edit/5
		public ActionResult Edit(string roleName)
		{
			var thisRole = _context.Roles.Where(r => r.Name == roleName).FirstOrDefault();

			return View(thisRole);
		}

		// POST: Roles/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
		{
			try
			{
				_context.Entry(role).State = System.Data.Entity.EntityState.Modified;
				_context.SaveChanges();

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Roles/Delete/5
		public ActionResult Delete(string roleName)
		{
			var thisRole = _context.Roles.FirstOrDefault(r => r.Name == roleName);

			_context.Roles.Remove(thisRole);

			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		// POST: Roles/Delete/5
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


		public ActionResult ManageUserRoles()
		{
			var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
			ViewBag.Roles = list;

			return View();
		}


		//The following link explains how to implement role management
		//https://andersnordby.wordpress.com/2014/11/28/asp-net-mvc-4-5-owin-simple-roles-management/

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RoleAddToUser(string userName, string roleName)
		{
			var roleStore = new RoleStore<IdentityRole>(_context);
			var roleManager = new RoleManager<IdentityRole>(roleStore);

			var userStore = new UserStore<ApplicationUser>(_context);
			var userManager = new UserManager<ApplicationUser>(userStore);

			var users = (from u in userManager.Users select u.UserName).ToList();
			var roles = (from r in roleManager.Roles select r.Name).ToList();

			var user = userManager.FindByName(userName);

			if (user ==  null)
			{
				//return View("Index");
				throw new Exception("User not found!");
			}

			var role = roleManager.FindByName(roleName);

			if (role == null)
			{
				//return View("Index");
				throw new Exception("Role not found!");
			}

			if (userManager.IsInRole(user.Id, role.Name))
			{
				ViewBag.ResultMessage = "This user alread has role specified";
			}
			else
			{
				userManager.AddToRole(user.Id, role.Name);
				_context.SaveChanges();

				ViewBag.ResultMessage = "Username added to the role";
			}

			roles = roleManager.Roles.Select(r => r.Name).ToList();

			ViewBag.Roles = new SelectList(roles);
			ViewBag.Users = new SelectList(users);

			return View("ManageUserRoles");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult GetRoles(string userName)
		{
			if (!string.IsNullOrWhiteSpace(userName))
			{
				var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

				if (user == null)
				{
					return View("ManageUserRoles");
				}

				var account = new AccountController();

				ViewBag.RolesForThisUser = account.UserManager.GetRoles(user.Id);

				// prepopulat roles for the view dropdown
				var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
				ViewBag.Roles = list;
			}

			return View("ManageUserRoles");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteRoleForUser(string userName, string roleName)
		{
			var account = new AccountController();
			var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

			if (user == null)
			{
				return View("ManageUserRoles");
			}

			if (account.UserManager.IsInRole(user.Id, roleName))
			{
				account.UserManager.RemoveFromRole(user.Id, roleName);
				ViewBag.ResultMessage = "Role removed from this user successfully !";
			}
			else
			{
				ViewBag.ResultMessage = "This user doesn't belong to selected role.";
			}
			// prepopulat roles for the view dropdown
			var list = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
			ViewBag.Roles = list;

			return View("ManageUserRoles");
		}


	}
}
