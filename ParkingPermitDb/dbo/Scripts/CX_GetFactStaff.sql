/*


	'Verify the fac/staff ID exists in CARS as an employee.
	Sql =	"SELECT id_rec.id " & vbcrlf & _
			"FROM id_rec INNER JOIN ufcred_rec on id_rec.id = ufcred_rec.id " & vbcrlf & _
			"WHERE id_rec.id = " & FacStaffID & " and id_rec.decsd<>'Y' and ufcred_rec.park_pass='Y' "

*/


/*   Insert into FacStaff table fac/staff members */

SET IDENTITY_INSERT dbo.FacStaff ON

INSERT INTO [dbo].[FacStaff] (Id, FirstName, LastName)

SELECT id_rec.id as FacStaffID, firstname, lastname  FROM [CARS].[cars].[informix].[id_rec] 
INNER JOIN [CARS].[cars].[informix].[ufcred_rec] on id_rec.id = ufcred_rec.id
WHERE decsd<>'Y' AND park_pass='Y'

SET IDENTITY_INSERT dbo.FacStaff OFF

