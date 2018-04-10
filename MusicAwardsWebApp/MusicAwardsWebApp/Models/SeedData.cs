using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MusicAwardsWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                // look for categoreis
                if (context.AwardCategories.Any())
                {
                    return;
                }

                context.AwardCategories.AddRange(
                    new AwardCategory
                    {
                        Category = "Promising student artiste",
                        Description = "Awarded to the promising breakthrough performer who establishes the public identity of an artiste"
                    },

                    new AwardCategory
                    {
                        Category = "Motivating male student artiste",
                        Description = "Awarded to the male artiste who is an inspiration to his fellow artistes"
                    },

                    new AwardCategory
                    {
                        Category = "Motivating female student artiste",
                        Description = "Awarded to the female artiste who is an inspiration to his fellow artistes"
                    },

                    new AwardCategory
                    {
                        Category = "Best student choice artiste",
                        Description = "Awarded to the performer who has a large fan base before, during and after the event"
                    },

                    new AwardCategory
                    {
                        Category = "Best Male Student Vocalist",
                        Description = "Awarded to the best male student vocalist among fellow artistes"
                    },

                    new AwardCategory
                    {
                        Category = "Best Female student vocalist",
                        Description = "Awarded to the best female student vocalist among fellow artistes"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
