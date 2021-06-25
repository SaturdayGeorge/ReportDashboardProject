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
            
            return View(report.ToViewModel(pageNumber));
        }
    }
}
