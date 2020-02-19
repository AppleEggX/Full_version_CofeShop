using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Repo;
using Services;
using Pocos;

namespace CoffeeShopWCF2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        
        IRepository<Basket> basketRepository;
        IRepository<BasketItem> basketItemRepository;
        IRepository<Coffee> coffeeRepository;
        IRepository<Course> courseRepository;
        IRepository<Product> productRepository;
        IRepository<Subscription> subscriptionRepository;
        IRepository<User> userRepository;

        BasketService basketService;
        ProductService productService;
        SubscribeService subscribeService;
        UserService userService;

        public Service1()
        {
            basketRepository = new Repository<Basket>();
            basketItemRepository = new Repository<BasketItem>();
            coffeeRepository = new Repository<Coffee>();
            courseRepository = new Repository<Course>();
            productRepository = new Repository<Product>();
            subscriptionRepository = new Repository<Subscription>();
            userRepository = new Repository<User>();

            basketService = new BasketService();
            productService = new ProductService();
            subscribeService = new SubscribeService();
            userService = new UserService();
        }

        #region Crud (REDUNDANT)


        //Basket////Basket////Basket//
        //Basket////Basket////Basket//
        public List<BasketDTO> GetAllBaskets()
        {
            List<Basket> basketList = basketRepository.ReadAll();

            IEnumerable<BasketDTO> basketDTOs = basketList.Select(e => new BasketDTO
            {
                Id = e.Id,
                SumPrice = e.SumPrice,
                Paid = e.Paid,
                User_Id = e.User.Id
            });

            return basketDTOs.ToList();

        }
        public BasketDTO CreateBasket(Basket basket)
        {
            basketRepository.CreateNewEntity(basket);
            return new BasketDTO
            {
                Id = basket.Id,
                SumPrice = basket.SumPrice,
                Paid = basket.Paid,
                User_Id = basket.User.Id
            };
        }
        public BasketDTO UpdateBasket(Basket basket)
        {
            basketRepository.UpdateEntity(basket);
            return new BasketDTO
            {
                Id = basket.Id,
                SumPrice = basket.SumPrice,
                Paid = basket.Paid,
                User_Id = basket.User.Id
            };
        }

        public BasketDTO DeleteBasket(int basketId)
        {
            basketRepository.DeleteEntity(basketId);
            return new BasketDTO
            {
                Id = basketId
            };
        }

        public BasketDTO FindBasketById(int basketId)
        {
            Basket basket = basketRepository.FindById(basketId);
            return new BasketDTO
            {
                Id = basket.Id,
                SumPrice = basket.SumPrice,
                Paid = basket.Paid,
                User_Id = basket.User.Id
            };
        }


        //BasketItem////BasketItem////BasketItem//
        //BasketItem////BasketItem////BasketItem//


     
        public BasketItemDTO CreateBasketItem(BasketItem basketItem)
        {
            basketItemRepository.CreateNewEntity(basketItem);
            return new BasketItemDTO
            {
                BasketItemId = basketItem.BasketItemId,
                ProductType = basketItem.ProductType,
                Quantity = basketItem.Quantity,
                TotalPrice = basketItem.TotalPrice,
                Basket_Id = basketItem.Basket.Id,
                Product_Id = basketItem.Product.Id,
                Product_name = basketItem.Product.Name
            };
        }
        public BasketItemDTO UpdateBasketItem(BasketItem basketItem)
        {
            basketItemRepository.UpdateEntity(basketItem);
            return new BasketItemDTO
            {
                BasketItemId = basketItem.BasketItemId,
                ProductType = basketItem.ProductType,
                Quantity = basketItem.Quantity,
                TotalPrice = basketItem.TotalPrice,
                Basket_Id = basketItem.Basket.Id,
                Product_Id = basketItem.Product.Id,
                Product_name = basketItem.Product.Name
            };
        }

        public BasketItemDTO DeleteBasketItem(int basketItemId)
        {
            basketItemRepository.DeleteEntity(basketItemId);
            return new BasketItemDTO
            {
                BasketItemId = basketItemId
            };
        }

        public BasketItemDTO FindBasketItemById(int basketItemId)
        {
            BasketItem basketItem = basketItemRepository.FindById(basketItemId);
            return new BasketItemDTO
            {
                BasketItemId = basketItem.BasketItemId,
                ProductType = basketItem.ProductType,
                Quantity = basketItem.Quantity,
                TotalPrice = basketItem.TotalPrice,
                Basket_Id = basketItem.Basket.Id,
                Product_Id = basketItem.Product.Id,
                Product_name = basketItem.Product.Name
            };
        }

        //Coffee////Coffee////Coffee//
        //Coffee////Coffee////Coffee//
        public List<CoffeeDTO> GetAllCoffees()
        {
            List<Coffee> coffeeList = coffeeRepository.ReadAll();

            IEnumerable<CoffeeDTO> coffeeDTOs = coffeeList.Select(e => new CoffeeDTO
            {
                Id = e.Id,
                Name = e.Name,
                Type = e.Type,
                Rating = e.Rating,
                Description = e.Description,
                Price = e.Price,
                Origin = e.Origin,
                Stock = e.Stock,
                CoffeeType = e.CoffeeType,
                Strength = e.Strength
            });

            return coffeeDTOs.ToList();

        }
        public CoffeeDTO CreateCoffee(Coffee coffee)
        {
            coffeeRepository.CreateNewEntity(coffee);
            return new CoffeeDTO
            {
                Id = coffee.Id,
                Name = coffee.Name,
                Type = coffee.Type,
                Rating = coffee.Rating,
                Description = coffee.Description,
                Price = coffee.Price,
                Origin = coffee.Origin,
                Stock = coffee.Stock,
                CoffeeType = coffee.CoffeeType,
                Strength = coffee.Strength

            };
        }
        public CoffeeDTO UpdateCoffee(Coffee coffee)
        {
            coffeeRepository.UpdateEntity(coffee);
            return new CoffeeDTO
            {
                Id = coffee.Id,
                Name = coffee.Name,
                Type = coffee.Type,
                Rating = coffee.Rating,
                Description = coffee.Description,
                Price = coffee.Price,
                Origin = coffee.Origin,
                Stock = coffee.Stock,
                CoffeeType = coffee.CoffeeType,
                Strength = coffee.Strength
            };
        }

        public CoffeeDTO DeleteCoffee(int coffeeId)
        {
            coffeeRepository.DeleteEntity(coffeeId);
            return new CoffeeDTO
            {
                Id = coffeeId
            };
        }

        public CoffeeDTO FindCoffeeById(int coffeeId)
        {
            Coffee coffee = coffeeRepository.FindById(coffeeId);
            return new CoffeeDTO
            {
                Id = coffee.Id,
                Name = coffee.Name,
                Type = coffee.Type,
                Rating = coffee.Rating,
                Description = coffee.Description,
                Price = coffee.Price,
                Origin = coffee.Origin,
                Stock = coffee.Stock,
                CoffeeType = coffee.CoffeeType,
                Strength = coffee.Strength
            };
        }
        //Course////Course////Course//
        //Course////Course////Course//

        public List<CourseDTO> GetAllCourses()
        {
            List<Course> courseList = courseRepository.ReadAll();

            IEnumerable<CourseDTO> courseDTOs = courseList.Select(e => new CourseDTO
            {
                Id = e.Id,
                Name = e.Name,
                Type = e.Type,
                Rating = e.Rating,
                Description = e.Description,
                Price = e.Price,
                Length = e.Length,
                Difficulty = e.Difficulty,
                AvailableStartDates = e.AvailableStartDates,
                CourseType = e.CourseType
            });

            return courseDTOs.ToList();

        }
        public CourseDTO CreateCourse(Course course)
        {
            courseRepository.CreateNewEntity(course);
            return new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Type = course.Type,
                Rating = course.Rating,
                Description = course.Description,
                Price = course.Price,
                Length = course.Length,
                Difficulty = course.Difficulty,
                AvailableStartDates = course.AvailableStartDates,
                CourseType = course.CourseType
            };
        }
        public CourseDTO UpdateCourse(Course course)
        {
            courseRepository.UpdateEntity(course);
            return new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Type = course.Type,
                Rating = course.Rating,
                Description = course.Description,
                Price = course.Price,
                Length = course.Length,
                Difficulty = course.Difficulty,
                AvailableStartDates = course.AvailableStartDates,
                CourseType = course.CourseType
            };
        }

        public CourseDTO DeleteCourse(int courseId)
        {
            courseRepository.DeleteEntity(courseId);
            return new CourseDTO
            {
                Id = courseId
            };
        }

        public CourseDTO FindCourseById(int courseId)
        {
            Course course = courseRepository.FindById(courseId);
            return new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Type = course.Type,
                Rating = course.Rating,
                Description = course.Description,
                Price = course.Price,
                Length = course.Length,
                Difficulty = course.Difficulty,
                AvailableStartDates = course.AvailableStartDates,
                CourseType = course.CourseType
            };
        }


        //Subscription////Subscription////Subscription//
        //Subscription////Subscription////Subscription//

        //public List<SubscriptionDTO> GetAllSubscriptions()
        //{
        //    List<Subscription> subscriptionList = subscriptionRepository.ReadAll();

        //    IEnumerable<SubscriptionDTO> subscriptionDTOs = subscriptionList.Select(e => new SubscriptionDTO
        //    {
        //        Id = e.Id,
        //        StartDate = e.StartDate,
        //        EndDate = e.EndDate,
        //        PercentDiscount = e.PercentDiscount,
        //        Quantity = e.Quantity,
        //        User = e.User,
        //        Coffee = e.Coffee

        //    });

        //    return subscriptionDTOs.ToList();

        //}
        //public SubscriptionDTO CreateSubscription(Subscription subscription)
        //{
        //    subscriptionRepository.CreateNewEntity(subscription);
        //    return new SubscriptionDTO
        //    {
        //        Id = subscription.Id,
        //        StartDate = subscription.StartDate,
        //        EndDate = subscription.EndDate,
        //        PercentDiscount = subscription.PercentDiscount,
        //        Quantity = subscription.Quantity,
        //        User = subscription.User,
        //        Coffee = subscription.Coffee

        //    };
        //}
        //public SubscriptionDTO UpdateSubscription(Subscription subscription)
        //{
        //    subscriptionRepository.UpdateEntity(subscription);
        //    return new SubscriptionDTO
        //    {
        //        Id = subscription.Id,
        //        StartDate = subscription.StartDate,
        //        EndDate = subscription.EndDate,
        //        PercentDiscount = subscription.PercentDiscount,
        //        Quantity = subscription.Quantity,
        //        User = subscription.User,
        //        Coffee = subscription.Coffee
        //    };
        //}

        //public SubscriptionDTO DeleteSubscription(int subscriptionId)
        //{
        //    subscriptionRepository.DeleteEntity(subscriptionId);
        //    return new SubscriptionDTO
        //    {
        //        Id = subscriptionId
        //    };
        //}

        //public SubscriptionDTO FindSubscriptionById(int subscriptionId)
        //{
        //    Subscription subscription = subscriptionRepository.FindById(subscriptionId);
        //    return new SubscriptionDTO
        //    {
        //        Id = subscription.Id,
        //        StartDate = subscription.StartDate,
        //        EndDate = subscription.EndDate,
        //        PercentDiscount = subscription.PercentDiscount,
        //        Quantity = subscription.Quantity,
        //        User = subscription.User,
        //        Coffee = subscription.Coffee
        //    };
        //}



        //Product////Product////Product//
        //Product////Product////Product//


        public ProductDTO CreateProduct(Product product)
        {
            productRepository.CreateNewEntity(product);
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Type = product.Type,
                Rating = product.Rating,
                Description = product.Description,
                Price = product.Price

            };
        }
        public ProductDTO UpdateProduct(Product product)
        {
            productRepository.UpdateEntity(product);
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Type = product.Type,
                Rating = product.Rating,
                Description = product.Description,
                Price = product.Price
            };
        }



        #endregion

        #region BasketService

        public List<ProductDTO> GetAllProducts()
        {
            List<Product> productList = basketService.GetAllProducts() ;

            IEnumerable<ProductDTO> productDTOs = productList.Select(e => new ProductDTO
            {
                Id = e.Id,
                Name = e.Name,
                Type = e.Type,
                Rating = e.Rating,
                Description = e.Description,
                Price = e.Price

            });

            return productDTOs.ToList();

        }

        public BasketItemDTO AddtoBasket(int basketId, int productId, int quantity)
        {
            BasketItem basketItem = basketService.AddtoBasket(basketId, productId, quantity);
            return new BasketItemDTO
            {
                BasketItemId = basketItem.BasketItemId,
                ProductType = basketItem.ProductType,
                Quantity = basketItem.Quantity,
                TotalPrice = basketItem.TotalPrice,
                Basket_Id = basketItem.Basket.Id,
                Product_Id = basketItem.Product.Id,
                Product_name = basketItem.Product.Name
            };
        }

        public BasketItemDTO EditBasketItem(int basketItemId, int quantity)
        {
            BasketItem basketItem = basketService.EditBasketItem(basketItemId, quantity);
            return new BasketItemDTO
            {
                BasketItemId = basketItem.BasketItemId,
                ProductType = basketItem.ProductType,
                Quantity = basketItem.Quantity,
                TotalPrice = basketItem.TotalPrice,
                Basket_Id = basketItem.Basket.Id,
                Product_Id = basketItem.Product.Id,
                Product_name = basketItem.Product.Name
            };
        }

        public void DeleteFromBasket(int basketId, int productId)
        {
            basketService.DeleteFromBasket(basketId, productId);
        }

        public BasketDTO CheckOutBasket(int basketId)
        {
            Basket basket = basketService.CheckOutBasket(basketId);
            return new BasketDTO
            {
                Id = basket.Id,
                SumPrice = basket.SumPrice,
                Paid = basket.Paid,
                User_Id = basket.User.Id
            };      
        }

        public List<BasketItemDTO> GetTheBasketItems(int basketId)
        {
            List<BasketItem> basketItemsList = basketService.GetTheBasketItems(basketId);
            IEnumerable<BasketItemDTO> basketItemDTOs = basketItemsList.Select(e => new BasketItemDTO
            {
                BasketItemId = e.BasketItemId,
                ProductType = e.ProductType,
                Quantity = e.Quantity,
                TotalPrice = e.TotalPrice,
                Basket_Id = e.Basket.Id,
                Product_Id = e.Product.Id,
                Product_name = e.Product.Name
            });

            return basketItemDTOs.ToList();

        }

        public List<BasketItemDTO> GetAllBasketItems()
        {
            List<BasketItem> basketItemsList = basketService.GetAllBasketItems();
            IEnumerable<BasketItemDTO> basketItemDTOs = basketItemsList.Select(e => new BasketItemDTO
            {
                BasketItemId = e.BasketItemId,
                ProductType = e.ProductType,
                Quantity = e.Quantity,
                TotalPrice = e.TotalPrice,
                Basket_Id = e.Basket.Id,
                Product_Id = e.Product.Id,
                Product_name = e.Product.Name
            });

            return basketItemDTOs.ToList();
        }

        public List<BasketDTO> GetHistoryBasket(int userId)
        {
            List<Basket> basketList = basketService.GetHistoryBasket(userId);
            IEnumerable<BasketDTO> basketDTOs = basketList.Select(e => new BasketDTO
            {
                Id = e.Id,
                SumPrice = e.SumPrice,
                Paid = e.Paid,
                User_Id = e.User.Id
            });

            return basketDTOs.ToList();
        }

        public BasketDTO GetTheBasket(int basketId)
        {
            Basket basket = basketService.GetTheBasket(basketId);
            BasketDTO basketDTO = new BasketDTO
            {
                Id = basket.Id,
                SumPrice = basket.SumPrice,
                Paid = basket.Paid,
                User_Id = basket.User.Id
            };
            return basketDTO;
        }
        #endregion

        #region ProductService
        //ProductService////ProductService////ProductService//
        //ProductService////ProductService////ProductService//

        public List<ProductDTO> GetAllProduct()
        {
            List<Product> productList = productService.GetAllProduct();
            IEnumerable<ProductDTO> productDTOs = productList.Select(e => new ProductDTO
            {
                Id = e.Id,
                Name = e.Name,
                Type = e.Type,
                Rating = e.Rating,
                Description = e.Description,
                Price = e.Price
            });

            return productDTOs.ToList();

        }

        public ProductDTO GetProductById(int id)
        {
            Product product = productService.GetProductById(id);
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Type = product.Type,
                Rating = product.Rating,
                Description = product.Description,
                Price = product.Price
            };
        }

        public CoffeeDTO CreateNewCoffee(Coffee newCoffee)
        {
            Coffee coffee = productService.CreateNewCoffee(newCoffee);
            return new CoffeeDTO
            {
                Id = coffee.Id,
                Name = coffee.Name,
                Type = coffee.Type,
                Rating = coffee.Rating,
                Description = coffee.Description,
                Price = coffee.Price,
                Origin = coffee.Origin,
                Stock = coffee.Stock,
                CoffeeType = coffee.CoffeeType,
                Strength = coffee.Strength

            };
        }


        public CoffeeDTO EditCoffeeById(int coffeeId, Coffee newCoffee)
        {
            Coffee coffee = productService.EditCoffeeById(coffeeId, newCoffee);
            return new CoffeeDTO
            {
                Id = coffee.Id,
                Name = coffee.Name,
                Type = coffee.Type,
                Rating = coffee.Rating,
                Description = coffee.Description,
                Price = coffee.Price,
                Origin = coffee.Origin,
                Stock = coffee.Stock,
                CoffeeType = coffee.CoffeeType,
                Strength = coffee.Strength
            };
        }

        public CourseDTO CreateNewCourse(Course newCourse)
        {
            Course course = productService.CreateNewCourse(newCourse); 
            return new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Type = course.Type,
                Rating = course.Rating,
                Description = course.Description,
                Price = course.Price,
                Length = course.Length,
                Difficulty = course.Difficulty,
                AvailableStartDates = course.AvailableStartDates,
                CourseType = course.CourseType
            };
        }

        public CourseDTO EditCourseById(int courseId, Course newCourse)
        {
            Course course = productService.EditCourseById(courseId, newCourse);
            return new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Type = course.Type,
                Rating = course.Rating,
                Description = course.Description,
                Price = course.Price,
                Length = course.Length,
                Difficulty = course.Difficulty,
                AvailableStartDates = course.AvailableStartDates,
                CourseType = course.CourseType
            };        
        }

        public void DeleteProduct(int productId)
        {
            productRepository.DeleteEntity(productId);
            return;
        }

        #endregion

        #region SubscribeService
        //Subscription////Subscription////Subscription//

        public List<SubscriptionDTO> GetAllSubscriptions()
        {
            List<Subscription> subscriptionList = subscribeService.GetAllSubscription();

            IEnumerable<SubscriptionDTO> subscriptionDTOs = subscriptionList.Select(e => new SubscriptionDTO
            {
                Id = e.Id,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                PercentDiscount = e.PercentDiscount,
                Quantity = e.Quantity,
                User = e.User,
                Coffee = e.Coffee

            });

            return subscriptionDTOs.ToList();

        }


        public SubscriptionDTO CreateSubscription(Subscription newSubscrip)
        {
            Subscription subscription = subscribeService.CreateSubscription(newSubscrip);
            return new SubscriptionDTO
            {
                Id = subscription.Id,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                PercentDiscount = subscription.PercentDiscount,
                Quantity = subscription.Quantity,
                User = subscription.User,
                Coffee = subscription.Coffee

            };
        }


        public SubscriptionDTO EditSubscriptionById(int subscriptionId, Subscription newSubscribe)
        {
            Subscription subscription = subscribeService.CreateSubscription(newSubscribe);
            return new SubscriptionDTO
            {
                Id = subscription.Id,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                PercentDiscount = subscription.PercentDiscount,
                Quantity = subscription.Quantity,
                User = subscription.User,
                Coffee = subscription.Coffee
            };
        }

        public SubscriptionDTO GetSubscriptionById(int subscriptionId)
        {
            Subscription subscription = subscribeService.GetSubscriptionById(subscriptionId);
            return new SubscriptionDTO
            {
                Id = subscription.Id,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                PercentDiscount = subscription.PercentDiscount,
                Quantity = subscription.Quantity,
                User = subscription.User,
                Coffee = subscription.Coffee
            };
        }


        //
        public List<SubscriptionDTO> GetSubscriptionByUserId(int userId)
        {
            List<Subscription> subscriptionList = subscribeService.GetSubscriptionsByUserId(userId);
            IEnumerable<SubscriptionDTO> subscriptionDTOs = subscriptionList.Select(e => new SubscriptionDTO
            {
                Id = e.Id,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                PercentDiscount = e.PercentDiscount,
                Quantity = e.Quantity,
                User = e.User,
                Coffee = e.Coffee
            });

            return subscriptionDTOs.ToList();
        }


        #endregion

        #region UserService


        //User////User////User//
        //User////User////User//

        public List<UserDTO> GetAllUser()
        {
            List<User> userList = userService.GetAllUser();

            IEnumerable<UserDTO> userDTOs = userList.Select(e => new UserDTO
            {
                Id = e.Id,
                Username = e.Username,
                Email = e.Email,
                Password = e.Password,
                Admin = e.Admin

            });

            return userDTOs.ToList();
        }

        public UserDTO CreateUser(User newUser)
        {
            User user = userService.CreateUser(newUser);
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Admin = user.Admin

            };
        }
        public UserDTO EditUser(int userId, User newUser)
        {
            User user = userService.EditUser(userId, newUser);
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Admin = user.Admin
            };
        }

        public void DeleteUser(int userId)
        {
            userService.DeleteUser(userId);
        }

        public UserDTO GetUserById(int userId)
        {
            User user = userService.GetUserById(userId);
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Admin = user.Admin
            };
        }
        #endregion
    }
}
