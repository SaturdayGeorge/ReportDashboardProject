using ReportDashboard.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportDashboard.Services
{
    public class ReportBuilder : IReportBuilder
    {
        private readonly IRepository<Scenario> _repository;

        public ReportBuilder(IRepository<Scenario> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Scenario>> GetReport()
        {
            return await _repository.GetAll();
        }
    }
}
