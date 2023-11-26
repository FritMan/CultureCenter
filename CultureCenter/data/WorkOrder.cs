using System;
using System.Collections.Generic;

namespace CultureCenter.data;

public partial class WorkOrder
{
    public long Id { get; set; }

    public long EventsId { get; set; }

    public long RoomId { get; set; }

    public long StatusId { get; set; }

    public long WorkTypesId { get; set; }

    public string DateStart { get; set; } = null!;

    public string DateEnd { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Event Events { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual WorkType WorkTypes { get; set; } = null!;
}
