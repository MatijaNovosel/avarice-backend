using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Paymentsource
    {
        public Paymentsource()
        {
            Financialchanges = new HashSet<Financialchange>();
            Financialhistories = new HashSet<Financialhistory>();
        }

        public int Id { get; set; }
        public string Currency { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int? AppUserId { get; set; }

        public virtual Appuser AppUser { get; set; }
        public virtual ICollection<Financialchange> Financialchanges { get; set; }
        public virtual ICollection<Financialhistory> Financialhistories { get; set; }
    }
}
