using System;
using System.Data.Odbc;
using WebApplicationAuthTest.Models;
using WebApplicationAuthTest.Models.Student;

/*
	Sql =	" SELECT unique id_rec.id " & vbcrlf & _
		" FROM id_rec, prog_enr_rec, outer stu_acad_rec " & vbcrlf & _
		" WHERE id_rec.id = prog_enr_rec.id " & vbcrlf & _
		" AND id_rec.id = stu_acad_rec.id " & vbcrlf & _
		" AND stu_acad_rec.yr in ("& AcademicYear &"," & NextAcademicYear &") and stu_acad_rec.reg_stat='C' " & vbcrlf & _
		" AND (stu_acad_rec.reg_hrs > 0 or stu_acad_rec.reg_au_hrs > 0) " & vbcrlf & _
		" AND id_rec.id = " & StudentID & "  "

	'CARS DSN Connection string
	Application("CARS_ConnectionString") = "DSN=CARS2;"


Sql =	"SELECT id_rec.id " & vbcrlf & _
		"FROM id_rec INNER JOIN ufcred_rec on id_rec.id = ufcred_rec.id " & vbcrlf & _
		"WHERE id_rec.id = " & FacStaffID & " and id_rec.decsd<>'Y' and ufcred_rec.park_pass='Y' "
	

*/

namespace WebApplicationAuthTest.DataAccess.JenzabarRepository
{
	public class Jenzabar : IStudentRepository, IFacStaffRepository
	{
			public bool VerifyStudentId(string studentId)
			{
				var isValidId = false;
				var connection = new OdbcConnection { ConnectionString = "DSN=CARS" };

				var academicYear = GetAcademicYear();

				const string sql = "SELECT unique id_rec.id FROM id_rec, prog_enr_rec, outer stu_acad_rec " +
								   "WHERE id_rec.id = prog_enr_rec.id  " +
								   "AND id_rec.id = stu_acad_rec.id " +
								   "AND stu_acad_rec.yr in ('{0}','{1}') " +
								   "AND stu_acad_rec.reg_stat='C'  " +
								   "AND (stu_acad_rec.reg_hrs > 0 or stu_acad_rec.reg_au_hrs > 0) " +
								   "AND id_rec.id = '{2}'";

				var sqlToExecute = string.Format(sql, academicYear[0], academicYear[1], studentId);

				try
				{
					connection.Open();
					var command = connection.CreateCommand();

					command.CommandText = sqlToExecute;
					command.Connection = connection;
					var reader = command.ExecuteReader();
					reader.Read();
					isValidId = reader.HasRows;

					reader.Close();
					reader.Dispose();
				}
				catch (Exception ex)
				{
					// ReSharper disable once UnusedVariable
					var msg = ex.Message;
				}
				finally
				{
					connection.Close();
					connection.Dispose();
				}

				return isValidId;
			}


		/*
		SELECT id_rec.id   from [CARS].[cars].[informix].[id_rec] INNER JOIN [CARS].[cars].[informix].[ufcred_rec] on id_rec.id = ufcred_rec.id
		WHERE id_rec.Id = '18538' AND decsd<>'Y' AND park_pass='Y'
		*/

			public bool VerifyFacStaffId(string facStaffId)
			{
				var isValidId = false;
				var connection = new OdbcConnection { ConnectionString = "DSN=CARS" };

				const string sql = "SELECT id_rec.id " +
									"FROM id_rec INNER JOIN ufcred_rec on id_rec.id = ufcred_rec.id " +
									"WHERE id_rec.id = '{0}' and id_rec.decsd <> 'Y' and ufcred_rec.park_pass = 'Y'";


				var sqlToExecute = string.Format(sql, facStaffId);

				try
				{
					connection.Open();
					var command = connection.CreateCommand();

					command.CommandText = sqlToExecute;
					command.Connection = connection;
					var reader = command.ExecuteReader();
					reader.Read();
					isValidId = reader.HasRows;

					reader.Close();
					reader.Dispose();
				}
				catch (Exception ex)
				{
					// ReSharper disable once UnusedVariable
					var msg = ex.Message;
				}
				finally
				{
					connection.Close();
					connection.Dispose();
	
				}
				return isValidId;
			}

			public ApplicantModel GetApplicant(string id)
			{
				var student = new ApplicantModel() { IsValid = false };

				var connection = new OdbcConnection { ConnectionString = "DSN=CARS" };

				const string sql = "SELECT id_rec.id, id_rec.lastname, id_rec.firstname FROM id_rec WHERE id_rec.id = '{0}'";
				var sqlToExecute = string.Format(sql, id);

				try
				{
					connection.Open();

					var command = connection.CreateCommand();
					command.CommandText = sqlToExecute;
					command.Connection = connection;
					var reader = command.ExecuteReader();
					reader.Read();

					if (reader.HasRows)
					{
						student.Id = reader[0].ToString();
						student.Lastname = reader[1].ToString();
						student.Firstname = reader[2].ToString();
						student.IsValid = true;
					}

					reader.Close();
					reader.Dispose();
				}
				catch (Exception ex)
				{
					// ReSharper disable once UnusedVariable
					var msg = ex.Message;
				}
				finally
				{
					connection.Close();
					connection.Dispose();
				}

				return student;
			}


			private string[] GetAcademicYear()
			{
				var academicYear = new string[2];

				academicYear[0] = "2015";
				academicYear[1] = "2016";

				return academicYear;
			}
		}
	}
