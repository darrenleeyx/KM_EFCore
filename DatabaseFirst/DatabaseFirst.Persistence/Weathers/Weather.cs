using System;
using System.Collections.Generic;

namespace DatabaseFirst.Persistence.Weathers;

public partial class Weather
{
    public Guid Id { get; set; }

    public DateTime DateTime { get; set; }

    public string Description { get; set; } = null!;
}
