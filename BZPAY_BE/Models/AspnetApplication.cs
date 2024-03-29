﻿using System;
using System.Collections.Generic;

namespace BZPAY_BE.Models
{
    public partial class AspnetApplication
    {
        public AspnetApplication()
        {
            AspnetMemberships = new HashSet<AspnetMembership>();
            Users = new HashSet<Users>();
        }

        public string ApplicationName { get; set; } = null!;
        public string LoweredApplicationName { get; set; } = null!;
        public Guid ApplicationId { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<AspnetMembership> AspnetMemberships { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
