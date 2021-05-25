using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Tag
    {
        public Tag()
        {
            Transactiontags = new HashSet<Transactiontag>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Transactiontag> Transactiontags { get; set; }
    }
}
