using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Dtos
{
    public class OrderItemDto : EntityDto<Guid>
    {
        public Guid ProductId { get; set; }
        public  int Quantity { get; set; }
        public  decimal Amount { get; set; }

        public Guid OrderId { get; set; }
        public string Name { get; set; }
    }

    
}
