using ReportDashboard.Abstract;
using System.Collections.Generic;

namespace ReportDashboard.ViewModels
{
    public class ReportViewModel
    {
        public const int PageEntries = 7;
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public IEnumerable<Scenario> Scenarios { get; set; }
    }
}