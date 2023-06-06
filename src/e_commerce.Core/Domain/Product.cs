using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Domain
{
    public class Product : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual decimal Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Decsription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Category Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Brand { get; set; }

    }
}