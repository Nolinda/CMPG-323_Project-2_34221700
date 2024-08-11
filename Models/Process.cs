using System;
using System.Collections.Generic;

namespace _34221700_Project2_CMPG323.Models;

public partial class Process
{
    public Guid ProcessId { get; set; }

    public string ProcessName { get; set; } = null!;

    public string ProcessType { get; set; } = null!;

    public bool IsFramework { get; set; }

    public bool RequiresDefaultConfig { get; set; }

    public string Submitter { get; set; } = null!;

    public DateTime DateSubmitted { get; set; }

    public string? ProcessConfigUrl { get; set; }

    public string? ReportUrl { get; set; }

    public Guid? ProjectId { get; set; }
}
