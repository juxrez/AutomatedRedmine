
namespace Redmine_for_dummies.Catalog
{
    public static class ActivityExtensions
    {
        public static string ToActivityString(this Activity activity)
        {
            switch(activity)
            {
                case Activity.Design:
                    return "Desing";
                case Activity.Development:
                    return "Development";
                case Activity.TestCaseDesign:
                    return "Test Case Design";
                case Activity.Testing:
                    return "Testing";
                case Activity.Meeting:
                    return "Meeting";
                case Activity.Reporting:
                    return "Reporting";
                case Activity.Research:
                    return "Research";
                case Activity.ITSupport:
                    return "IT Support";
                case Activity.VacationsPTO:
                    return "Vacations/PTO";
                case Activity.InfrastructureDowntime:
                    return "Infrastructure Downtime";
                case Activity.WaitTime:
                    return "Wait Time";
                case Activity.CompTime:
                    return "Comp Time";
                default:
                    return "Not Specified";
            }
            
        }
    }
}
