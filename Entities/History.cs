using System;
using System.Collections.Generic;
using fin_app_backend.Entities.Base;

#nullable disable

namespace fin_app_backend
{
    public partial class History : Entity
    {
        public int? AccountId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }

        public virtual Account Account { get; set; }
        public virtual User User { get; set; }
    }
}
