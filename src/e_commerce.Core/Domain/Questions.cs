using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Domain
{
   public class Questions:FullAuditedEntity<Guid>
    {
        public virtual string Question { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Answer { get; set; }
    }
}
