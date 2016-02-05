
/*
		Get active students from CX and INSERT into Student Table
*/

SET IDENTITY_INSERT dbo.Student ON

INSERT INTO [dbo].[Student] (Id, FirstName, LastName)
SELECT  DISTINCT id_rec.id, firstname, lastname
	 FROM [CARS].[cars].[informix].[id_rec] 
	 INNER JOIN [CARS].[cars].[informix].[prog_enr_rec] ON id_rec.id = prog_enr_rec.id
	 INNER  JOIN  [CARS].[cars].[informix].[stu_acad_rec] ON id_rec.id = stu_acad_rec.id
WHERE stu_acad_rec.yr in ('2015', '2016') and stu_acad_rec.reg_stat='C'
AND (stu_acad_rec.reg_hrs > 0 or stu_acad_rec.reg_au_hrs > 0) 

SET IDENTITY_INSERT dbo.Student OFF