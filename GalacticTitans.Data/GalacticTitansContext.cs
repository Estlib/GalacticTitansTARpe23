using GalacticTitans.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticTitans.Data
{
    public class GalacticTitansContext : IdentityDbContext<ApplicationUser>
    {
        public GalacticTitansContext(DbContextOptions<GalacticTitansContext> options) : base(options) {}
        public DbSet<Titan> Titans { get; set; }
        public DbSet<AstralBody> AstralBodies { get; set; }
        public DbSet<SolarSystem> SolarSystems { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<Galaxy> Galaxies { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<PlayerProfile> PlayerProfiles { get; set; }
        public DbSet<TitanOwnership> TitanOwnerships { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Titan>().HasData(
                new Titan
                {
                    ID = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    TitanName = "Seed Titan",
                    TitanHealth = 0,
                    TitanXP = 0,
                    TitanXPNextLevel = 100,
                    TitanLevel = 0,
                    TitanType = TitanType.Unknown,
                    TitanStatus = TitanStatus.Alive,
                    PrimaryAttackName = "Primary Attack",
                    PrimaryAttackPower = 0,
                    SecondaryAttackName = "Secondary Attack",
                    SecondaryAttackPower = 0,
                    SpecialAttackName = "Special Attack",
                    SpecialAttackPower = 0,
                    TitanWasBorn = new DateTime(2025, 1, 1),
                    CreatedAt = new DateTime(2025, 1, 1),
                    UpdatedAt = new DateTime(2025, 1, 1),
                }
            );
            Guid sunid = Guid.Parse("11111111-1111-1111-1111-111111111112");
            Guid planetid = Guid.Parse("11111111-1111-1111-1111-111111111113");
            builder.Entity<AstralBody>().HasData(
                new AstralBody
                {
                    ID = planetid,
                    AstralBodyName = "Seed Planet",
                    AstralBodyType = AstralBodyType.Planet_RockGiant,
                    EnvironmentBoost = TitanType.Earth,
                    AstralBodyDescription = "Example planet in DB, do not use as actual planet",
                    MajorSettlements = 0,
                    TechnicalLevel = KardashevScale.Type1,

                    CreatedAt = new DateTime(2025, 1, 1),
                    ModifiedAt = new DateTime(2025, 1, 1),
                },
                new AstralBody
                {
                    ID = sunid,
                    AstralBodyName = "Seed Sun",
                    AstralBodyType = AstralBodyType.Star_Common,
                    EnvironmentBoost = TitanType.Plasma,
                    AstralBodyDescription = "Example sun in DB, do not use as actual planet",
                    MajorSettlements = 0,
                    TechnicalLevel = KardashevScale.Type1,

                    CreatedAt = new DateTime(2025, 1, 1),
                    ModifiedAt = new DateTime(2025, 1, 1),
                }
            );
            builder.Entity<SolarSystem>().HasData(
                new SolarSystem
                {
                    ID = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                    AstralBodyAtCenter = sunid,
                    //AstralBodyAtCenterWith = new AstralBody
                    //{
                    //    ID = sunid,
                    //    AstralBodyName = "Seed Sun",
                    //    AstralBodyType = AstralBodyType.Star_Common,
                    //    EnvironmentBoost = TitanType.Plasma,
                    //    AstralBodyDescription = "Example sun in DB, do not use as actual planet",
                    //    MajorSettlements = 0,
                    //    TechnicalLevel = KardashevScale.Type1,

                    //    CreatedAt = new DateTime(2025, 1, 1),
                    //    ModifiedAt = new DateTime(2025, 1, 1),
                    //},
                    SolarSystemName = "Seed solar system",
                    SolarSystemLore = "Do not use this solar system for actual gameplay",
                    AstralBodyIDs = new List<Guid> { sunid, planetid },
                    CreatedAt = new DateTime(2025,1,1),
                    UpdatedAt = new DateTime(2025, 1, 1),
                }
            );
            builder.Entity<PlayerProfile>().HasData(
                new PlayerProfile
                {
                    ID = Guid.Parse("10000000-1000-1000-1000-100010001000"),
                    ApplicationUserID = "10000000-1000-1000-1000-100010001000",
                    ScreenName = "DbAdminGT",
                    GalacticCredits = 9999999,
                    ScrapResource = 9999999,
                    Victories = 0,
                    CurrentStatus = ProfileStatus.Active,
                    ProfileType = true,
                    ProfileCreatedAt = new DateTime(2025,1,1),
                    ProfileModifiedAt = new DateTime(2025,1,1),
                    ProfileAttributedToAnAccountUserAt = new DateTime(2025,1,1),
                    ProfileStatusLastChangedAt = new DateTime(2025,1,1)
                }
            );

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    City = "testPassword1!",
                    Id = "10000000-1000-1000-1000-100010001000",
                    PlayerProfileID = Guid.Parse("10000000-1000-1000-1000-100010001000"),
                    ProfileType = true,
                    UserName = "galactus@titanus.com",
                    Email = "galactus@titanus.com",
                    EmailConfirmed = true,
                }
            );
        }
    }
    
}
