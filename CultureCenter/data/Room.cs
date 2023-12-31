﻿using System;
using System.Collections.Generic;

namespace CultureCenter.data;

public partial class Room
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Mug> Mugs { get; } = new List<Mug>();

    public virtual ICollection<WorkOrder> WorkOrders { get; } = new List<WorkOrder>();
}
