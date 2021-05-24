using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Appsetting
    {
        public int Id { get; set; }
        public bool? DarkMode { get; set; }
        public int? LocaleId { get; set; }
        public string PreferredCurrency { get; set; }
        public string DateFormat { get; set; }
        public int? AppUserId { get; set; }

        public virtual Appuser AppUser { get; set; }
        public virtual Locale Locale { get; set; }
    }
}
