using System.Collections.Generic;
using Pocos;

namespace Services
{
    interface ISubscribeService
    {
        List<Subscription> GetAllSubscription();
        Subscription GetSubscriptionById(int subscriptionId);
        List<Subscription> GetSubscriptionsByUserId(int userId);
        Subscription CreateSubscription(Subscription newSubscrip);
        Subscription EditSubscriptionById(int subscriptionId, Subscription newSubscribe);
        
        
    }
}
