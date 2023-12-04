using System;
using System.Collections.Generic;

namespace CultureCenter.data;

public partial class DaysOfWeek
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Mug> MugDayId1Navigations { get; } = new List<Mug>();

    public virtual ICollection<Mug> MugDayId2Navigations { get; } = new List<Mug>();

    public virtual ICollection<Mug> MugDayId3Navigations { get; } = new List<Mug>();
}
