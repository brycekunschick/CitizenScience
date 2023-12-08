use CitizenScienceDB
GO

create or alter proc [dbo].[GetAllInstitutions]
as
    select * from Institutions
GO

/*
exec GetAllInstitutions
GO
*/

create or alter procedure [dbo].[GetAllResearchAreas]
as
    select [ResearchID]
          ,[ResearchName]
          ,[Description]
          ,[InstitutionID]
    from ResearchAreas
GO

/*
exec GetAllResearchAreas
GO
*/

create or alter procedure [dbo].[GetRAbyInstitution]
    @InstitutionID int
as
    select [ResearchID]
          ,[ResearchName]
          ,[Description]
    from ResearchAreas
    where InstitutionID = @InstitutionID
GO

/*
exec GetRAbyInstitution 301
GO
*/

create or alter procedure [dbo].[GetAllProjects]
as
    select [ProjectID]
          ,[ProjectName]
          ,[StartDate]
          ,[EndDate]
          ,[Coordinator]
          ,[Description]
          ,[ResearchID]
    from Projects
GO

/*
exec GetAllProjects
GO
*/

create or alter procedure [dbo].[GetProjectsByRA]
    @ResearchAreaID int
as
    select [ProjectID]
          ,[ProjectName]
          ,[StartDate]
          ,[EndDate]
          ,[Coordinator]
          ,[Description]
    from Projects
    where ResearchID = @ResearchAreaID
GO

/*
exec GetProjectsByRA 101
GO
*/

create or alter procedure [dbo].[GetProjectDetails]
    @ProjectID int
as
    select [ProjectID]
          ,[ProjectName]
          ,[StartDate]
          ,[EndDate]
          ,[Coordinator]
          ,[Description]
          ,[ResearchID]
    from Projects
    where ProjectID = @ProjectID
GO

/*
exec GetProjectDetails 501
GO
*/




/*
alter table Observations
add UserID nvarchar(64);
*/


create or alter procedure GetObservationsByUser
	@UserID nvarchar(64)
as
	select ObservationID, Notes
	from dbo.Observations
	where UserID = @UserID
GO

/*
exec GetObservationsByUser
*/