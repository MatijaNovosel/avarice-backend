using System;
using System.Collections.Generic;
using fin_app_backend.Entities.Base;

#nullable disable

namespace fin_app_backend
{
    public partial class Locale : Entity
    {
        public Locale()
        {
            Settings = new HashSet<Setting>();
        }

        public string Text { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }
    }
}
