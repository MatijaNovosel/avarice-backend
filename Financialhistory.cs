using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Financialhistory
    {
        public int Id { get; set; }
        public int? PaymentSourceId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? AppUserId { get; set; }

        public virtual Appuser AppUser { get; set; }
        public virtual Paymentsource PaymentSource { get; set; }
    }
}
