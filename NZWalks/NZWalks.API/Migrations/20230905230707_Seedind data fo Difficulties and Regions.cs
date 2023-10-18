using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedinddatafoDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("04586839-2f05-44ff-9243-2e63760be123"), "Hard" },
                    { new Guid("227c92c0-a637-4129-a113-9512d02ab604"), "Medium" },
                    { new Guid("2e15ca75-410b-4962-ad24-8a873f7f723c"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "BOP", "Bay Of Plenty", null },
                    { new Guid("52857143-f4e4-4e25-b2fb-379b4988204d"), "AKL", "Auckland", "https://www.bing.com/images/search?view=detailV2&ccid=7qhzYLde&id=0B45D175189187E895159459B45C726C44672BAE&thid=OIP.7qhzYLdeX-Y8cb21DO56PgHaE8&mediaurl=https%3A%2F%2Fc1.staticflickr.com%2F7%2F6152%2F6250123449_ff4944f72c_b.jpg&cdnurl=https%3A%2F%2Fth.bing.com%2Fth%2Fid%2FR.eea87360b75e5fe63c71bdb50cee7a3e%3Frik%3DritnRGxyXLRZlA%26pid%3DImgRaw%26r%3D0&exph=683&expw=1024&q=auckland+image+url&form=IRPRST&ck=1882B8DC540D9857C3DB774931E3928C&selectedindex=2&ajaxhist=0&ajaxserp=0&pivotparams=insightsToken%3Dccid_J9ZlmELU*cp_4E1ADEA5E69DCE756CC6B2DCA78F7553*mid_53C4C450F43887621E4E5EB5C7B78A8E1A42D048*simid_608022938512740459*thid_OIP.J9ZlmELU4aRwxubQS-OJrwHaEK&vt=0&sim=11&iss=VSI&ajaxhist=0&ajaxserp=0" },
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), "NTL", "Northland", null },
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "STL", "Southland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("04586839-2f05-44ff-9243-2e63760be123"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("227c92c0-a637-4129-a113-9512d02ab604"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2e15ca75-410b-4962-ad24-8a873f7f723c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("52857143-f4e4-4e25-b2fb-379b4988204d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"));
        }
    }
}
