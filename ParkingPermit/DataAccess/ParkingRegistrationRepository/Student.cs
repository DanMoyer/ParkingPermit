namespace WebApplicationAuthTest.DataAccess.ParkingRegistrationRepository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int Id { get; set; }

        [StringLength(90)]
        public string FirstName { get; set; }

        [StringLength(90)]
        public string LastName { get; set; }
    }
}
