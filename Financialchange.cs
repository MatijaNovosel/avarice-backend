using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Financialchange
    {
        public Financialchange()
        {
            Financialchangetags = new HashSet<Financialchangetag>();
        }

        public int Id { get; set; }
        public double? Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public bool? Expense { get; set; }
        public int? PaymentSourceId { get; set; }
        public int? AppUserId { get; set; }
        public sbyte Transfer { get; set; }

        public virtual Appuser AppUser { get; set; }
        public virtual Paymentsource PaymentSource { get; set; }
        public virtual ICollection<Financialchangetag> Financialchangetags { get; set; }
    }
}
