using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Dtos
{
  public  class ShippingDto : EntityDto<Guid>
    {
        public Guid OrderId { get; set; }
        public  string Address { get; set; }
        public string City { get; set; }
        public  string Province { get; set; }
        public  string ZipCode { get; set; }
        public string FirstName { get; set; }
        public  string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
