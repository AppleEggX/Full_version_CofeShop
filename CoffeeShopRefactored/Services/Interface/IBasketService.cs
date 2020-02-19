using System.Collections.Generic;
using Pocos;


namespace Services
{
    interface IBasketService
    {

        BasketItem AddtoBasket(int basketid, int coffeeid, int amount);
        BasketItem EditBasketItem(int basketItemId, int amount);
        void DeleteFromBasket(int basketid, int coffeeid);
        Basket CheckOutBasket(int basketId);
        List<BasketItem> GetTheBasketItems(int basketId);
        List<BasketItem> GetAllBasketItems();
        List<Basket> GetHistoryBasket(int userId);
        Basket GetTheBasket(int BasketId);
    }
}
