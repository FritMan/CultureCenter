using System;
using System.Collections.Generic;

namespace CultureCenter.data;

public partial class Mug
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string DateStartOfWork { get; set; } = null!;

    public long MugsTypeId { get; set; }

    public long RoomId { get; set; }

    public string TimeStart { get; set; } = null!;

    public long TeacherId { get; set; }

    public string TimeEnd { get; set; } = null!;

    public long DayId1 { get; set; }

    public long? DayId2 { get; set; }

    public long? DayId3 { get; set; }

    public virtual DaysOfWeek DayId1Navigation { get; set; } = null!;

    public virtual DaysOfWeek? DayId2Navigation { get; set; }

    public virtual DaysOfWeek? DayId3Navigation { get; set; }

    public virtual MugsType MugsType { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
