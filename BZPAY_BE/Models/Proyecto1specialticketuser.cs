using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BZPAY_BE.Models;

public partial class Proyecto1specialticketuser : IdentityUser
{
    public string Id { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;
}
