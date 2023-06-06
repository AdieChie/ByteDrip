using Abp.Application.Services.Dto;
using e_commerce.Domain.RefList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Dtos
{
  public  class PaymentDto : EntityDto<Guid>
    {
        public Guid OrderId { get; set; }
        public RefListMethod Method { get; set; }
        public  decimal Amount { get; set; }
    }

  
}
