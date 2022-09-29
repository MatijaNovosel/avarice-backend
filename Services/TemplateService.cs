using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using avarice_backend.Services.Interfaces;
using avarice_backend.Repositories.Interfaces;
using avarice_backend.Constants;
using avarice_backend.Models;
using avarice_backend.Mapper;
using avarice_backend.Utils;
using System.Linq;

namespace avarice_backend.Services
{
  public class TemplateService : ITemplateService
  {
    private readonly ITemplateRepository _templateRepository;
    private readonly IAccountRepository _accountRepository;

    public TemplateService(
      ITemplateRepository templateRepository,
      IAccountRepository accountRepository
    )
    {
      _templateRepository = templateRepository ?? throw new ArgumentNullException(nameof(templateRepository));
      _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }

    public async Task AddTemplate(AddTemplateDto template, string userId)
    {
      await _templateRepository.AddAsync(new Template()
      {
        AccountId = template.AccountId,
        Amount = template.Amount,
        CategoryId = template.CategoryId,
        Description = template.Description,
        TransferAccountId = template.AccountToId,
        UserId = userId
      });
    }

    public async Task DeleteTemplate(string userId, long templateId)
    {
      var transaction = await _templateRepository.GetByIdAsync(templateId);
      await _templateRepository.DeleteAsync(transaction);
    }

    public async Task<IEnumerable<TemplateModel>> GetAll(string userId)
    {
      var templates = await _templateRepository.GetAsync(x => x.UserId == userId);
      var mapped = ObjectMapper.Mapper.Map<IEnumerable<TemplateModel>>(templates);
      return mapped;
    }

    public async Task<long> GetCount(string userId)
    {
      var templates = await _templateRepository.GetAsync(x => x.UserId == userId);
      return templates.Count;
    }
  }
}