using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet_MVC.Infrastructure.Persistence.Migrations
{
    public partial class AddStoreProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetAllCoverType
                                 AS BEGIN
                                    SELECT * FROM dbo.CoverType END                                
                                ");
            migrationBuilder.Sql(@"CREATE PROC usp_GetCoverType
                                 @Id int
                                 AS BEGIN
                                    SELECT * FROM dbo.CoverType 
                                 END                                
                                ");
            migrationBuilder.Sql(@"CREATE PROC usp_UpdateCoverType
                                 @Id int,
                                 @Name varchar(100)
                                 AS BEGIN
                                    UPDATE dbo.CoverType 
                                    SET Name = @Name
                                    WHERE Id = @Id
                                 END                                
                                ");
            migrationBuilder.Sql(@"CREATE PROC usp_DeleteCoverType
                                 @Id int
                                 AS BEGIN
                                    DELETE FROM dbo.CoverType 
                                    WHERE Id = @Id
                                 END                                
                                ");
            migrationBuilder.Sql(@"CREATE PROC usp_CreateCoverType
                                 @Name varchar(100)
                                 AS BEGIN
                                    INSERT INTO dbo.CoverType(Name)
                                    VALUES (@Name)
                                 END                                
                                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql(@"DROP PROCEDURE usp_GetAllCoverType");
           migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoverType");
           migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateCoverType");
           migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteCoverType");
           migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateCoverType");

        }
    }
}
