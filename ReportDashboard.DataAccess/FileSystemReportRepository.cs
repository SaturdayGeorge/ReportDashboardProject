using ReportDashboard.Abstract;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReportDashboard.DataAccess
{
    public class FileSystemReportRepository : IRepository<Scenario>
    {
        public void Dispose()
        {
        }

        public async Task<IEnumerable<Scenario>> GetAll()
        {
            var data = await File.ReadAllTextAsync(Path.Combine("Data.xml"));
            return   XDocument.Parse(data).Descendants("Scenario").Select(x => new Scenario
            {
                Forename = x.Element("Forename")?.Value,
                ScenarioID = x.Element("ScenarioID")?.Value,
                Name = x.Element("Name")?.Value,
                Surname = x.Element("Surname")?.Value,
                CreationDate = x.Element("CreationDate")?.Value,
                UserID = x.Element("UserID")?.Value,
                MarketID = x.Element("MarketID")?.Value,
                NetworkLayerID = x.Element("NetworkLayerID")?.Value,
                SampleDate = x.Element("SampleDate")?.Value,
                NumMonths = x.Element("NumMonths")?.Value
            }).ToList();
        }
    }
}
