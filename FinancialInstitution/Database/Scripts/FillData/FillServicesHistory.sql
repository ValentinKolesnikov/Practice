IF NOT EXISTS(SELECT * FROM [dbo].[ServicesHistory] )

	INSERT INTO [dbo].[ServicesHistory]
		([Date], [EmployeeId], [ServicesDirectoryId], [ClientId])
	VALUES
		('2019-03-03 09:11', 1, 1, 1),
		('2019-04-04 09:11', 1, 2, 1),
		('2018-05-03 09:11', 2, 3, 1),
		('2019-05-12 09:11', 3, 2, 3),
		('2018-02-07 09:11', 3, 1, 2)