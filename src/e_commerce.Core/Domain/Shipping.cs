using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Domain
{
  public   class Shipping : FullAuditedEntity<Guid>
    {
        public virtual Order Order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string ZipCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Surname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string PhoneNumber { get; set; }
    }
}
