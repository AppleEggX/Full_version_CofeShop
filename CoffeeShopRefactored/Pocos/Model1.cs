namespace Pocos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    public partial class Model1 : DbContext
    {
        public virtual DbSet<Coffee> Coffees { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<BasketItem> BasketItems { get; set; }

        public virtual DbSet<TestClass> TestClasses { get; set; }


        public Model1()
            : base("name=Model1")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Basket has many basketItems
            modelBuilder.Entity<Basket>().HasMany(t => t.BasketItems);

            //User has many basket, (for big amount sake , 1-many)
            modelBuilder.Entity<User>().HasMany(t => t.Baskets);
        }
    }
}
