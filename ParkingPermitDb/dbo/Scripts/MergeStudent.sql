/*
	Data read from CX for students goes into the StudentLatest table.
	Data from prior CX reads is in Student table.
	Merge changes of latest data in StudentLatest to the Student table.

	RegistrantChange contains DELETE and INSERT operations against the FacStaff table
*/

MERGE [dbo].[Student] AS [Target]
USING [dbo].[StudentLatest] as [Source]
ON (Target.Id = [Source].Id)
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, FirstName, LastName)
	VALUES ([Source].Id, [Source].FirstName, [Source].LastName)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE
OUTPUT
	$action,
	'Student',
	DELETED.*,
	INSERTED.*,
	GETDATE()
  INTO [dbo].[RegistrantChange];

