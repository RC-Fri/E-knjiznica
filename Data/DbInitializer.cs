using E_knjiznica.Data;
using E_knjiznica.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using NuGet.Configuration;

namespace E_knjiznica.Data;

public static class DbInitializer
{
    public static void Initialize(LibraryContext context)
    {
        context.Database.EnsureCreated();
        // Look for any members.
        if (context.Members.Any())
        {
            return;   // DB has been seeded
        }
        var members = new Member[]
        {
            new Member{FirstMidName="Carson",LastName="Alexander",MembershipDate=DateTime.Parse("2019-09-01"), Credentials="password"},
            new Member{FirstMidName="Meredith",LastName="Alonso",MembershipDate=DateTime.Parse("2017-09-01"), Credentials="password"},
            new Member{FirstMidName="Arturo",LastName="Anand",MembershipDate=DateTime.Parse("2018-09-01"), Credentials="password"},
            new Member{FirstMidName="Gytis",LastName="Barzdukas",MembershipDate=DateTime.Parse("2017-09-01"), Credentials="password"},
            new Member{FirstMidName="Yan",LastName="Li",MembershipDate=DateTime.Parse("2017-09-01"), Credentials="password"},
            new Member{FirstMidName="Peggy",LastName="Justice",MembershipDate=DateTime.Parse("2016-09-01"), Credentials="password"},
            new Member{FirstMidName="Laura",LastName="Norman",MembershipDate=DateTime.Parse("2018-09-01"), Credentials="password"},
            new Member{FirstMidName="Nino",LastName="Olivetto",MembershipDate=DateTime.Parse("2019-09-01"), Credentials="password"}
        };
        context.Members.AddRange(members);
        context.SaveChanges();

        var materials = new Material[]
        {
            new Material{MaterialID=1050,Title="Chemistry"},
            new Material{MaterialID=4022,Title="Microeconomics"},
            new Material{MaterialID=4041,Title="Macroeconomics"},
            new Material{MaterialID=1045,Title="Calculus"},
            new Material{MaterialID=3141,Title="Trigonometry"},
            new Material{MaterialID=2021,Title="Composition"},
            new Material{MaterialID=2042,Title="Literature"}
        };
        context.Materials.AddRange(materials);
        context.SaveChanges();

        var roles = new IdentityRole[] {
            new IdentityRole{Id="1", Name="Administrator"},
            new IdentityRole{Id="2", Name="Manager"},
            new IdentityRole{Id="3", Name="Staff"}
        };
        foreach (IdentityRole r in roles)
        {
            context.Roles.Add(r);
        }
        var user = new ApplicationUser
        {
            FirstName = "Bob",
            LastName = "Dilon",
            Email = "bob@example.com",
            NormalizedEmail = "XXXX@EXAMPLE.COM",
            UserName = "bob@example.com",
            NormalizedUserName = "bob@example.com",
            PhoneNumber = "+111111111111",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };
        if (!context.Users.Any(u => u.UserName == user.UserName))
        {
            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(user,"Testni123!");
            user.PasswordHash = hashed;
            context.Users.Add(user);
            
        }
        context.SaveChanges();
        
        var UserRoles = new IdentityUserRole<string>[]
        {
            new IdentityUserRole<string>{RoleId = roles[0].Id, UserId=user.Id},
            new IdentityUserRole<string>{RoleId = roles[1].Id, UserId=user.Id},
        };
        foreach (IdentityUserRole<string> r in UserRoles)
        {
            context.UserRoles.Add(r);
        }
        context.SaveChanges();
    }
}
