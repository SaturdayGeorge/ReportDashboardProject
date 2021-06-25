using Microsoft.AspNetCore.Mvc;
using ReportDashboard.Abstract;
using ReportDashboard.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ReportDashboard.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportBuilder _reportBuilder;
        public ReportController(IReportBuilder reportBuilder)
        {
            _reportBuilder = reportBuilder;
        }

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var report = await _reportBuilder.GetReport();

            if (pageNumber * ReportViewModel.PageEntries > report.Count())
            {
                var indexCorrection = report.Count() % ReportViewModel.PageEntries == 0 ? 0 : 1;
                pageNumber = (report.Count() / ReportViewModel.PageEntries) + indexCorrection;
            }

            if (pageNumber <= 0)
            {
                pageNumber = 1;
            }

            var data = report.Skip((pageNumber - 1) * ReportViewModel.PageEntries).Take(ReportViewModel.PageEntries).ToViewModel();
            data.PageIndex = pageNumber;
            data.TotalPages = report.Count();
            return View(data);
        }
    }
}
