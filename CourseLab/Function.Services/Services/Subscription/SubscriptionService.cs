using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Function.Data.Infrastructure;
using Function.Services.Services.Subscription.Dto;
using Omu.ValueInjecter;

namespace Function.Services.Services.Subscription
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IRepository<Data.Entities.Subscription> subRepository;
        private readonly IUnitOfWork unitOfWork;

        public SubscriptionService(IRepository<Data.Entities.Subscription> subRepository, IUnitOfWork unitOfWork)
        {
            this.subRepository = subRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateSubscription(SubscriptionDto subscription)
        {
            subRepository.Add((Data.Entities.Subscription)new Data.Entities.Subscription().InjectFrom(subscription));
            unitOfWork.Commit();
        }

        public void DeleteSubscription(SubscriptionDto subscription)
        {
            subscription.IsDeleted = true;
            subRepository.Update((Data.Entities.Subscription)new Data.Entities.Subscription().InjectFrom(subscription));
            unitOfWork.Commit();
        }

        public SubscriptionDto GetById(Guid id)
        {
            var sub = subRepository.GetById(id);
            if (sub == null)
                return null;
            if(sub.IsDeleted==true)
                return null;
            var subdto = (SubscriptionDto)new SubscriptionDto().InjectFrom(sub);

            return subdto;
        }

        public List<SubscriptionDto> GetSubscriptionsByUser(Guid id)
        {
            var subscriptions = subRepository.Query(x => x.User == id && x.IsDeleted==false).ToList();
            var dtolist = new List<SubscriptionDto>();
            foreach(var sub in subscriptions)
            {
                var subdto = (SubscriptionDto)new SubscriptionDto().InjectFrom(sub);
                dtolist.Add(subdto);
            }
            return dtolist;
        }
    }
}
