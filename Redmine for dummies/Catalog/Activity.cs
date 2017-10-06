
using System.ComponentModel;

namespace Redmine_for_dummies.Catalog
{
    public enum Activity
    {
        [Description("Design")]
        Design = 0,
        [Description("Development")]
        Development = 1,
        [Description("Test Case Design")]
        TestCaseDesign = 2,
        [Description("Testing")]
        Testing = 3,
        [Description("Meeting")]
        Meeting = 4,
        [Description("Reporting")]
        Reporting = 5,
        [Description("Research")]
        Research = 6,
        [Description("IT Support")]
        ITSupport = 7,
        [Description("Vacations/PTO")]
        VacationsPTO = 8,
        [Description("Infrastructure Downtime")]
        InfrastructureDowntime = 9,
        [Description("Wait Time")]
        WaitTime = 10,
        [Description("Comp Time")]
        CompTime = 11,
    }
}
