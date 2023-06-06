using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Dtos
{
    public class CategoryDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
