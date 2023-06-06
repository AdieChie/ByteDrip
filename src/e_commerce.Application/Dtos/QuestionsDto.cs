using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Dtos
{
   public class QuestionsDto:EntityDto<Guid>
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
