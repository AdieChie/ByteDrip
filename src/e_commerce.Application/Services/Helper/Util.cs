using Abp.Dependency;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using e_commerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.Helper
{
  public static class Util
    {
        public static string GenerateOrderNum()
        {
            var uow = IocManager.Instance.Resolve<IUnitOfWorkManager>();
            var order = IocManager.Instance.Resolve<IRepository<Order, Guid>>();
            using (uow.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var list = order.GetAll();
                var current = list.Count();

                return $"ORD_{current++ }";
            }
        }

        public static T GetEntity<T>(Guid Id) where T: FullAuditedEntity<Guid>
        {
            if (Id == Guid.Empty) return null;

            var repo = IocManager.Instance.Resolve<IRepository<T, Guid>>();

            var entity = repo.Get(Id);
            if (entity is null) return null;

            return entity;
        }
    }
}
