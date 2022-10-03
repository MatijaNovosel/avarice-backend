using avarice_backend.Models;
using System.Collections.Generic;

namespace avarice_backend.Utils
{
  public static class PresetCategories
  {
    public static List<Category> Categories = new List<Category>() {
      // System categories
      new Category()
      {
        Id = 1,
        UserId = null,
        Color = "grey",
        Icon = "mdi-swap-horizontal",
        Name = "Transfer",
        System = true
      },
      // Food & drinks
      new Category()
      {
        Id = 2,
        Color = "#ffffff",
        Icon = "mdi-food-fork-drink",
        Name = "Food & Drinks"
      }
    };
  }
}