using GalacticTitans.Core.Domain;
using GalacticTitans.Core.Domain.SupportingDomain;
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

            string fileid = "11111111-1111-1111-1111-111111111114";
            builder.Entity<FileToDatabase>().HasData(
                new FileToDatabase
                {
                    ID = Guid.Parse(fileid),
                    ImageTitle = "Portrait",
                    ImageData = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAQAAAAEACAIAAADTED8xAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAABG5SURBVHhe7Z29rtw4D4b3zrbdC0mV+0iTCwmQ+wiQZtuUKYIAKVN8zZb5qB/LEvVjSqZnfIav8SDwyBRFUnrtGccz56+///kXALNAAMA0EAAwDQQATAMBANNAAMA0EAAwDQQATAMBANNAAMA0EAAwDQQATAMBANNAAMA0EAAwDQQATAMBANNIBfDh659t+/3BtXz/El/S1m559/m/+OrPny8fd1c5uQ1tPz5/+/v9rx/xFW3/fXrfsvF9XUg/f70Lrj7+DsbBZ3u4yrPrFT18+/Sz47ns6D3XuR/TrMbe+PV7sixo5cV65Z5pS1nkkE1qT34Ec8ppjPXxN/dc17kxFqfh+bqVkCETwL5QElQslglvoeG3EOlQjKlJZilv+f7l6/cPXze3NA0/o8E47dyP2//523l4/+vT1zSRpWc3DSz4OvdjsnG3apTya8dc59XpledVw7Iu/SSkeRVj1QJo2VRjtSl6SVsWV0JAJgDRIuAteaB1GjmCJKuWj7/DLMZGt/P9008XAFkO0s79OMvPv758/vbu868Pmavccx2JfKHksHFpn85be5y0RJoXgSqvXq9WnDtsdOfhhLCLsVLdkufapjFWm6KXsGV1JQTknwGoOm7bPMaXfgtV4y15oLTfvcpLkqxaPnzdBg2nlpC/rwVZDtLO/XjLb3Tu//L5u5skHyHzvC24PP0692PYuFSNYilvo3OqvHq9cv81bPTNw+GctinGIhFmW4qtioeN1abO4rBleSUEZj8EuzS8U9phNeIteaB1GjmHSVYt+VTFtxP+qKvCB7EAwnUztsTFxD3n9rTfyf0Y5of2xVeAIi+1K8B+1KU8lVcxVowwtifPnXjSWG3qXkctfL7kKyEwK4D0vrMuFm/ZAz26Ak6nXRbd7W8t7uXPUdq5n/2NIxEEUHt2wce8qKWTO+EqI7rKpWrQ8o3vjIefAVhenV55Xg12qdRjDea0TTFWWbGjePqZeupeBy0nVkJA/CE4bbGOufJC1XgLRRBfDVc/UaTk1kfa9o65DV+4tCD2Qrgw2mlXnms/n2rPtJOlvy2UtO0rhs7Ng3cOzWr4Lm7b02e08mr2KmrYgvcSzWmbYqxaAPUMNsZqU3iu/VQ2iyshY/YKALrQxIxnF9wQCEAFd2UfnzXBPYEAgGkgAGAaCACYBgIAppEJoH1jK96Bije/WJcNd/ct3rf2ZK6ol7tzkm0/3FMJ+02u3HPphz50Zve/epRjhcbCD2UR992nWD9udSswz303boyeeS7vdu+jgNsxcQXIl6a7+yt65Kh8UKlza5Yt+pYAmB+BANzCrW0KP24s/jAcRVjezCE/2/KlJe5tmqPXmQY/lUNwJ04IQPLIUfWgUvNOOVv0+X70zPwIBFBEmyj9OP/8YbgDAfh4WqPzCN0+JdsOA9yGMwI4fuSIPajUWw15O9sPnvkDTwIBbIvVXXNoa/rx/tnDcNHeb944fwsU1dsYvYqQILPy7R+4H+cE4Oe7/8hRvpjciiEPS1cA7mf2CtDzE96xRMtdAGEpb2RXgI169DpCRx4DuCcnBeAbe48cZe8H9kXWeF/OPWcnWn/mrv0IBODHikuZejX9ZG/Zvf2yABoR8n2PywjXhFshE4BbTGnzc79PuTv5NQXAl1eYeFrf25Z6sYXibqf4LTS2/PiVtG1t+RHlWLWf1qNv+bl8ewvUEEC0oK3pOdhDAPdn4goAwOsBAQDTQADANBAAMA0EAEwDAQDTQADANBAAMA0EAEwDAQDTQADANBAAMA0EAEwDAQDTQADANBAAMA0EAEwDAQDTQADANDIBvK++E1x8L7b8FnnEGezf1v0Yfx3tXfopOP/Nd/YV8t63e9O3hLexqm/uNlo4+9B+c+OWX2Z3ozcyrUevqHtt+YY6pFGcq/w7wVlHn/txFgSrof/qcwx1UEOiGJ33as9XfJnBRt9f+q1d1eF8JeOnMHEFoGSyWKle3RnaoCRTtn6nXBZUmtznVqyKxmQkz4OWNkUWjalq2PSWAoPlctUfYK1q6LJY+JW+Rq9qvmrq0X07q1heh9JzIv2AEh1iRXgolwrA1yv7dTQ6A+3TUx4itmJViBZKf85KiiwkAmiM3obncs0fYK1r6B2u/Epfo1c1KYzG6H6/6JKG2D2PBSCauIs4I4B4CRueIL3ZZlCUjxaWUAAOKpPbNoP40m+hfHVLGzZVsYff0uhlpgQbvU2VyyV/gLWuYVxwk7/S1+lVzFdNY3S/X1SsUdXBfD3z9E9cfAUoe9Xnj/xoNg09XNW2grLR65Y2bKqaoxc2O2n0Nnmv8E4jtsSFkqactuzo1reTF6eu4ZbF3K/09Xp1co80Rvf7Ra9GVeu82FngaTxUAK5k8ezizjQu872IW0uwbJNsWgW9XAAHEea9+E9l7cs0s6T2LeZtdEEWrRoGz86t/Ff6Or3i0dSRUY/u24tejap2BeCKEB0+B5kA3FSlLUwt5T+/4Lziw5Ya6xYOFT1tUS1U0LSFMOqWNgdTVWfaGL2i6lX/VtyZP8DK4BXbs3Dd06LMqePp/TlRNl81zfk6qGpzvrZ1Tw7HI17KxBUAgNcDAgCmgQCAaSAAYBoIAJgGAriKcHPj3ef2H8V5K7xGFgNEAnD5Z5u7aVXd+GvY+L7urlm60evu+sX7cdsNsga7K1/0hmfhjbb4cg+GIfPsWMiiXjrOSdx6t255Sx7hcbn85uLXm506CxFZAMHPHkDwU40lirDy3OslZ+IKQIOxAQQthw9gVVBpYsJK/9XiDm0BtDjyTMxn4WfOHaJ00pTnE+loxVy2ZLHNZCFtOc6LZyGCQt0nzlHPaaeGBxHWnj11pnIuFoDkAaySWPHwMqt74Tk53P20FtMuAHao4Miza5zNooE7dbEV3Iq5K4Ayzor66HGLSl41lVoac9oZ6zDCpg7rTOVcKwDZA1gFRbFo0XQEEK95fvP27tywbdug8eXoxEkceV7JokMMaesyiJm2uDhSbLQ/OA0XWcha9PIqqMdtzGlnrHGEtedAr13CpQLIp9Ovwihll0/vsS31K0DhsIXAc9qkWQxxDrsxly15bEWcFfXRoxb1vCI0iuwK0BhrHGHtOVBnKudKAZSLye1vLe5l/7Et5c8AdMqJDtsceF7LYkTKa0YAjXdQBUUWkpb1vFz8g2tRI9R6TjtjHUTYKULRa5JVAbhQ0rbHlNvIH8Bi0AkjbHlWg9JsiyltYQ1tAvAOc1eMseflLDj5m6u4eloxx5e0uRaKIb4arn6iyOLK2SH8BDHplmTJBj98TjtjHURIO5Vnosh9kgkBABBwshxcAd4UEACYwr//GZ/+3xQQADANBABMAwEA00AAwDRSAaTbWP4DUHGH3t2Z8reoSht/ryDb/I2q6sZfeYd4cDPLOY+WhecYRu2nvhXo7qDFO2vkYY8fGEYmgH15JWgph1sB207DxlHeo029sqONX1CrKR6KynySQ9fY81OM/lH0EBswhUwA7mya/a9EgFZ8/sM+TRuBABq/oFZTPhSV+wz7PT/F6K5d42Ev8ELIPwPQ2nVbtm78LeHirF/blEtwM/BbWoj8F9RqBg9F0X7QYdNPMXoQxumHvcArMfsh2K3gtHSK5bUzsKFDxRUgvKuJNl0B5LLJ7P3RsN/zU4werwxnH/YCr8SsAIqPv8Xy2hnYtAUQX/YEUL2l2X1SFy+Jnp+WAHzj/gBWfR0DhhB/CE5btkbZ8ooGtPVsinO5UwJfuK2FWNvQ+Tv62D51NPw4baTNH92FlF+jIADTzF4BAHgpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmAYCAKaBAIBpIABgGggAmOatCuDP//4KsHYApnjDAgj/QgPgDG9y9eTrHhoAZ3irAmAvoYEpUK7EKwig2QIGoFyJt1eI5uRRIyZVDmqVeBEBEJhUOahV4qUEgHkVgkIlnlyIhVU7sMe8CkGhEs8sRFj9AXaox9hY7sc4KFTiaYXIl3K+P+bQTOjHOKhS4jmFqCdAUQCY3UNQosQTCtFco8KFq2VjHJQo8YRC9KoPATwMlCjx6EIMSn84K2QgmTmhmWVQn8RDC3G4NM8czcEEj0F9Eo8rhKToAxs6JJ82TPAY1CfxuEJIij6wmZozMsYcD0BxEg8qhLzivbU7O2eY4wEoTuIRheit6R5N49k5wxwPQHESjyiEytqFABRBcRKXF4JqvbB26y4Lc7bQxQioTOLaQjSXsgTWa3nCMNNNUJbEtYXQWrgQgC4oS+LaQkAA9wRlSVxYiJNVzrtDALqgLIkLC6ElAC0/EshYDuv7hnjTwetyVSHOL5Hk4bwf1tIjjSjkavvruEkYd+CqQqiUOKyYk66E3dcGCr3kHZuWyYkQ1n0BFSeH5DE/ZsQFrgpLK2GV2h16kIwSbHow4x655UJ3YqFLzcnuPVJsAXb0nlxYCNa4hoqrsYfzQ8i7p7FODhq6L3uY7ZiGO4R1vD+XRKxYCBVXYyfnh5jyQMYB1r7Asp/DXsFzDjN4GfQTu2G9BvGoRDvlQWXExJqrXq8QW4AdelX087xh7QYhqUQ75YSMFUu05or1CiEF8vZnkceTw8xU0Hd6UaBnGJRPJdopJ7r1WfMWetG/ifzoExnEc1Gc+h6viPI8vahUopU7IUvd+ix4CzGoR3Kew5CuCFu5BOrxadGLSiVauRP1+sx6CwHoxqCFMCrdFJQLcc/KEr3AVAKWOyFL3RJNeUuj68agwmxIKZeTKBfihpUN9AJTCVjuhCx1SzTlLRirx6DCQkgqiSgX4oaVDfQCUwlY6ITMAqz9DFPegrFuACosl2W5Y0K5FjcsLjEok0rAQifBTGXExJQ3Mg6w9udyMp6TGT1tMh7JIDCVmIVOgplulWa9kb1uAOc5H8+ZpJ45GXfgTO0SQg/BTLdKC96oi24MZ9AKZtnJkyfjDpyfA2H3YKZbpVlvZJ/Djj4erRiW03nmZNyHM5HL+wZL3SrNesvtaV83mEPYcLoBrLnSzP/B1VTkTOTyvsFSt0qz3mp7atENaQAbSHfcNW/Pj+AmLAcv7xgsdas0661nrxtVDxolH0h30DVvahGw3N4ca/FP9QqWC6MMmPI2jnZ8VIs0ivpYaw7VgnhA7a4mzY2QBfv0rxYLAQwggwBr1+WiUdYc6gRxRT7PQp7IbMrBXrdQU96ExmSmG2QT9VHWvOlE8IB6PQz5xMxmHex1azXlTW5MlrpxMpJzxVHWXOkMf2mxHg+lc5jRQsqhi26tprzNGgdYuwq5W62B1jzopHc++rsxnpXBoQFrvcbIHZ6JeaHjgKbDNFB9SMhaR53EloO+Oc35aDZKWO7YY8rhmaF1Ix+7CmMl2NEeU8Y5Olmtjf0mCJVlMBshZ/rWzHo7ObRi8LNhS+yXY1NISRgiUCzUgiuVoVVSWIhcAuslRKcorAU0OTNPjCfW/HwWTwy+RiGUW+VjhKfX/IwMIABwljvUfFkDEAA4y01qHjQwG8xCl+vA2gVnWZABBABejSkNzArmOiAAoMbUmoYAwKsRzuvClS23vBQIACgzpQHW8nggAKBP0IBkfQvNrgMCAFfxJjQAAYALEa7sJ2oAAgC34FkagADAXQgaeLASIABwOx6pAQgA3JF0KZDA+k4BAYC3DRNDgNkMgACAaSAAYBoIAJgGAgCmgQCAaSAAYBoIAJgGAgCmgQCAaSAAYBoIAJgGAgCmgQCAaSAAYBoIAJgGAgCmgQCAaSAAYBoIAJgGAgCmgQCAaSAAYBoIAJgGAgCmgQCAaSAAYBoIAJgGAgCmgQCAaSAAYBoIAJgGAgCmgQCAaSAAYBoIAJgGAgCmgQCAaSAAYBoIABjmn3//D4SQKEnZLf8fAAAAAElFTkSuQmCC"),
                    TitanID = Guid.Parse("11111111-1111-1111-1111-111111111111")
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
