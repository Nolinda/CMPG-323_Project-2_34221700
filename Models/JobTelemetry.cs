using System;

namespace _34221700_Project2_CMPG323.Models
{
    public class JobTelemetry
    {
        public Guid Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? BusinessFunction { get; set; }
        public bool ExcludeFromTimeSaving { get; set; }
        public string? Geography { get; set; }
        public string? JobId { get; set; }
        public string? ProcessId { get; set; }
        public string? QueueId { get; set; }
        public string? StepDescription { get; set; }
        public string? UniqueReference { get; set; }
        public string? UniqueReferenceType { get; set; }

        // Assuming 'ProjectID' and 'ClientId' are foreign key properties
        public Guid ProjectID { get; set; }
        public Guid ClientId { get; set; }

        // Navigation properties
        public virtual Project Project { get; set; } = new Project();
        public virtual Client Client { get; set; } = new Client();

        // Define HumanTime if it's a calculated property or method
        public string? HumanTime
        {
            get
            {
                // Implement logic to calculate HumanTime if needed
                return null;
            }
        }
    }
}
