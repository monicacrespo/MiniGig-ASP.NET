/* *************************************************************** */
/*                SQL Server : Create Database Script              */
/*                                                                 */
/* Command Line Syntax:                                            */
/*     > sqlcmd.exe -U [user] -P [password] -I -i DataBase.sql     */
/*                                                                 */
/* *************************************************************** */

/* --------------------------------------------------------------- */
/* -------------------- Script Code ------------------------------ */
/* --------------------------------------------------------------- */


USE [master]
GO

--/****** Drop database if already exists  ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'minigig')
DROP DATABASE [minigig]
GO

USE [master]
GO
/* DataBase Creation */
                                  

CREATE DATABASE [minigig] ON  PRIMARY 
( NAME = 'minigig', FILENAME = 'C:\Temporary\MyProjects_IT\ASPNET\Database\minigig.mdf') 
LOG ON 
( NAME = 'minigig_log', FILENAME = 'C:\Temporary\MyProjects_IT\ASPNET\Database\minigig_log.ldf')
GO


