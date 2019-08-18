IF NOT EXISTS(SELECT * FROM [dbo].[BranchService] )

	INSERT INTO [dbo].[BranchService]
		([BranchId], [ServicesDirectoryId])
	VALUES
		(1, 1),
		(1, 2),
		(1, 3),
		(2, 4),
		(2, 5),
		(3, 4)