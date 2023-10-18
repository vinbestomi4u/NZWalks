using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions) 
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data for difficulties
            // Easy, medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("2e15ca75-410b-4962-ad24-8a873f7f723c"),
                    Name = "Easy"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("227c92c0-a637-4129-a113-9512d02ab604"),
                    Name = "Meduim"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("04586839-2f05-44ff-9243-2e63760be123"),
                    Name = "Hard"

                }
            };

            // Seed difficulties to data base
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("52857143-f4e4-4e25-b2fb-379b4988204d"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://www.bing.com/images/search?view=detailV2&ccid=7qhzYLde&id=0B45D175189187E895159459B45C726C44672BAE&thid=OIP.7qhzYLdeX-Y8cb21DO56PgHaE8&mediaurl=https%3A%2F%2Fc1.staticflickr.com%2F7%2F6152%2F6250123449_ff4944f72c_b.jpg&cdnurl=https%3A%2F%2Fth.bing.com%2Fth%2Fid%2FR.eea87360b75e5fe63c71bdb50cee7a3e%3Frik%3DritnRGxyXLRZlA%26pid%3DImgRaw%26r%3D0&exph=683&expw=1024&q=auckland+image+url&form=IRPRST&ck=1882B8DC540D9857C3DB774931E3928C&selectedindex=2&ajaxhist=0&ajaxserp=0&pivotparams=insightsToken%3Dccid_J9ZlmELU*cp_4E1ADEA5E69DCE756CC6B2DCA78F7553*mid_53C4C450F43887621E4E5EB5C7B78A8E1A42D048*simid_608022938512740459*thid_OIP.J9ZlmELU4aRwxubQS-OJrwHaEK&vt=0&sim=11&iss=VSI&ajaxhist=0&ajaxserp=0"
                },

                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            //Seed region to data base
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
