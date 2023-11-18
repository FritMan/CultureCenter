using System;
using System.Collections.Generic;

namespace CultureCenter.data;

public partial class TypesOfEvent
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
