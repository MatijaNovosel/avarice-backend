using avarice_backend.Repositories.Base;
using avarice_backend.Repositories.Interfaces;
using avarice_backend.Models;
using avarice_backend.Mapper;
using avarice_backend.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avarice_backend.Repositories
{
  public class TemplateRepository : Repository<Template, long>, ITemplateRepository
  {
    public TemplateRepository(avariceContext dbContext) : base(dbContext)
    {
    }
  }
}