using avarice_backend.Models;
using avarice_backend.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using avarice_backend.Utils;

namespace avarice_backend.Mapper
{
  public static class ObjectMapper
  {
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
        cfg.AddProfile<AspnetRunDtoMapper>();
      });
      var mapper = config.CreateMapper();
      return mapper;
    });
    public static IMapper Mapper => Lazy.Value;
  }

  public class AspnetRunDtoMapper : Profile
  {
    public AspnetRunDtoMapper()
    {
      CreateMap<AddTransactionDto, Transaction>();
      CreateMap<Category, CategoryModel>()
        .ForMember(dest => dest.Parent, m => m.MapFrom(x => x.ParentId != null ? new CategoryModel
        {
          Color = x.Parent.Color,
          Icon = x.Parent.Icon,
          Id = x.Parent.Id,
          Name = x.Parent.Name
        } : null));
      CreateMap<Account, AccountModel>();
      CreateMap<Template, TemplateModel>()
        .ForMember(dest => dest.Account, m => m.MapFrom(x => x.Account.Name))
        .ForMember(dest => dest.Currency, m => m.MapFrom(x => x.Account.Currency))
        .ForMember(dest => dest.Category, m => m.MapFrom(x => new TransactionCategoryModel
        {
          Name = x.Category.Name,
          Icon = x.Category.Icon,
          Color = x.Category.Color,
          ParentName = x.Category.Parent != null ? x.Category.Parent.Name : null
        }));
      CreateMap<Transaction, TransactionModel>()
        .ForMember(dest => dest.Account, m => m.MapFrom(x => x.Account.Name))
        .ForMember(dest => dest.Currency, m => m.MapFrom(x => x.Account.Currency))
        .ForMember(dest => dest.TransactionType, m => m.MapFrom(x => x.CategoryId == (long)SystemCategoryEnum.Transfer ? TransactionType.Transfer : (x.Amount < 0 ? TransactionType.Expense : TransactionType.Income)))
        .ForMember(dest => dest.Category, m => m.MapFrom(x => new TransactionCategoryModel
        {
          Name = x.Category.Name,
          Icon = x.Category.Icon,
          Color = x.Category.Color,
          ParentName = x.Category.Parent != null ? x.Category.Parent.Name : null
        }));
    }
  }
}