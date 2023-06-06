using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Domain
{
  public  class OrderItem : FullAuditedEntity<Guid>
    {
        public virtual Product Product  { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int Quantity  { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual decimal Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Order Order { get; set; }
    }
}
