using fin_app_backend.Models;
using fin_app_backend.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace fin_app_backend.Mapper
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
      CreateMap<Transaction, TransactionModel>()
        .ForMember(dest => dest.Account, m => m.MapFrom(x => x.Account.Name))
        .ForMember(dest => dest.CreatedAt, m => m.MapFrom(x => 
          DateTime.ParseExact(x.Id.ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture)
        ))
        .ForMember(dest => dest.Category, m => m.MapFrom(x => new TransactionCategoryModel { 
          Name = x.Category.Name, 
          Icon = x.Category.Icon 
        }));
    }
  }
}