using System;
using System.Collections.Generic;

namespace CultureCenter.data;

public partial class Teacher
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Mug> Mugs { get; } = new List<Mug>();
}
