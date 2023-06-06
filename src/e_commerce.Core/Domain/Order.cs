using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Domain
{
   public  class Order : FullAuditedEntity<Guid>
    {
        public virtual Customer Customer  { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string OrderNumber  { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public virtual string Status { get; set; }

    }
}
