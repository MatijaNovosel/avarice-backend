using System;
using System.Collections.Generic;

#nullable disable

namespace fin_app_backend
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            Histories = new HashSet<History>();
            Settings = new HashSet<Setting>();
            Tags = new HashSet<Tag>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public sbyte EmailConfirmed { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Setting> Settings { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
