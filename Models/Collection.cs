using System.Collections.Generic;

namespace fin_app_backend.Models 
{
  public class PageableCollection<TResult>
  {
    public IEnumerable<TResult> Results { get; set; }
    public long Total { get; set; }
  }
}