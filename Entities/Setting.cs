using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Setting
    {
        public int Id { get; set; }
        public bool? DarkMode { get; set; }
        public int? LocaleId { get; set; }
        public string PreferredCurrency { get; set; }
        public string DateFormat { get; set; }
        public int? UserId { get; set; }

        public virtual Locale Locale { get; set; }
        public virtual User User { get; set; }
    }
}
