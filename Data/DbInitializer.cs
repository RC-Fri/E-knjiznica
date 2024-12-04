using E_knjiznica.Models;
using Microsoft.AspNetCore.Identity;


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
        //TODO: Add hash
        var authors = new Author[]
        {
            new Author
            {
                FirstName = "William",
                LastName = "Shakespeare",
                DateOfBirth = DateTime.Parse("1564-04-23")
            },
            new Author
            {
                FirstName = "Jane",
                LastName = "Austen",
                DateOfBirth = DateTime.Parse("1775-12-16")
            },
            new Author
            {
                FirstName = "Mark",
                LastName = "Twain",
                DateOfBirth = DateTime.Parse("1835-11-30")
            },
            new Author
            {
                FirstName = "Leo",
                LastName = "Tolstoy",
                DateOfBirth = DateTime.Parse("1828-09-09")
            },
            new Author
            {
                FirstName = "Agatha",
                LastName = "Christie",
                DateOfBirth = DateTime.Parse("1890-09-15")
            },
            new Author
            {
                FirstName = "George",
                LastName = "Orwell",
                DateOfBirth = DateTime.Parse("1903-06-25")
            },
            new Author
            {
                FirstName = "J.K.",
                LastName = "Rowling",
                DateOfBirth = DateTime.Parse("1965-07-31")
            },
            new Author
            {
                FirstName = "Ernest",
                LastName = "Hemingway",
                DateOfBirth = DateTime.Parse("1899-07-21")
            }
        };
        context.Authors.AddRange(authors);
        context.SaveChanges();

        var materials = new Material[]
        {
            new Material
            {
                Title = "Romeo and Juliet",
                Genre = "Tragedy",
                PublicationYear = 1597,
                AuthorID = 1
            },
            new Material
            {
                Title = "Pride and Prejudice",
                Genre = "Romance",
                PublicationYear = 1813,
                AuthorID = 2
            },
            new Material
            {
                Title = "Adventures of Huckleberry Finn",
                Genre = "Adventure",
                PublicationYear = 1884,
                AuthorID = 3
            },
            new Material
            {
                Title = "War and Peace",
                Genre = "Historical Fiction",
                PublicationYear = 1869,
                AuthorID = 4
            },
            new Material
            {
                Title = "Murder on the Orient Express",
                Genre = "Mystery",
                PublicationYear = 1934,
                AuthorID = 5
            },
            new Material
            {
                Title = "1984",
                Genre = "Dystopian",
                PublicationYear = 1949,
                AuthorID = 6
            },
            new Material
            {
                Title = "Harry Potter and the Sorcerer's Stone",
                Genre = "Fantasy",
                PublicationYear = 1997,
                AuthorID = 7
            },
            new Material
            {
                Title = "The Old Man and the Sea",
                Genre = "Literary Fiction",
                PublicationYear = 1952,
                AuthorID = 8
            }
        };
        context.Materials.AddRange(materials);
        context.SaveChanges();

        var subsidiaries = new Subsidiary[]
        {
            new Subsidiary
            {
                Name = "Central Library",
                Location = "123 Main Street, City Center"
            },
            new Subsidiary
            {
                Name = "West End Branch",
                Location = "456 Elm Street, West End"
            },
            new Subsidiary
            {
                Name = "East Side Branch",
                Location = "789 Oak Avenue, East Side"
            },
            new Subsidiary
            {
                Name = "North Branch",
                Location = "321 Pine Road, North District"
            },
            new Subsidiary
            {
                Name = "South Branch",
                Location = "654 Maple Lane, South District"
            }
        };

        context.Subsidiaries.AddRange(subsidiaries);
        context.SaveChanges();

        var members = new Member[]
        {
            new Member
            {
                FirstMidName = "Carson",
                LastName = "Alexander",
                Email = "carson.alexander@example.com",
                PhoneNumber = "1234567890",
                MembershipDate = DateTime.Parse("2019-09-01"),
                SubsidiaryID = 1,
                Username = "carson.alexander",
                Credentials = "password"
            },
            new Member
            {
                FirstMidName = "Meredith",
                LastName = "Alonso",
                Email = "meredith.alonso@example.com",
                PhoneNumber = "1234567891",
                MembershipDate = DateTime.Parse("2017-09-01"),
                SubsidiaryID = 2,
                Username = "meredith.alonso",
                Credentials = "password"
            },
            new Member
            {
                FirstMidName = "Arturo",
                LastName = "Anand",
                Email = "arturo.anand@example.com",
                PhoneNumber = "1234567892",
                MembershipDate = DateTime.Parse("2018-09-01"),
                SubsidiaryID = 1,
                Username = "arturo.anand",
                Credentials = "password"
            },
            new Member
            {
                FirstMidName = "Gytis",
                LastName = "Barzdukas",
                Email = "gytis.barzdukas@example.com",
                PhoneNumber = "1234567893",
                MembershipDate = DateTime.Parse("2017-09-01"),
                SubsidiaryID = 3,
                Username = "gytis.barzdukas",
                Credentials = "password"
            },
            new Member
            {
                FirstMidName = "Yan",
                LastName = "Li",
                Email = "yan.li@example.com",
                PhoneNumber = "1234567894",
                MembershipDate = DateTime.Parse("2017-09-01"),
                SubsidiaryID = 2,
                Username = "yan.li",
                Credentials = "password"
            },
            new Member
            {
                FirstMidName = "Peggy",
                LastName = "Justice",
                Email = "peggy.justice@example.com",
                PhoneNumber = "1234567895",
                MembershipDate = DateTime.Parse("2016-09-01"),
                SubsidiaryID = 1,
                Username = "peggy.justice",
                Credentials = "password"
            },
            new Member
            {
                FirstMidName = "Laura",
                LastName = "Norman",
                Email = "laura.norman@example.com",
                PhoneNumber = "1234567896",
                MembershipDate = DateTime.Parse("2018-09-01"),
                SubsidiaryID = 3,
                Username = "laura.norman",
                Credentials = "password"
            },
            new Member
            {
                FirstMidName = "Nino",
                LastName = "Olivetto",
                Email = "nino.olivetto@example.com",
                PhoneNumber = "1234567897",
                MembershipDate = DateTime.Parse("2019-09-01"),
                SubsidiaryID = 2,
                Username = "nino.olivetto",
                Credentials = "password"
            }
        };
        context.Members.AddRange(members);
        context.SaveChanges();

        var loans = new Loan[]
        {
            new Loan
            {
                MemberID = 1,
                MaterialID = 1,
                LoanDate = DateTime.Parse("2024-01-01"),
                DueDate = DateTime.Parse("2024-01-15"),
                ReturnDate = DateTime.Parse("2024-01-10")
            },
            new Loan
            {
                MemberID = 2,
                MaterialID = 2,
                LoanDate = DateTime.Parse("2024-01-05"),
                DueDate = DateTime.Parse("2024-01-20"),
                ReturnDate = null
            },
            new Loan
            {
                MemberID = 3,
                MaterialID = 3,
                LoanDate = DateTime.Parse("2024-02-01"),
                DueDate = DateTime.Parse("2024-02-15"),
                ReturnDate = DateTime.Parse("2024-02-14")
            },
            new Loan
            {
                MemberID = 4,
                MaterialID = 4,
                LoanDate = DateTime.Parse("2024-02-10"),
                DueDate = DateTime.Parse("2024-02-25"),
                ReturnDate = null
            },
            new Loan
            {
                MemberID = 5,
                MaterialID = 5,
                LoanDate = DateTime.Parse("2024-03-01"),
                DueDate = DateTime.Parse("2024-03-15"),
                ReturnDate = DateTime.Parse("2024-03-12")
            },
            new Loan
            {
                MemberID = 6,
                MaterialID = 6,
                LoanDate = DateTime.Parse("2024-03-05"),
                DueDate = DateTime.Parse("2024-03-20"),
                ReturnDate = null
            },
            new Loan
            {
                MemberID = 7,
                MaterialID = 7,
                LoanDate = DateTime.Parse("2024-04-01"),
                DueDate = DateTime.Parse("2024-04-15"),
                ReturnDate = DateTime.Parse("2024-04-14")
            },
            new Loan
            {
                MemberID = 8,
                MaterialID = 8,
                LoanDate = DateTime.Parse("2024-04-10"),
                DueDate = DateTime.Parse("2024-04-25"),
                ReturnDate = null
            }
        };

        context.Loans.AddRange(loans);
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
