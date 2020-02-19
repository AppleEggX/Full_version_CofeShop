using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Pocos;
using Services;
using Repo;

namespace CoffeeShopWCF2
{
    [ServiceContract]
    public interface IService1
    {

        ///////////////////////////////////////
        /////////////Basket////////////////////
        /////////////////////////////////////// 

        [OperationContract]

        List<BasketDTO> GetAllBaskets();

        [OperationContract]
        BasketDTO FindBasketById(int BasketId);

        [OperationContract]
        BasketDTO CreateBasket(Basket basket);

        [OperationContract]
        BasketDTO UpdateBasket(Basket basket);

        [OperationContract]
        BasketDTO DeleteBasket(int basket);


        ///////////////////////////////////////
        /////////////BasketItem////////////////
        /////////////////////////////////////// 

        //[OperationContract]

        //List<BasketItemDTO> GetAllBasketItems();

        [OperationContract]
        BasketItemDTO FindBasketItemById(int BasketItemId);

        [OperationContract]
        BasketItemDTO CreateBasketItem(BasketItem basketItem);

        [OperationContract]
        BasketItemDTO UpdateBasketItem(BasketItem basketItem);

        [OperationContract]
        BasketItemDTO DeleteBasketItem(int basketItem);


        ///////////////////////////////////////
        /////////////Coffee////////////////////
        /////////////////////////////////////// 

        [OperationContract]

        List<CoffeeDTO> GetAllCoffees();

        [OperationContract]
        CoffeeDTO FindCoffeeById(int CoffeeId);

        [OperationContract]
        CoffeeDTO CreateCoffee(Coffee coffee);

        [OperationContract]
        CoffeeDTO UpdateCoffee(Coffee coffee);

        [OperationContract]
        CoffeeDTO DeleteCoffee(int CoffeeId);


        ///////////////////////////////////////
        /////////////Course////////////////////
        /////////////////////////////////////// 

        [OperationContract]

        List<CourseDTO> GetAllCourses();

        [OperationContract]
        CourseDTO FindCourseById(int CourseId);

        [OperationContract]
        CourseDTO CreateCourse(Course course);

        [OperationContract]
        CourseDTO UpdateCourse(Course course);

        [OperationContract]
        CourseDTO DeleteCourse(int CourseId);

        #region Product

        ///////////////////////////////////////
        /////////////Product///////////////////
        /////////////////////////////////////// 

        [OperationContract]
        ProductDTO CreateProduct(Product product);

        [OperationContract]
        ProductDTO UpdateProduct(Product product);

        //[OperationContract]
        //ProductDTO DeleteProduct(int ProductId);
        #endregion

        #region SubscriptionService
        ///////////////////////////////////////
        /////////////Subscription//////////////
        /////////////////////////////////////// 

        [OperationContract]
        List<SubscriptionDTO> GetAllSubscriptions();

        [OperationContract]
        List<SubscriptionDTO> GetSubscriptionByUserId(int userId);


        [OperationContract]

        SubscriptionDTO GetSubscriptionById(int SubscriptionId);

        [OperationContract]
        SubscriptionDTO CreateSubscription(Subscription newSubscrip);

        [OperationContract]
        SubscriptionDTO EditSubscriptionById(int subscriptionId, Subscription newSubscribe);

        //[OperationContract]
        //SubscriptionDTO DeleteSubscription(int SubscriptionId);

        #endregion

        #region UserService
        ///////////////////////////////////////
        /////////////Users/////////////////////
        /////////////////////////////////////// 

        [OperationContract]

        List<UserDTO> GetAllUser();

        [OperationContract]
        UserDTO GetUserById(int UserId);

        [OperationContract]
        UserDTO CreateUser(User user);

        [OperationContract]
        UserDTO EditUser(int userId, User newUser);

        [OperationContract]
        void DeleteUser(int UserId);
        #endregion 

        #region BasketService
        /////////////BasketService/////////////

        [OperationContract]
        BasketItemDTO AddtoBasket(int basketId, int productId, int quantity);

        //////[OperationContract]
        ////// List<ProductDTO> GetAllProduct();

        [OperationContract]
        BasketItemDTO EditBasketItem(int basketItemId, int quantity);

        [OperationContract]
        void DeleteFromBasket(int basketId, int productId);

        [OperationContract]
        BasketDTO CheckOutBasket(int basketId);

        [OperationContract]
        List<BasketItemDTO> GetTheBasketItems(int basketId);

        [OperationContract]
        List<BasketItemDTO> GetAllBasketItems();

        [OperationContract]
        List<BasketDTO> GetHistoryBasket(int userId);

        [OperationContract]
        BasketDTO GetTheBasket(int basketId);

        #endregion

        #region ProductService
        /////////////ProductService/////////////

        [OperationContract]
        List<ProductDTO> GetAllProduct();

        [OperationContract]
        ProductDTO GetProductById(int id);


        [OperationContract]
        CoffeeDTO EditCoffeeById(int coffeeId, Coffee newCoffee);

        [OperationContract]
        CourseDTO EditCourseById(int courseId, Course newCourse);

        [OperationContract]
        CoffeeDTO CreateNewCoffee(Coffee newCoffee);

        [OperationContract]
        CourseDTO CreateNewCourse(Course newCourse);

        [OperationContract]
        void DeleteProduct(int productId);

        #endregion 
    }
}
