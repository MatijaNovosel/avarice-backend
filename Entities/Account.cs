using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Account
    {
        public Account()
        {
            Histories = new HashSet<History>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Currency { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
