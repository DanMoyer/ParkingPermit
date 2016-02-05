/*
  These queries are from the ASP page for student registration

	'Verify the StudentID exists and is an active student for current session and year in CARS
'	Sql =	"SELECT id_rec.id FROM id_rec " & vbcrlf & _
'			"INNER JOIN stu_acad_rec on id_rec.id = stu_acad_rec.id " & vbcrlf & _
'			"WHERE id_rec.id = " & StudentID & "  " & vbcrlf & _
'			" and stu_acad_rec.yr in ("& AcademicYear &"," & NextAcademicYear &") and stu_acad_rec.reg_stat='C' " & vbcrlf & _
'			" and (stu_acad_rec.reg_hrs > 0 or stu_acad_rec.reg_au_hrs > 0) "


	Sql =	" SELECT unique id_rec.id " & vbcrlf & _
		" FROM id_rec, prog_enr_rec, outer stu_acad_rec " & vbcrlf & _
		" WHERE id_rec.id = prog_enr_rec.id " & vbcrlf & _
		" AND id_rec.id = stu_acad_rec.id " & vbcrlf & _
		" AND stu_acad_rec.yr in ("& AcademicYear &"," & NextAcademicYear &") and stu_acad_rec.reg_stat='C' " & vbcrlf & _
		" AND (stu_acad_rec.reg_hrs > 0 or stu_acad_rec.reg_au_hrs > 0) " & vbcrlf & _
		" AND id_rec.id = " & StudentID & "  "

*/



/*
  Verify active student and current session and year (2015 and 2016) in CARS
*/

select stu_acad_rec.id, stu_acad_rec.reg_hrs, stu_acad_rec.reg_au_hrs, stu_acad_rec.yr  
from [CARS].[cars].[informix].[stu_acad_rec] 
where stu_acad_rec.yr in ('2015', '2016') 
	  and stu_acad_rec.reg_stat='C'
	  and (stu_acad_rec.reg_hrs > 0 or stu_acad_rec.reg_au_hrs > 0)
order by stu_acad_rec.id


/*
  Verify the StudentID exists and is an active student for current session and year in CARS
*/

SELECT  DISTINCT id_rec.id, firstname, lastname
	 FROM [CARS].[cars].[informix].[id_rec] 
	 INNER JOIN [CARS].[cars].[informix].[prog_enr_rec] ON id_rec.id = prog_enr_rec.id
	 INNER  JOIN  [CARS].[cars].[informix].[stu_acad_rec] ON id_rec.id = stu_acad_rec.id
WHERE stu_acad_rec.yr in ('2015', '2016') and stu_acad_rec.reg_stat='C'
AND (stu_acad_rec.reg_hrs > 0 or stu_acad_rec.reg_au_hrs > 0) 
AND id_rec.id = 123 /*UF ID */


