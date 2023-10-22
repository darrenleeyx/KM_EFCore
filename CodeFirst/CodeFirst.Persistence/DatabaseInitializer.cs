using CodeFirst.Persistence.Weathers;

namespace CodeFirst.Persistence;

public class DatabaseInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Weathers.Any())
        {
            return;
        }

        var now = DateTime.Now;

        var weathers = new List<Weather>
        {
            new Weather
            {
                Id = Guid.NewGuid(),
                DateTime = now.AddHours(-10),
                Description = "Sunny"
            },
            new Weather
            {
                Id = Guid.NewGuid(),
                DateTime = now.AddHours(-5),
                Description = "Cloudy"
            },
            new Weather
            {
                Id = Guid.NewGuid(),
                DateTime = now,
                Description = "Raining"
            },
        };
        context.Weathers.AddRange(weathers);
        context.SaveChanges();
    }
}
