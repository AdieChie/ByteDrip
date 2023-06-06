using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using e_commerce.Domain;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services
{
    public class QuestionsAppService : ApplicationService, IQuestionsAppService
    {
        private readonly IRepository<Questions, Guid> _questionsRepository;

        public QuestionsAppService(IRepository<Questions, Guid> questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task<QuestionsDto> CreateAsync(QuestionsDto input)
        {
            var Questions = ObjectMapper.Map<Questions>(input);
            await _questionsRepository.InsertAsync(Questions);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<QuestionsDto>(Questions);
        }
        public async Task<List<QuestionsDto>> GetAllList(PagedAndSortedResultRequestDto input)
        {
            var questions = _questionsRepository.GetAllList();
            return ObjectMapper.Map<List<QuestionsDto>>(questions);
        }
    }
}
