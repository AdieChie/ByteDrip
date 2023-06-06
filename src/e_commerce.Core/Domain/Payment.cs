using Abp.Domain.Entities.Auditing;
using e_commerce.Domain.RefList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Domain
{
   public class Payment : FullAuditedEntity<Guid>
    {
        public virtual Order Order  { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListMethod Method { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual decimal Amount { get; set; }
    }
}
