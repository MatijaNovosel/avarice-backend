using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class Appuser
    {
        public Appuser()
        {
            Appsettings = new HashSet<Appsetting>();
            Financialchanges = new HashSet<Financialchange>();
            Financialhistories = new HashSet<Financialhistory>();
            Paymentsources = new HashSet<Paymentsource>();
        }

        public int Id { get; set; }
        public string Uid { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public sbyte EmailConfirmed { get; set; }

        public virtual ICollection<Appsetting> Appsettings { get; set; }
        public virtual ICollection<Financialchange> Financialchanges { get; set; }
        public virtual ICollection<Financialhistory> Financialhistories { get; set; }
        public virtual ICollection<Paymentsource> Paymentsources { get; set; }
    }
}
