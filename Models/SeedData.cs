using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.MembershipTypes.Any())
                {
                    Console.WriteLine("Database already seeded with membership types");
                }
                else
                {
                    context.MembershipTypes.AddRange(
                    new MembershipType
                    {
                        Id = 1,
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0
                    },
                    new MembershipType
                    {
                        Id = 2,
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10
                    },
                    new MembershipType
                    {
                        Id = 3,
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15
                    },
                    new MembershipType
                    {
                        Id = 4,
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20
                    });
                }

                if (context.Genre.Any())
                {
                    Console.WriteLine("Database already seeded with genres");
                }
                else
                {
                    context.Genre.AddRange(
                        new Genre
                        {
                            Id = 1,
                            Name = "Thriller"
                        },
                        new Genre
                        {
                            Id = 2,
                            Name = "Science Fiction"
                        });
                }

                if (context.Books.Any())
                {
                    Console.WriteLine("Database already seeded with books");
                }
                else
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Name = "Pan Tadeusz",
                            AuthorName = "Adam Mickiewicz",
                            GenreId = 1,
                            DateAdded = DateTime.Now,
                            ReleaseDate = DateTime.Now,
                            NumberInStock = 20,
                            NumberAvailable = 10
                        },
                        new Book
                        {
                            Name = "Dziady",
                            AuthorName = "Adam Mickiewicz",
                            GenreId = 2,
                            DateAdded = DateTime.Now,
                            ReleaseDate = DateTime.Now,
                            NumberInStock = 10,
                            NumberAvailable = 5
                        });
                }

                if (context.Customers.Any())
                {
                    Console.WriteLine("Database already seeded with customers");
                }
                else
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            Name = "Jan Kowalski",
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 1,
                            Birthdate = DateTime.Now
                        },
                        new Customer
                        {
                            Name = "Adam Kowalski",
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 2,
                            Birthdate = DateTime.Now
                        });
                }

                context.SaveChanges();
            }
        }
    }
}