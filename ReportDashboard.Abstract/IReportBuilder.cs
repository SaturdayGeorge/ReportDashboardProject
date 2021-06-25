using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportDashboard.Abstract
{
    public interface IReportBuilder
    {
        Task<IEnumerable<Scenario>> GetReport();
    }
}
