using System.Collections.Generic;
using Pocos;

namespace Services
{
    interface IProductService
    {
        List<Product> GetAllProduct();
        Product GetProductById(int id);
        Coffee EditCoffeeById(int coffeeId, Coffee newCoffee);
        Course EditCourseById(int courseId, Course newCourse);
        Coffee CreateNewCoffee(Coffee newCoffee);
        Course CreateNewCourse(Course newCourse);
        void DeleteProduct(int productId);

    }
}
