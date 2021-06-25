using ReportDashboard.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ReportDashboard.ViewModels
{
    public static class ModelExtensions
    {
        public static ReportViewModel ToViewModel(this IEnumerable<Scenario> scenarios, int pageNumber)
        {
            var numberOfScenarios = scenarios.Count();
            if (pageNumber * ReportViewModel.PageEntries > scenarios.Count())
            {
                var indexCorrection = numberOfScenarios % ReportViewModel.PageEntries == 0 ? 0 : 1;
                pageNumber = (numberOfScenarios / ReportViewModel.PageEntries) + indexCorrection;
            }

            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }

            return new ReportViewModel
            {
                PageIndex = pageNumber,
                TotalPages = numberOfScenarios,
                Scenarios = scenarios.Skip((pageNumber - 1) * ReportViewModel.PageEntries).Take(ReportViewModel.PageEntries)
            };
        }
    }
}
