using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository
{
	public class ParkingPermitRepository<T> where T : class
	{
		private readonly ParkingPermitContext _context = new ParkingPermitContext();

		public DbSet<T> DbSet { get; set; }

		public ParkingPermitRepository()
		{
			DbSet = _context.Set<T>();
		}

		public List<T> GetAll()
		{
			return DbSet.ToList();
		}
		public T Get(int id)
		{
			return DbSet.Find(id);
		}

		public void Add(T entity)
		{
			DbSet.Add(entity);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}