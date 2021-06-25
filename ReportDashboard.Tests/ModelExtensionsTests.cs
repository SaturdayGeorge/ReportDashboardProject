using AutoFixture;
using ReportDashboard.Abstract;
using ReportDashboard.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ReportDashboard.Tests
{
    public class ModelExtensionsTests
    {
        private readonly Fixture _fixture;
        private readonly System.Collections.Generic.IEnumerable<Scenario> _scenarios;

        public ModelExtensionsTests()
        {
            _fixture = new Fixture();
            _scenarios = _fixture.CreateMany<Scenario>(60);
        }

        [Fact]
        public void Paging_Limit_Max_Success()
        {
            var model = _scenarios.ToViewModel(100);
            Assert.True(model.PageIndex == 9);
        }

        [Fact]
        public void Paging_Limit_Min_Success()
        {
            var model = _scenarios.ToViewModel(-2);
            Assert.True(model.PageIndex == 1);
        }

        [Fact]
        public void First_Page_Only_Success()
        {
            var scenarios = _fixture.CreateMany<Scenario>(3);
            var model = scenarios.ToViewModel(1);
            Assert.True(model.Scenarios.Count() == 3);
        }

        [Fact]
        public void Last_Page_Items_Few_Items_Success()
        {
            var model = _scenarios.ToViewModel(9);
            Assert.True(model.Scenarios.Count() == 4);
        }
    }
}
