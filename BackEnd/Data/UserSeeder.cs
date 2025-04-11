namespace BackEnd.Data{
public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.Users.Any()) return; // DB already seeded

        var data = new List<User>
        {
            new User { Username = "Kev", Email = "Kevin@kevin.com", Tier = "Paid" },
            new User { Username = "Joe", Email = "Joe@Joe.com", Tier = "Free" },
        };

        context.Users.AddRange(data);
        context.SaveChanges();
    }
}

}
