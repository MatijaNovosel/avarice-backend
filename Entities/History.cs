using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class History
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UserId { get; set; }

        public virtual Account Account { get; set; }
        public virtual User User { get; set; }
    }
}
