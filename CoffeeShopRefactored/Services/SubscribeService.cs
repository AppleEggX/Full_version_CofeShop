using System;
using System.Collections.Generic;
using System.Linq;
using Pocos;
using Repo;

namespace Services
{
    public class SubscribeService : ISubscribeService
    {
        Model1 model1 = new Model1();

        private IRepository<Coffee> coffeeRepository = new Repository<Coffee>();
        private IRepository<Subscription> subscriptionRepository = new Repository<Subscription>();
        private IRepository<User> userRepository = new Repository<User>();

        public Subscription CreateSubscription(Subscription newSubscrip)
        {
            subscriptionRepository.CreateNewEntity(newSubscrip);
            return newSubscrip;
        }

        public Subscription EditSubscriptionById(int subscriptionId, Subscription newSubscribe)
        {
            Subscription subscriptionToEdit = subscriptionRepository.FindById(subscriptionId);
            if (newSubscribe.EndDate != null)
                subscriptionToEdit.EndDate = newSubscribe.EndDate;
            if (newSubscribe.PercentDiscount > 0)
                subscriptionToEdit.PercentDiscount = newSubscribe.PercentDiscount;
            if (newSubscribe.Quantity >0)
                subscriptionToEdit.Quantity = newSubscribe.Quantity;
            if (newSubscribe.StartDate != null)
                subscriptionToEdit.StartDate = newSubscribe.StartDate;
            subscriptionRepository.UpdateEntity(subscriptionToEdit);
            return subscriptionToEdit;
        }

        public Subscription EditSubscriptionById(int subscriptionId)
        {
            throw new NotImplementedException();
        }

        public List<Subscription> GetAllSubscription()
        {
            return subscriptionRepository.ReadAll();
        }

        public Subscription GetSubscriptionById(int subscriptionId)
        {
            return subscriptionRepository.FindById(subscriptionId);
        }

        public List<Subscription> GetSubscriptionsByUserId(int userId)
        {
            return subscriptionRepository.ReadAll().Where(m => m.User.Id == userId).ToList();
        }


    }
}
