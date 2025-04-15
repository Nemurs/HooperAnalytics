// using BackEnd.Data;
// namespace AspNetCore.Identity.Database{
// public static class DbInitializer
// {
//     public static void Seed(AppDbContext context)
//     {
//         if (context.Users.Any()) return; // DB already seeded

//         var data = new List<User>
//         {
//             new User { Username = "Kev", Tier = "Paid" },
//             new User { Username = "Joe", Tier = "Free" },
//         };

//         context.Users.AddRange(data);
//         context.SaveChanges();
//     }
// }

// }
