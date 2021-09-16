using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet_MVC.Application.Migrations
{
    public partial class AddStoreProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetAllCoverType
                                 AS BEGIN
                                    SELECT * FROM dbo.CoverTypes END                                
                                ");
            migrationBuilder.Sql(@"CREATE PROC usp_GetCoverType
                                 @Id int
                                 AS BEGIN
                                    SELECT * FROM dbo.CoverTypes 
                                 END                                
                                ");
            migrationBuilder.Sql(@"CREATE PROC usp_UpdateCoverType
                                 @Id int
                                 @Name varchar(100)
                                 AS BEGIN
                                    UPDATE dbo.CoverTypes 
                                    SET Name = @Name
                                    WHERE Id = @Id
                                 END                                
                                ");
            migrationBuilder.Sql(@"CREATE PROC usp_GetCoverType
                                 @Id int
                                 AS BEGIN
                                    SELECT * FROM dbo.CoverTypes 
                                 END                                
                                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
