CREATE TABLE [uc-it-5k].dbo.Account (
	Id int NOT NULL IDENTITY(1,1),
	FirstName varchar(50),
	LastName varchar(50),
	Email varchar(255)
) go;

CREATE TABLE [uc-it-5k].dbo.Event (
	Id int NOT NULL IDENTITY(1,1),
	StartDateTime datetime NOT NULL,
	EndDateTime datetime NOT NULL,
	Description varchar(128),
	GroupId int NOT NULL,
	LocationId int
) go;

CREATE TABLE [uc-it-5k].dbo.[Group] (
	Id int NOT NULL IDENTITY(1,1),
	Name varchar(64) NOT NULL,
	Description varchar(2147483647),
	DistrictId varchar(100)
) go;

CREATE TABLE [uc-it-5k].dbo.Student (
	Id int NOT NULL IDENTITY(1,1),
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	BirthDate date,
	Phone varchar(32),
	Address1 varchar(64),
	Address2 varchar(64),
	Address3 varchar(64),
	StateProvince varchar(64),
	PostalCode varchar(16),
	Email varchar(255)
) go;

CREATE TABLE [uc-it-5k].dbo.District (
	Id int NOT NULL IDENTITY(1,1),
	Name varchar(100),
	Phone varchar(100),
	Address1 varchar(100),
	Address2 varchar(100),
	Address3 varchar(100),
	PostalCode varchar(100),
	StateProvince varchar(100)
) go
CREATE INDEX NewTable_Id_IDX ON [uc-it-5k].dbo.District (Id) go;

CREATE TABLE [uc-it-5k].dbo.Location (
	Id int NOT NULL IDENTITY(1,1),
	Name varchar(100),
	Phone varchar(100),
	Address1 varchar(100),
	Address2 varchar(100),
	Address3 varchar(100),
	PostalCode varchar(100),
	StateProvince varchar(100)
) go;

CREATE TABLE [uc-it-5k].dbo.Topic (
	Id int NOT NULL IDENTITY(1,1),
	Title varchar(100) NOT NULL,
	CreatedDateTime datetime NOT NULL,
	ModifiedDateTime datetime,
	ArchivedDateTime datetime,
	GroupId int NOT NULL
) go;

CREATE TABLE [uc-it-5k].dbo.Comment (
	Id int NOT NULL IDENTITY(1,1),
	Content varchar(512) NOT NULL,
	CreatedDateTime datetime NOT NULL,
	ModifiedDateTime datetime,
	TopicId int NOT NULL,
	AccountId int NOT NULL
) go;

CREATE TABLE [uc-it-5k].dbo.AccountStudentMap (
	AccountID int NOT NULL,
	StudentId int NOT NULL
) go;

CREATE TABLE [uc-it-5k].dbo.StudentGroupMap (
	StudentId int NOT NULL,
	GroupId int NOT NULL
) go;

