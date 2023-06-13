﻿using System;
using System.Collections.Generic;

namespace BZPAY_BE.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Proyecto1specialticketuser? Proyecto1specialticketuser { get; set; }

    public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();

    public virtual ICollection<Userclaim> Userclaims { get; set; } = new List<Userclaim>();

    public virtual ICollection<Userlogin> Userlogins { get; set; } = new List<Userlogin>();

    public virtual ICollection<Usertoken> Usertokens { get; set; } = new List<Usertoken>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
