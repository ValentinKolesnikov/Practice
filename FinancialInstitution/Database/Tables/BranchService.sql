CREATE TABLE [dbo].[BranchService]( 
	[BranchId] INT REFERENCES Branch (ID) NOT NULL,
	[ServicesDirectoryId] INT REFERENCES ServicesDirectory (ID) NOT NULL
)