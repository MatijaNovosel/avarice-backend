using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Locale
    {
        public Locale()
        {
            Appsettings = new HashSet<Appsetting>();
        }

        public int Id { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Appsetting> Appsettings { get; set; }
    }
}
