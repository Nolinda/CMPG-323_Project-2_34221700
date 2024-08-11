using System;

namespace _34221700_Project2_CMPG323.Models
{
    public class JobTelemetry
    {
        public int ID { get; set; }
        public string? QueueID { get; set; } // Nullable
        public string? StepDescription { get; set; } // Nullable
        public int? HumanTime { get; set; }
        public string? UniqueReference { get; set; } // Nullable
        public string? UniqueReferenceType { get; set; } // Nullable
        public string? BusinessFunction { get; set; } // Nullable
        public string? Geography { get; set; } // Nullable
        public bool ExcludeFromTimeSaving { get; set; } = false; // Default value
        public string? AdditionalInfo { get; set; } // Nullable
        public DateTime EntryDate { get; set; } = DateTime.UtcNow; // Default value
    }


}
