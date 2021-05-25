using fin_app_backend.Repositories.Base;
using fin_app_backend.Repositories.Interfaces;
using fin_app_backend.Models;
using fin_app_backend.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fin_app_backend.Repositories
{
  public class TransactionTagRepository : Repository<Transactiontag>, ITransactionTagRepository
  {
    public TransactionTagRepository(finappContext dbContext) : base(dbContext)
    {
    }
  }
}