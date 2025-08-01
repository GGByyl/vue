using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Adopt
{
    public int AdId { get; set; }

    public int? AdoptUserId { get; set; }

    public int AdoptState { get; set; }

    public DateOnly? AdoptTime { get; set; }

    public int Principal { get; set; }

    public string? Describe { get; set; }

    public int Apid { get; set; }
}
