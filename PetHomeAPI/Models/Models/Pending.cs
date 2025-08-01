using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Pending
{
    public int PeId { get; set; }

    public string Affair { get; set; } = null!;

    public int Principal { get; set; }

    public DateOnly PeBeginTime { get; set; }

    public DateOnly PeFinishTime { get; set; }

    public int PeState { get; set; }
}
