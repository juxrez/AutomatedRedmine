using System;

namespace Redmine_for_dummies.Models
{
    public class TfsIteration
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public ItrerationAttributes Attributes { get; set; }

    }

    public class ItrerationAttributes
    {
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
