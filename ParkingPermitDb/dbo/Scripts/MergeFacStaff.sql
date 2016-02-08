/*
	Data read from CX for FacStaff goes into the FacStaffLatest table.
	Data from prior CX reads is in FacStaff table.
	Merge changes of latest data in FacStaffLatest to the Student table.

	RegistrantChange contains DELETE and INSERT operations against the FacStaff table
*/

MERGE [dbo].[FacStaff] AS [Target]
USING [dbo].[FacStaffLatest] as [Source]
ON (Target.Id = [Source].Id)
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, FirstName, LastName)
	VALUES ([Source].Id, [Source].FirstName, [Source].LastName)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE
OUTPUT
	$action,
	'FacStaff',
	DELETED.*,
	INSERTED.*,
	GETDATE()
  INTO [dbo].[RegistrantChange];

