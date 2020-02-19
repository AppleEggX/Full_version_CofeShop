using System;
using System.Collections.Generic;
using System.Linq;
using Pocos;
using Repo;

namespace Services
{
    public class BasketService : IBasketService
    {
        Model1 model1 = new Model1();
        private IRepository<Product> productRepository = new Repository<Product>();
        private IRepository<Basket> basketRepository = new Repository<Basket>();
        private IRepository<BasketItem> basketItemRepository = new Repository<BasketItem>();

        #region find the product info inside the basket
        public List<Product> GetAllProducts()
        {
            return productRepository.ReadAll();
        }
        public Product GetProductById(int id)
        {
            return productRepository.FindById(id);
        }
        #endregion
        #region basket service
        private void ChangeBasketItem(int basketId, int productId, int quantity)
        {
            BasketItem itemToUpdate = model1.BasketItems.Where(m => m.Product.Id == productId && m.Basket.Id == basketId).FirstOrDefault();
            if (model1.Products.Find(productId).Type == ProductType.Coffee)
            {
                if (itemToUpdate.Quantity + quantity > model1.Coffees.Find(productId).Stock)
                { return; }
                else
                {
                    itemToUpdate.Quantity += quantity;
                    decimal addPrice = quantity * model1.Coffees.FirstOrDefault(m => m.Id == productId).Price;
                    itemToUpdate.TotalPrice += addPrice;
                    model1.Baskets.FirstOrDefault(m => m.Id == basketId).SumPrice += addPrice;
                    model1.SaveChanges();
                }
            }
            else if (model1.Products.Find(productId).Type == ProductType.Course)
            {
                itemToUpdate.Quantity += quantity;
                decimal addPrice = quantity * model1.Courses.FirstOrDefault(m => m.Id == productId).Price;
                itemToUpdate.TotalPrice += addPrice;
                model1.Baskets.FirstOrDefault(m => m.Id == basketId).SumPrice += addPrice;
                model1.SaveChanges();
            }
            
        }
        public BasketItem AddtoBasket(int basketId, int productId, int quantity = 1)
        {
            Product productToAdd = productRepository.FindById(productId);
            Basket basketToChange = basketRepository.FindById(basketId);

            if (productToAdd.Type == ProductType.Course)
            {
                BasketItem itemToAdd = new BasketItem()
                {
                    ProductType = model1.Products.Where(m => m.Id == productId).FirstOrDefault().Type,
                    Product = model1.Products.Where(m => m.Id == productId).FirstOrDefault(),
                    Quantity = quantity,
                    Basket = model1.Baskets.Where(m => m.Id == basketId).FirstOrDefault(),
                    TotalPrice = model1.Coffees.Where(m => m.Id == productId).FirstOrDefault().Price * quantity
                };
                if (model1.BasketItems.Where(m => m.Product.Id == productId && m.Basket.Id == basketId).FirstOrDefault() != null)
                {
                    ChangeBasketItem(basketId, productId, quantity);
                    return itemToAdd;
                }
                model1.BasketItems.Add(itemToAdd);
                model1.SaveChanges();
                basketToChange.SumPrice += itemToAdd.TotalPrice;
                model1.Baskets.Where(m => m.Id == basketId).FirstOrDefault().SumPrice += itemToAdd.TotalPrice;
                model1.SaveChanges();
                Console.WriteLine("Item added");
                return itemToAdd;
            }
            else
            {
                if (productToAdd != null && model1.Coffees.Find(productId).Stock >= quantity)
                {
                    BasketItem itemToAdd = new BasketItem()
                    {
                        ProductType = model1.Products.Where(m => m.Id == productId).FirstOrDefault().Type,
                        Product = model1.Products.Where(m => m.Id == productId).FirstOrDefault(),
                        Quantity = quantity,
                        Basket = model1.Baskets.Where(m => m.Id == basketId).FirstOrDefault(),
                        TotalPrice = model1.Coffees.Where(m => m.Id == productId).FirstOrDefault().Price * quantity
                    };
                    if (model1.BasketItems.Where(m => m.Product.Id == productId && m.Basket.Id == basketId).FirstOrDefault() != null)
                    {
                        ChangeBasketItem(basketId, productId, quantity);
                        return itemToAdd;
                    }
                    model1.BasketItems.Add(itemToAdd);
                    model1.SaveChanges();
                    basketToChange.SumPrice += itemToAdd.TotalPrice;
                    model1.Baskets.Where(m => m.Id == basketId).FirstOrDefault().SumPrice += itemToAdd.TotalPrice;
                    model1.SaveChanges();
                    Console.WriteLine("Item added");
                    return itemToAdd;
                }
                else if (productToAdd != null && model1.Coffees.Find(productId).Stock < quantity)
                {
                    Console.WriteLine("Storage less then {0}", quantity);
                    return null;
                }
                else
                {
                    Console.WriteLine("Wrong Id, No such item to add");
                    return null;
                }
            }
        }

        public BasketItem EditBasketItem(int basketItemId, int quantity)
        {
            BasketItem itemToEdit = basketItemRepository.FindById(basketItemId);
            int productId = itemToEdit.Product.Id;
            if (itemToEdit.ProductType == ProductType.Course)
            {
                decimal oldTotalPrice = itemToEdit.TotalPrice;
                itemToEdit.Quantity = quantity;
                decimal addPrice = quantity * model1.Products.FirstOrDefault(m => m.Id == productId).Price;
                itemToEdit.TotalPrice = addPrice;
                model1.BasketItems.FirstOrDefault(m => m.BasketItemId == basketItemId).Quantity = quantity;
                model1.BasketItems.Find(basketItemId).TotalPrice = addPrice;
                model1.Baskets.FirstOrDefault(m => m.Id == itemToEdit.Basket.Id).SumPrice -= oldTotalPrice;
                model1.Baskets.FirstOrDefault(m => m.Id == itemToEdit.Basket.Id).SumPrice += addPrice;
                model1.SaveChanges();
                return itemToEdit;
            }
            else
            {
                if (quantity > model1.Coffees.Find(productId).Stock)
                { return itemToEdit; }
                else
                {
                    decimal oldTotalPrice = itemToEdit.TotalPrice;
                    itemToEdit.Quantity = quantity;
                    decimal addPrice = quantity * model1.Products.FirstOrDefault(m => m.Id == productId).Price;
                    itemToEdit.TotalPrice = addPrice;
                    model1.BasketItems.FirstOrDefault(m => m.BasketItemId == basketItemId).Quantity = quantity;
                    model1.BasketItems.Find(basketItemId).TotalPrice = addPrice;
                    model1.Baskets.FirstOrDefault(m => m.Id == itemToEdit.Basket.Id).SumPrice -= oldTotalPrice;
                    model1.Baskets.FirstOrDefault(m => m.Id == itemToEdit.Basket.Id).SumPrice += addPrice;
                    model1.SaveChanges();
                    return itemToEdit;
                }
            }
           
        }
        public void DeleteFromBasket(int basketId, int productId)
        {
            Product productToDel = productRepository.FindById(productId);
            Basket basketToChange = basketRepository.FindById(basketId);
            if (basketToChange != null && productToDel != null)
            {
                BasketItem itemToDelete = model1.BasketItems.Where(m => m.Product.Id == productId && m.Basket.Id == basketId).FirstOrDefault();
                if (itemToDelete == null)
                { Console.WriteLine("Item you want to delete not in basket!"); }
                else
                {
                    model1.BasketItems.Remove(itemToDelete);
                    model1.SaveChanges();
                    model1.Baskets.Find(basketId).SumPrice -= itemToDelete.TotalPrice;
                    model1.SaveChanges();
                }
                return;
            }
            else if (productToDel == null)
            { Console.WriteLine("System error, wrong product Id to oprate"); return; }
            else
            { Console.WriteLine("System error, wrong basket Id to oprate"); return; }
        }

        public Basket CheckOutBasket(int basketId)
        {
            Console.WriteLine("The totla money need to pay is {0}", model1.Baskets.FirstOrDefault(m => m.Id == basketId).SumPrice);
            Basket newBasket = new Basket()
            {
                User = model1.Baskets.Find(basketId).User,
                Paid = false
            };
            var itemsInTheBasket = model1.BasketItems.Where(m => m.Basket.Id == basketId).ToArray();
            foreach (var item in itemsInTheBasket)
            {
                if (item.ProductType == ProductType.Coffee)
                {
                    model1.Coffees.Find(item.Product.Id).Stock -= item.Quantity;
                    model1.SaveChanges();
                }
            }
            model1.Baskets.Find(basketId).Paid = true;
            model1.Baskets.Add(newBasket);
            model1.SaveChanges();
            return newBasket;
        }

        public List<BasketItem> GetTheBasketItems(int basketId)
        {
            List<BasketItem> allItems = model1.BasketItems.Where(m => m.Basket.Id == basketId).ToList();
            return allItems;
        }

        public List<BasketItem> GetAllBasketItems()
        {
            return basketItemRepository.ReadAll();
        }
        #endregion

        public List<Basket> GetHistoryBasket(int userId)
        {
            return basketRepository.ReadAll().Where(m => m.User.Id == userId).Where(m => m.Paid == true).ToList();
        }
        public Basket GetTheBasket(int BasketId)
        {
            return basketRepository.FindById(BasketId);
        }
    }
}
