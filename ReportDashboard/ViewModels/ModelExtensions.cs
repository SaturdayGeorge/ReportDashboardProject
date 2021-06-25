using ReportDashboard.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ReportDashboard.ViewModels
{
    public static class ModelExtensions
    {
        public static ReportViewModel ToViewModel(this IEnumerable<Scenario> scenarios)
        {
            return new ReportViewModel
            {
                Scenarios = scenarios.ToArray()
            };
        }
    }
}
