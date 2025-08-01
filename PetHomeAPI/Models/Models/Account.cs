using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Account
{
    public int Aid { get; set; }

    public string Number { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Sex { get; set; }

    public string Phone { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string IdNumber { get; set; } = null!;

    public int Admins { get; set; }
}
