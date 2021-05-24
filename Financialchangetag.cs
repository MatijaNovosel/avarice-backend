using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Financialchangetag
    {
        public int Id { get; set; }
        public int? FinancialChangeId { get; set; }
        public int? TagId { get; set; }

        public virtual Financialchange FinancialChange { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
