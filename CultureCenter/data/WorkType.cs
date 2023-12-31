﻿using System;
using System.Collections.Generic;

namespace CultureCenter.data;

public partial class WorkType
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<WorkOrder> WorkOrders { get; } = new List<WorkOrder>();
}
