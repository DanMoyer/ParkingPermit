using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Admin;
using WebApplicationAuthTest.Models.FacStaff;

namespace WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository
{
	public class FacStaffParkingPermitRepository : ParkingPermitRepository<Admin_Security_ParkingRegistration_FacStaff>
	{
		public Admin_Security_ParkingRegistration_FacStaff GetByFacStaffId(string facStaffId)
		{
			return DbSet.FirstOrDefault(rec => rec.FacStaffID == facStaffId);
		}

		public Admin_Security_ParkingRegistration_FacStaff GetByRowId(string rowId)
		{

			var id = Convert.ToInt64(rowId);
			return DbSet.FirstOrDefault(rec => rec.RowID == id);
		}

		public List<Admin_Security_ParkingRegistration_FacStaff> GetByLastName(string lastName)
		{
			return DbSet.Where(r => r.LastName == lastName).ToList();
		}

		public List<Admin_Security_ParkingRegistration_FacStaff> GetByFirstName(string firstName)
		{
			return DbSet.Where(r => r.LastName == firstName).ToList();
		}

		public List<Admin_Security_ParkingRegistration_FacStaff> GetbyLicenseNumber(string licenseNumber)
		{
			return DbSet.Where(r => r.LastName == licenseNumber).ToList();
		}

		public List<Admin_Security_ParkingRegistration_FacStaff> GetByTagNumber(string tabNumber)
		{
			return DbSet.Where(r => r.LastName == tabNumber).ToList();
		}

		public Admin_Security_ParkingRegistration_FacStaff GetByStudentIdAndVehicleType(string facStaffId, string vechicle)
		{
			return DbSet.FirstOrDefault(rec => rec.FacStaffID == facStaffId && rec.VehicleType == vechicle);
		}

		public Admin_Security_ParkingRegistration_FacStaff UpdateParkingTag(FacStaffRegistrationModel model)
		{
			var entity = GetByRowId(model.RowId);

			entity.TagNumber = model.TagNumber;
			entity.IssuedBy  = model.AssignedBy;

			SaveChanges();

			return entity;
		}

		public Admin_Security_ParkingRegistration_FacStaff Update(FacStaffRegistrationModel model)
		{
			var entity = GetByRowId(model.RowId);

			entity.FirstName     = model.FirstName;
			entity.LastName      = model.LastName;
			entity.FacStaffID    = model.FacStaffId;
			entity.Phone         = model.Phone;
			entity.CarMake       = model.Make;
			entity.CarModel      = model.Model;
			entity.CarYear       = Convert.ToInt32(model.Year);
			entity.LicenseNumber = model.LicensePlate;
			entity.State         = model.State;
			entity.Color         = model.Color;
			entity.CreatedDate   = DateTime.Now;
			entity.VehicleType   = model.VehicleType;
			entity.TagNumber     = model.TagNumber;
			entity.DateTagIssued = Convert.ToDateTime(model.DateTagIssued);
			entity.IssuedBy      = model.AssignedBy;

			SaveChanges();

			return entity;
		}

		public void Remove(SecurityAdminsModel model)
		{
			var entity = GetByRowId(model.Id);
			DbSet.Remove(entity);
			SaveChanges();
		}

		public void AddParkingRegistration(VehicleFacStaffModel model)
		{
			var entity = new Admin_Security_ParkingRegistration_FacStaff
			{
				FirstName     = model.FirstName,
				LastName      = model.LastName,
				FacStaffID    = model.FacStaffId,
				Phone         = model.Phone,
				CarMake       = model.Make,
				CarModel      = model.Model,
				CarYear       = Convert.ToInt32(model.Year),
				LicenseNumber = model.LicensePlate,
				State         = model.State,
				Color         = model.Color,
				VehicleType   = VehicleEnum.Auto.ToString().ToLower(),
				CreatedDate   = DateTime.Now
			};

			DbSet.Add(entity);
			SaveChanges();
		}

		public void AddParkingRegistration(MotorcycleFacStaffModel model)
		{
			var entity = new Admin_Security_ParkingRegistration_FacStaff
			{
				FirstName     = model.FirstName,
				LastName      = model.LastName,
				FacStaffID    = model.FacStaffId,
				Phone         = model.Phone,
				CarMake       = model.Make,
				//CarModel    = model.Model,
				CarYear       = Convert.ToInt32(model.Year),
				LicenseNumber = model.LicensePlate,
				State         = model.State,
				Color         = model.Color,
				VehicleType   = VehicleEnum.Motorcycle.ToString().ToLower(),
				CreatedDate   = DateTime.Now
			};

			DbSet.Add(entity);
			SaveChanges();
		}

		public void AddParkingRegistration(BicycleFacStaffModel model)
		{
			var entity = new Admin_Security_ParkingRegistration_FacStaff
			{
				FirstName     = model.FirstName,
				LastName      = model.LastName,
				FacStaffID    = model.FacStaffId,
				Phone         = model.Phone,
				CarMake       = model.Make,
				LicenseNumber = model.LicensePlate,
				State         = model.State,
				Color         = model.Color,
				VehicleType   = VehicleEnum.Bicycle.ToString().ToLower(),
				CreatedDate   = DateTime.Now
			};

			DbSet.Add(entity);
			SaveChanges();
		}
	}
}
