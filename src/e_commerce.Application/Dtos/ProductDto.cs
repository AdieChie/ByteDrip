using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using e_commerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Dtos
{
    public class ProductDto : EntityDto<Guid>
    {
        public  string Name { get; set; }
        public  decimal Price { get; set; }
        public  string Image { get; set; }
        public  string Decsription { get; set; }
        public  Guid CategoryId { get; set; }
        public  string Brand { get; set; }
    }
}
