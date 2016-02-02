using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Student;

namespace WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository
{
	public class StudentParkingPermitRepository : ParkingPermitRepository<Admin_Security_ParkingRegistration>
	{
		public Admin_Security_ParkingRegistration GetByStudentId(string studentId)
		{
			return DbSet.FirstOrDefault(rec => rec.StudentID == studentId);
		}

		public Admin_Security_ParkingRegistration GetByRowId(string rowId)
		{

			var id = Convert.ToInt64(rowId);
			return DbSet.FirstOrDefault(rec => rec.RowID == id);
		}

		public List<Admin_Security_ParkingRegistration> GetByLastName(string lastName)
		{
			return DbSet.Where(r => r.LastName == lastName).ToList();
		}

		public List<Admin_Security_ParkingRegistration> GetByFirstName(string firstName)
		{
			return DbSet.Where(r => r.LastName == firstName).ToList();
		}

		public List<Admin_Security_ParkingRegistration> GetbyLicenseNumber(string licenseNumber)
		{
			return DbSet.Where(r => r.LastName == licenseNumber).ToList();
		}

		public List<Admin_Security_ParkingRegistration> GetByTagNumber(string tabNumber)
		{
			return DbSet.Where(r => r.LastName == tabNumber).ToList();
		}

		public Admin_Security_ParkingRegistration GetByStudentIdAndVehicleType(string studentId, string vechicle)
		{
			return DbSet.FirstOrDefault(rec => rec.StudentID == studentId && rec.VehicleType == vechicle);
		}

		public Admin_Security_ParkingRegistration UpdateParkingTag(StudentRegistrationModel model)
		{
			var entity = GetByRowId(model.RowId);

			entity.TagNumber = model.TagNumber;
			entity.IssuedBy  = model.AssignedBy;

			SaveChanges();

			return entity;
		}

		public Admin_Security_ParkingRegistration Update(StudentRegistrationModel model)
		{
			var entity = GetByRowId(model.RowId);

			entity.FirstName      = model.FirstName;
			entity.LastName       = model.LastName;
			entity.StudentID      = model.StudentId;
			entity.Phone          = model.Phone;
			entity.StudentType    = model.StudentId;
			entity.CarMake        = model.Make;
			entity.CarModel       = model.Model;
			entity.CarYear        = Convert.ToInt32(model.Year);
			entity.LicenseNumber  = model.LicensePlate;
			entity.State          = model.State;
			entity.Color          = model.Color;
			entity.CreatedDate    = DateTime.Now;
			entity.VehicleType    = model.VehicleType;
			entity.ViolationCount = Convert.ToByte(model.ViolationCount);
			entity.TagNumber      = model.TagNumber;
			entity.DateTagIssued  = Convert.ToDateTime(model.DateTagIssued);
			entity.IssuedBy       = model.AssignedBy;

			SaveChanges();

			return entity;
		}

		public void Remove(string id)
		{
			var entity = GetByRowId(id);
			DbSet.Remove(entity);
			SaveChanges();
		}

		public void AddParkingRegistration(VehicleModel model)
		{
			var entity = new Admin_Security_ParkingRegistration
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				StudentID = model.StudentId,
				Phone = model.CellPhone,
				ClassYear = model.ClassYear,
				StudentType = model.ResidenceStatus,
				CarMake = model.Make,
				CarModel = model.Model,
				CarYear = Convert.ToInt32(model.Year),
				LicenseNumber = model.LicensePlate,
				State = model.State,
				Color = model.Color,
				VehicleType = "auto",
				CreatedDate = DateTime.Now
			};

			DbSet.Add(entity);
			SaveChanges();

		}

		public void AddParkingRegistration(MotorcycleModel model)
		{
			var entity = new Admin_Security_ParkingRegistration
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				StudentID = model.StudentId,
				Phone = model.CellPhone,
				ClassYear = model.ClassYear,
				StudentType = model.ResidenceStatus,
				CarMake = model.Make,
				//CarModel = model.Model,
				CarYear = Convert.ToInt32(model.Year),
				LicenseNumber = model.LicensePlate,
				State = model.State,
				Color = model.Color,
				VehicleType = "motorcycle",
				CreatedDate = DateTime.Now
			};

			DbSet.Add(entity);
			SaveChanges();

		}
		
		public void AddParkingRegistration(BicycleModel model)
		{
			var entity = new Admin_Security_ParkingRegistration
			{
				FirstName     = model.FirstName,
				LastName      = model.LastName,
				StudentID     = model.StudentId,
				Phone         = model.CellPhone,
				ClassYear     = model.ClassYear,
				StudentType   = model.ResidenceStatus,
				CarMake       = model.Make,
				//CarYear       = Convert.ToInt32(model.Year),
				LicenseNumber = model.LicensePlate,
				State         = model.State,
				Color         = model.Color,
				VehicleType   = "bicycle",
				CreatedDate   = DateTime.Now
			};

			DbSet.Add(entity);
			SaveChanges();

		}
	}
}