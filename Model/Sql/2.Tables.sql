/* *************************************************************** */
/*                SQL Server : Create Tables Script                */
/* 																   */
/* Command Line Syntax:						                       */
/*       > sqlcmd.exe -U [user] -P [password] -I -i Tables.sql     */
/* 														  		   */
/* *************************************************************** */

/* 
 * Drop tables.                                                             
 * NOTE: before dropping a table (when re-executing the script), the tables 
 * having columns acting as foreign keys of the table to be dropped must be 
 * dropped first (otherwise, the corresponding checks on those tables could 
 * not be done).                                                            
 */
 
 USE minigig

/* Drop Table Gig if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Gig]') 
AND type in ('U')) DROP TABLE [Gig]
GO

/* Drop Table MusicType if already exists */

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[MusicType]') 
AND type in ('U')) DROP TABLE MusicType
GO

/* MusicType : Table Creation */

  CREATE TABLE MusicType(
	typeId tinyint NOT NULL,
	description varchar(255) NOT NULL,
	CONSTRAINT [PK_MusicType] PRIMARY KEY (typeId ASC)	
  )
  
  CREATE TABLE Gig(
	gigId int IDENTITY(1,1) NOT NULL,
	name varchar(255) NOT NULL,
	date datetime2(7) NOT NULL,
	typeId tinyint NOT NULL,
  CONSTRAINT [PK_Gig] PRIMARY KEY (gigId ASC),	
  CONSTRAINT [FK_GigTypeId] FOREIGN KEY(typeId)
        REFERENCES MusicType (typeId) ON DELETE CASCADE
  )
  
  CREATE NONCLUSTERED INDEX IX_FK_GigIndexByDate
	ON Gig (gigId,date);
  CREATE NONCLUSTERED INDEX IX_FK_GigIndexByTypeId
	ON Gig (typeId);

GO

INSERT [dbo].[MusicType] ([typeId], [Description]) VALUES (1, N'Jazz')
INSERT [dbo].[MusicType] ([typeId], [Description]) VALUES (2, N'Punk')
INSERT [dbo].[MusicType] ([typeId], [Description]) VALUES (3, N'Pop')
INSERT [dbo].[MusicType] ([typeId], [Description]) VALUES (4, N'Folk')
INSERT [dbo].[MusicType] ([typeId], [Description]) VALUES (5, N'Classic')
INSERT [dbo].[MusicType] ([typeId], [Description]) VALUES (6, N'Rock and Roll')
