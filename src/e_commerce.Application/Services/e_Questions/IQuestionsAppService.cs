using Abp.Application.Services;
using Abp.Application.Services.Dto;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services
{
   public interface IQuestionsAppService : IApplicationService
    {
       
            Task<QuestionsDto> CreateAsync(QuestionsDto input);
        Task<List<QuestionsDto>> GetAllList(PagedAndSortedResultRequestDto input);
    }
}
