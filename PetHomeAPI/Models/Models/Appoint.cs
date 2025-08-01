using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Appoint
{
    public int Aid { get; set; }

    public int Auid { get; set; }

    public int Astate { get; set; }

    public int Principal { get; set; }

    public DateOnly Atime { get; set; }

    public int Atype { get; set; }
}
