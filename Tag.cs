using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Tag
    {
        public Tag()
        {
            Financialchangetags = new HashSet<Financialchangetag>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Financialchangetag> Financialchangetags { get; set; }
    }
}
