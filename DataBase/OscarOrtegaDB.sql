USE OscarOrtegaDB;

CREATE TABLE [dbo].[Role](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(75) NOT NULL,
	[Updated] DATETIME,
	[Enabled] BIT
);

CREATE TABLE [dbo].[User](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[RoleId] INT NOT NULL,
	[UserName] NVARCHAR(50),
	[Password] NVARCHAR(256) NOT NULL,
	[Updated] DATETIME,
	[Enabled] BIT
	FOREIGN KEY (RoleId) REFERENCES [dbo].[Role]([Id])
);

CREATE TABLE [dbo].[Student](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[UserId] INT,
	[Name] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(75) NOT NULL,
	[Email] NVARCHAR(75) NOT NULL,
	[ControlNumber] VARCHAR(20),
	[Updated] DATETIME,
	[Enabled] BIT

	FOREIGN KEY (UserId) REFERENCES [dbo].[User]([Id])
);

CREATE TABLE [dbo].[Teacher](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[UserId] INT,
	[Name] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(75) NOT NULL,
	[Email] NVARCHAR(75) NOT NULL,
	[Updated] DATETIME,
	[Enabled] BIT
	FOREIGN KEY (UserId) REFERENCES [dbo].[User]([Id])
);


CREATE TABLE [dbo].[ClassRoom](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[TeacherId] INT,
	[Name] NVARCHAR(60) NOT NULL,
	[Updated] DATETIME,
	[Enabled] BIT
	FOREIGN KEY (TeacherId) REFERENCES [dbo].[Teacher]([Id])
);

CREATE TABLE [dbo].[ClassRoom_Student](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[ClassRoomId] INT NOT NULL,
	[StudentId] INT NOT NULL,
	[Updated] DATETIME,
	[Enabled] BIT

	FOREIGN KEY (ClassRoomId) REFERENCES [dbo].[ClassRoom]([Id]),
	FOREIGN KEY (StudentId) REFERENCES [dbo].[Student]([Id])
);


CREATE TABLE [dbo].[Course](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(60) NOT NULL,
	[Updated] DATETIME,
	[Enabled] BIT
);

CREATE TABLE [dbo].[ClassRoom_Course](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[ClassRoomId] INT NOT NULL,
	[CourseId] INT NOT NULL,
	[Updated] DATETIME,
	[Enabled] BIT

	FOREIGN KEY (ClassRoomId) REFERENCES [dbo].[ClassRoom]([Id]),
	FOREIGN KEY (CourseId) REFERENCES [dbo].[Course]([Id])
);

CREATE TABLE [dbo].[Results](
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[StudentId] INT,
	[CourseId] INT,
	[StudentName] NVARCHAR(75),
	[StudentLastName] NVARCHAR(75),
	[CourseName] NVARCHAR(75),
	[Marks] NVARCHAR(45),
	[Updated] DATETIME,
	[Enabled] BIT

	FOREIGN KEY (StudentId) REFERENCES [dbo].[Student]([Id]),
	FOREIGN KEY (CourseId) REFERENCES [dbo].[Course]([Id])
);