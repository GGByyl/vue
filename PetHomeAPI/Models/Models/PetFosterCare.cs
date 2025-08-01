using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class PetFosterCare
{
    public int Fid { get; set; }

    public int State { get; set; }

    public int UserId { get; set; }

    public DateOnly BeginTime { get; set; }

    public DateOnly FinishTime { get; set; }

    public int Principal { get; set; }

    public string? Describe { get; set; }

    public int Fpid { get; set; }
}
