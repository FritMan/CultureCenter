using System;
using System.Collections.Generic;

namespace CultureCenter.data;

public partial class Event
{
    public long Id { get; set; }

    public string EventDate { get; set; } = null!;

    public string? Description { get; set; }

    public long TypesId { get; set; }

    public virtual TypesOfEvent Types { get; set; } = null!;
}
