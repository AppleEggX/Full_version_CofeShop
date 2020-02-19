namespace Pocos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pocos.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pocos.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Coffees.AddOrUpdate(x => x.Id,
            //    new Coffee()
            //    {
            //        Id = 1,
            //        Name = "Santa Marta",
            //        Type = ProductType.Coffee,
            //        Rating = 4,
            //        Description = "A rich tasting coffee from the mineral rich soils of Guatemala, this beautifully aromatic coffee will not disappoint",
            //        Price = 10,
            //        Origin = CountryOfOrigin.Guatemala,
            //        Stock = 200,
            //        CoffeeType = CoffeeType.Aeropress,
            //        Strength = 4,
            //        Imgurl = "https://cmkt-image-prd.freetls.fastly.net/0.1.0/ps/4423621/2000/1333/m1/fpnw/wm0/_mg_7215-.jpg?1525810534&s=a6438f4c14f67fc9dff4a2e8a19fc209"
            //    },
            //    new Coffee
            //    {
            //        Id = 2,
            //        Name = "Duromina Washed",
            //        Type = ProductType.Coffee,
            //        Rating = 3,
            //        Description = "Delicate and tea like with a hint of Apricot, clean and complex on the palate, most enjoyable black",
            //        Price = 29,
            //        Origin = CountryOfOrigin.Ethiopia,
            //        Stock = 10,
            //        CoffeeType = CoffeeType.Chemex,
            //        Strength = 2,
            //        Imgurl = "https://u5j4h3u7.stackpathcdn.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/B/S/BSCBEA-400.jpg"
            //    },
            //    new Coffee
            //    {
            //        Id = 3,
            //        Name = "The Docks House Blend",
            //        Type = ProductType.Coffee,
            //        Rating = 4,
            //        Origin = CountryOfOrigin.Bolivia,
            //        Description = "A Custom Blend of Coffee and hot Chocolate with a hint of orange, great for winter warming",
            //        Price = 7,
            //        CoffeeType = CoffeeType.Espresso,
            //        Strength = 2,
            //        Imgurl = "https://ictcoffee.com/wp-content/uploads/2019/09/how-to-roast-coffee-beans.jpeg"
            //    },

            //     new Coffee
            //     {
            //        Id = 3,
            //        Name = "Los Pozitos",
            //        Type = ProductType.Coffee,
            //        Rating = 4,
            //        Origin = CountryOfOrigin.Nicaragua,
            //        Description = "A rich coffee with a hint of red apple and caramel",
            //        Price = 7,
            //        CoffeeType = CoffeeType.FrenchPress,
            //        Strength = 2,
            //        Imgurl = "https://ictcoffee.com/wp-content/uploads/2019/09/how-to-roast-coffee-beans.jpeg"
            //      },

            //     new Coffee
            //      {
            //        Id = 3,
            //        Name = "The Docks House Blend",
            //        Type = ProductType.Coffee,
            //        Rating = 4,
            //        Origin = CountryOfOrigin.Bolivia,
            //        Description = "A Custom Blend of Coffee and hot Chocolate with a hint of orange, great for winter warming",
            //        Price = 7,
            //        CoffeeType = CoffeeType.Espresso,
            //        Strength = 2,
            //        Imgurl = "https://ictcoffee.com/wp-content/uploads/2019/09/how-to-roast-coffee-beans.jpeg"
            //      },

            //      new Coffee
            //       {
            //        Id = 3,
            //         Name = "Ruchu AA",
            //         Type = ProductType.Coffee,
            //         Rating = 4,
            //         Origin = CountryOfOrigin.Kenya,
            //         Description = "A Bold Coffee with a hint of lemon, profits from each pack goes to supporting young people and women in Kenya!",
            //         Price = 7,
            //         CoffeeType = CoffeeType.PourOver,
            //         Strength = 4,
            //          Imgurl = "https://ictcoffee.com/wp-content/uploads/2019/09/how-to-roast-coffee-beans.jpeg"
            //                      }

            //    );

            //context.Courses.AddOrUpdate(x => x.Id,
            //    new Course
            //    {
            //        Name = "Baking Beans",
            //        Type = ProductType.Course,
            //        Rating = 5,
            //        Description = " This course will teach you what's the different between long baked bean and short baked beans, and it will also teach you how to bake your bean by yourself if you want to tates some unique coffee taste.",
            //        Price = 2,
            //        CourseType = CourseType.Roasting,
            //        Difficulty = Difficulty.Intermediate,
            //        Length = "10 Days"
            //    },
            //    new Course
            //    {
            //        Name = "Know the Beans",
            //        Type = ProductType.Course,
            //        Rating = 5,
            //        Description = " Tell you the difference among all kinds of coffee bean, and what's there features",
            //        Price = 5,
            //        CourseType = CourseType.Barista,
            //        Difficulty = Difficulty.Beginner,
            //        Length = "5 Days"
            //    }
            //    );
            //context.Users.AddOrUpdate(x => x.Id,
            //    new User
            //    {
            //        Id = 1,
            //        Username = "testing",
            //        Email = "testc@test.com",
            //        Password = "pwd",
            //        Admin = true
            //    }
            //    );
        }
    }
}
