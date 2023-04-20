using System.ComponentModel;

namespace CarMaintenanceApp.Constants
{
    public class Constant
    {
        public enum CarMaintenanceStatus
        {
            [Description("Waiting")]
            Waiting = 1,
            [Description("In-Progress")]
            InProgress = 2,
            [Description("Completed")]
            Completed = 3
        }
    }
}
