using System;
using System.Collections.Generic;

namespace CultureCenter.data;

public partial class Booking
{
    public long Id { get; set; }

    public string DataStart { get; set; } = null!;

    public string DataEnd { get; set; } = null!;

    public string TimeStart { get; set; } = null!;

    public string TimeEnd { get; set; } = null!;

    public long RoomId { get; set; }

    public long EventsId { get; set; }

    public string? Comment { get; set; }

    public string DataCreation { get; set; } = null!;

    public virtual Event Events { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
