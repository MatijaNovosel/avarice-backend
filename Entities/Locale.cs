using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Locale
    {
        public Locale()
        {
            Settings = new HashSet<Setting>();
        }

        public int Id { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }
    }
}
