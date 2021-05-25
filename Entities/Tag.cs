using System;
using System.Collections.Generic;
using fin_app_backend.Entities.Base;

#nullable disable

namespace fin_app_backend
{
    public partial class Tag : Entity
    {
        public Tag()
        {
            Transactiontags = new HashSet<Transactiontag>();
        }

        public string Description { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Transactiontag> Transactiontags { get; set; }
    }
}
