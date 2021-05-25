using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fin_app_backend.Services.Interfaces;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Models;
using fin_app_backend.Mapper;

namespace fin_app_backend.Services
{
  public class TagService : ITagService
  {
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
      _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
    }

    public async Task<IEnumerable<TagModel>> GetTags()
    {
      var tags = await _tagRepository.GetAllAsync();
      var mapped = ObjectMapper.Mapper.Map<IEnumerable<TagModel>>(tags);
      return mapped;
    }
  }
}