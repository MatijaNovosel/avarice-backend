using avarice_backend.Entities;
using avarice_backend.Repositories;
using avarice_backend.Specifications;
using avarice_backend.Repositories.Base;
using avarice_backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using avarice_backend.Models;

namespace avarice_backend.Repositories
{
  public class AccountRepository : Repository<Account, long>, IAccountRepository
  {

    public AccountRepository(AvariceContext dbContext) : base(dbContext)
    {
    }
  }
}