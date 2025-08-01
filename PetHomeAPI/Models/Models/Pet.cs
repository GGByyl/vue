using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Pet
{
    public int Pid { get; set; }

    public string Breed { get; set; } = null!;

    public string Source { get; set; } = null!;

    public string Vaccine { get; set; } = null!;

    public int Store { get; set; }

    public string? Describe { get; set; }

    public int Aeg { get; set; }

    public int Master { get; set; }

    public int Psex { get; set; }

    public string? Pname { get; set; }
}
