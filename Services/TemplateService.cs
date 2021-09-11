using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Constants;
using fin_app_backend.Models;
using fin_app_backend.Mapper;
using fin_app_backend.Utils;
using System.Linq;

namespace fin_app_backend.Services
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
        TransactionType = template.TransactionType,
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