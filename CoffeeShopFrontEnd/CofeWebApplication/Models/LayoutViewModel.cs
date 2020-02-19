using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CofeWebApplication.ServiceReference1;
using Pocos;

namespace CofeWebApplication.Models
{
    public class LayoutViewModel
    {
        Service1Client srv1 = new Service1Client();

        public List<BasketItemDTO> basketItemDTOs;
        public List<BasketDTO> basketDTOs;
        public LayoutViewModel()
        {
            basketItemDTOs = srv1.GetAllBasketItems().ToList();
            basketDTOs = srv1.GetAllBaskets().ToList();
        }
    }
    
}