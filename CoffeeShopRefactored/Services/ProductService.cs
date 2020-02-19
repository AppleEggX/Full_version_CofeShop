using System.Collections.Generic;
using Pocos;
using Repo;

namespace Services
{
    public class ProductService : IProductService
    {
        Model1 model1 = new Model1();

        private IRepository<Coffee> coffeeRepository = new Repository<Coffee>();
        private IRepository<Course> courseRepository = new Repository<Course>();
        private IRepository<Product> productRepository = new Repository<Product>();
       
        public List<Product> GetAllProduct()
        {
            return productRepository.ReadAll();
        }
        public Product GetProductById(int id)
        {
            return productRepository.FindById(id);
        }

        private Product EditProductById(int id, Product newEntity)
        {
            Product productToEdit = productRepository.FindById(id);
            if (newEntity.Description != null)
                productToEdit.Description = newEntity.Description;
            if (newEntity.Name != null) productToEdit.Name = newEntity.Name;
            if (newEntity.Price >= 0) productToEdit.Price = newEntity.Price;
            if (newEntity.Rating > 0) productToEdit.Rating = newEntity.Rating;
            productRepository.UpdateEntity(productToEdit);
            return productToEdit;
        }
        public Coffee EditCoffeeById(int coffeeId, Coffee newCoffee)
        {
            Coffee coffeeToEdit = coffeeRepository.FindById(coffeeId);
            coffeeToEdit.CoffeeType = newCoffee.CoffeeType;
            coffeeToEdit.Origin = newCoffee.Origin;
            if (newCoffee.Stock >= 0) coffeeToEdit.Stock = newCoffee.Stock;
            if (newCoffee.Strength>0 && newCoffee.Strength <6)
                coffeeToEdit.Strength = newCoffee.Strength;
            coffeeRepository.UpdateEntity(coffeeToEdit);
            EditProductById(coffeeId, newCoffee);
            return coffeeToEdit;
        }
        public Course EditCourseById(int courseId, Course newCourse)
        {
            Course courseToEdit = courseRepository.FindById(courseId);
            if (newCourse.AvailableStartDates != null)
                courseToEdit.AvailableStartDates = newCourse.AvailableStartDates;
            courseToEdit.CourseType = newCourse.CourseType;
            courseToEdit.Difficulty = newCourse.Difficulty;
            courseToEdit.Length = newCourse.Length;
            courseRepository.UpdateEntity(courseToEdit);
            EditProductById(courseId, newCourse);
            return courseToEdit;
        }

        public Coffee CreateNewCoffee(Coffee newCoffee)
        {
            coffeeRepository.CreateNewEntity(newCoffee);
            return newCoffee;
        }
        public Course CreateNewCourse(Course newCourse)
        {
            courseRepository.CreateNewEntity(newCourse);
            return newCourse;
        }

        public void DeleteProduct(int productId)
        {
            productRepository.DeleteEntity(productId);
        }

    }
}
