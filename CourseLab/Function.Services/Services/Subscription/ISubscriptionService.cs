using Function.Services.Services.Subscription.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Function.Services.Services.Subscription
{
    interface ISubscriptionService
    {
        SubscriptionDto GetById(Guid id);
        List<SubscriptionDto> GetSubscriptionsByUser(Guid id);
        void CreateSubscription(SubscriptionDto subscription);
        void DeleteSubscription(SubscriptionDto subscription);
    }
}
