IF NOT EXISTS(SELECT 1 FROM sys.databases WHERE name = 'TestCaseTrackingSystem')
	CREATE DATABASE TestCaseTrackingSystem
GO

USE TestCaseTrackingSystem
GO

IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tblBacklogItemType')
	CREATE TABLE tblBacklogItemType
	(
		ID			INT				NOT NULL PRIMARY KEY,
		Type		NVARCHAR(20)	NOT NULL
	)
GO

IF NOT EXISTS(SELECT 1 FROM tblBacklogItemType)
	INSERT INTO tblBacklogItemType VALUES
	(1, 'Story'),
	(2, 'Bug')
GO

IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tblUserRole')
	CREATE TABLE tblUserRole
	(
		ID			INT				NOT NULL PRIMARY KEY,
		Role		NVARCHAR(20)	NOT NULL
	)
GO

IF NOT EXISTS(SELECT 1 FROM tblUserRole)
	INSERT INTO tblUserRole VALUES
	(1, 'Admin'),
	(2, 'Developer'),
	(3, 'QA')
GO

IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tblUser')
	CREATE TABLE tblUser
	(
		ID			INT				NOT NULL PRIMARY KEY IDENTITY(1,1),
		RoleID		INT				NOT NULL FOREIGN KEY REFERENCES tblUserRole(ID),
		Login		NVARCHAR(50)	NOT NULL,
		FirstName	NVARCHAR(50)	NOT NULL,
		LastName	NVARCHAR(50)	NOT NULL,
		Email		NVARCHAR(100)	NOT NULL,
		Password	NVARCHAR(50)	NOT NULL,
		LastLogin	DATETIME		NULL,
		CreatedDate	DATETIME		NOT NULL,
		Locked		BIT				NOT NULL DEFAULT(0)
	)
GO

IF NOT EXISTS(SELECT 1 FROM tblUser)
	INSERT INTO tblUser VALUES
	(1, 'Admin', 'Admin', 'Admin', 'admin@tcts.com', 'admin', NULL, GETDATE(), 0)
GO

IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tblIteration')
	CREATE TABLE tblIteration
	(	
		ID			INT				NOT NULL PRIMARY KEY IDENTITY(1, 1),
		Name		NVARCHAR(50)	NOT NULL,
		StartDate	DATETIME		NOT NULL,
		EndDate		DATETIME		NOT NULL
	)
GO


IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tblBacklogItem')
	CREATE TABLE tblBacklogItem
	(
		ID			INT				NOT NULL PRIMARY KEY IDENTITY(1, 1),
		TypeID		INT				NOT NULL FOREIGN KEY REFERENCES tblBacklogITemType(ID),
		Title		NVARCHAR(50)	NOT NULL,
		Description	NVARCHAR(MAX) 	NULL,
		IterationID	INT				NULL	 FOREIGN KEY REFERENCES tblIteration(ID),
		CreatedBy	INT				NOT NULL FOREIGN KEY REFERENCES tblUser(ID),
		DateCreated	DATETIME		NOT NULL,
		AssignedTo	INT				NULL	 FOREIGN KEY REFERENCES tblUser(ID)
	)
GO

IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tblTestCaseStatus')
	CREATE TABLE tblTestCaseStatus
	(
		ID			INT				NOT NULL PRIMARY KEY,
		Name		NVARCHAR(50)	NOT NULL
	)
GO

IF NOT EXISTS(SELECT 1 FROM tblTestCaseStatus)
	INSERT INTO tblTestCaseStatus VALUES
	(1, 'Not Started'),
	(2, 'In progress'),
	(3, 'Failed'),
	(4, 'Passed')
GO


IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'tblTestCase')
	CREATE TABLE tblTestCase
	(
		ID				INT				NOT NULL PRIMARY KEY IDENTITY(1, 1),
		Title			NVARCHAR(50)	NOT NULL,
		Description		NVARCHAR(MAX)	NOT NULL,
		StatusId		INT				NOT NULL FOREIGN KEY REFERENCES tblTestCaseStatus(ID),
		CreatedBy		INT				NOT NULL FOREIGN KEY REFERENCES tblUser(ID),
		DateCreated		DATETIME		NOT NULL,
		RunBy			INT				NULL	 FOREIGN KEY REFERENCES tblUser(ID),
		BacklogItemID	INT				NOT NULL FOREIGN KEY REFERENCES tblBacklogItem(ID)
	)
GO