using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Dtos
{
  public  class OrderDto : EntityDto<Guid>
    {
        public Guid CustomerId { get; set; }
        public  string OrderNumber { get; set; }
        public string Status { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }

    public class UpdateDto : EntityDto<Guid>
    {
        public string Status { get; set; }
    }

    public class ResponeDto : FullAuditedEntityDto<Guid>
    {
        public Guid CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public string Status { get; set; }
        public string orderCreationDate { get; set; }
    }
}
