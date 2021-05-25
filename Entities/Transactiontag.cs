using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Transactiontag
    {
        public int Id { get; set; }
        public int? TransactionId { get; set; }
        public int? TagId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
