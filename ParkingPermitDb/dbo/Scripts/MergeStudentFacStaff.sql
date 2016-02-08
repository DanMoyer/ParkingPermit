/*
	Student and FacStaff are populated with data from CX

	Prior to this merge, a merge with StudentLatest and FacStaffLatest
	against Student and FacStaff has completed to make the 
	Student and Faculty data in sync with CX data

	Becuase a staff may be also be a student 
	There can be identical UFID in the facstaff and student
	tables data coming from CX.

	To avoid primary key collisions, delete UFID in Student table that 
	is also in FacStaff table.
*/
MERGE [dbo].[Student] AS [Target]
USING [dbo].[FacStaff] as [Source]
ON (Target.Id = [Source].Id)
WHEN  MATCHED THEN
    DELETE
OUTPUT
	$action,
	'Student',
	DELETED.*,
	INSERTED.*,
	GETDATE()
  INTO [dbo].[StudentChange];


/*
  With the primary keys fixed up, combine the student and facstaf data into the Registrant table
*/

DELETE [dbo].[Registrant] 

INSERT INTO [dbo].[Registrant] (Id, FirstName, LastName, IsStudent)
SELECT Id, FirstName, LastName, 1 FROM [dbo].[Student]

INSERT INTO [dbo].[Registrant] (Id, FirstName, LastName, IsStudent)
SELECT Id, FirstName, LastName, 0 FROM [dbo].[FacStaff]