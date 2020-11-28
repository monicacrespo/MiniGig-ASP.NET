# Introduction
MiniGig is a simple Model-View-Controller web based application in C# ASP.NET that I built few years ago (2013) and now I have extended it in Visual Studio 2015 Professional with NUnit and Microsoft unit testing. For application packaging and deployment I have used WiX (Windows Installer XML).

The motivation was to design and develop a web application that can be viewed in multiple languages (English and Spanish)
with N-tier architecture using Design patterns such as MVC, Dependency Injection, Facade, DAO, Unit testing as well as the jQuery UI Datepicker widget for date fields in web forms.

MiniGig is a Database First application with Entity Framework 4.0 generating an Entity Data Model from an existing database schema in SQL Server Express.

The solution contains six projects:
*  Model
    * GigDAO
        * GigDaoEntityFramework.cs
        * IGigDAO
    * GigFacade
        * GigService
        * IGigService    
*  Test (Microsoft Unit Testing)
*  NUnitTest
*  Util
*  Web
*  Installer

Use Cases:
*   Set locale
*   Create a gig
    *   gig identifier, name, date, type of music
    *   gig identifier automatic generated
*  Removes the specified gig by its identifier
*  Find the specified gig by its identifier
*  Find the gigs between two dates 

![picture alt](https://github.com/monicacrespo/MiniGig-ASP.NET/blob/master/Web/Images/FindGigsByDate.JPG)

![picture alt](https://github.com/monicacrespo/MiniGig-ASP.NET/blob/master/Web/Images/ResultsGigsByDate.JPG)

# Getting Started
1.	Installation process
    1. Database deployment. Deploy the SQL Scripts (with run order) located on the Model/Sql folder
        1. Database.sql 
        2. Tables.sql 
        3. Users.sql 
        4. UserNetworkService.sql
    2. Application deployment
       1. Copy the following file from the Installer/MSIInstallationFile folder on specific server
            * WixInstaller.msi (MSI deployment package)
       2. Copy the following file from the Installer folder on specific server
            * DV.EMiniGig.bat
       3. Please, review the values of the DV.EMiniGig.bat file to make sure the values are correct, such as the value of sql server instance set up in the parameter V_MINIGIGDBSERVER
       4. Open command prompt as administrator (cmd). In the Command Prompt, navigate to the directory that the install file is located and run it (DV.EMiniGig.bat).
2.	Software dependencies    
    1. .Net Framework 4.0 or higher
    2.  MS SQL Server Express
    
Note. To debug locally, make sure the start page on the Web project is Web/Pages/MainPage.aspx

