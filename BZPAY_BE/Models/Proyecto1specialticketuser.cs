using System;
using System.Collections.Generic;

namespace BZPAY_BE.Models;

public partial class Proyecto1specialticketuser
{
    public string Id { get; set; } = null!;

    public virtual User IdNavigation { get; set; } = null!;
}
