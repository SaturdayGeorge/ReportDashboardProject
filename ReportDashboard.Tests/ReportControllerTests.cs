using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReportDashboard.Abstract;
using ReportDashboard.Controllers;
using ReportDashboard.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ReportDashboard.Tests
{
    public class ReportControllerTests
    {
        private readonly Fixture _fixture;
        private readonly Mock<IReportBuilder> _reportBuilder;
        private readonly Mock<HttpContext> _contextMock;
        private readonly ReportController controller;

        public ReportControllerTests()
        {
            _reportBuilder = new Mock<IReportBuilder>();
            _contextMock = new Mock<HttpContext>();
            _fixture = new Fixture();
            _reportBuilder.Setup(rb => rb.GetReport()).ReturnsAsync(_fixture.CreateMany<Scenario>(60));
            controller = new ReportController(_reportBuilder.Object);
            controller.ControllerContext.HttpContext = _contextMock.Object;
        }

        [Fact]
        public async Task Index_Success()
        {
            var result = await controller.Index(1);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ReportViewModel>(viewResult.Model);
            Assert.True(model.Scenarios.Count() == ReportViewModel.PageEntries);
        }

        [Fact]
        public async Task Paging_Limit_Max_Success()
        {
            var result = await controller.Index(100);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ReportViewModel>(viewResult.Model);
            Assert.True(model.PageIndex == 9);
        }

        [Fact]
        public async Task Paging_Limit_Min_Success()
        {
            var result = await controller.Index(-2);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ReportViewModel>(viewResult.Model);
            Assert.True(model.PageIndex == 1);
        }

        [Fact]
        public async Task First_Page_Only_Success()
        {
            _reportBuilder.Setup(rb => rb.GetReport()).ReturnsAsync(_fixture.CreateMany<Scenario>(3));
            var result = await controller.Index(1);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ReportViewModel>(viewResult.Model);
            Assert.True(model.Scenarios.Count() == 3);
        }

        [Fact]
        public async Task Last_Page_Items_Few_Items_Success()
        {
            var result = await controller.Index(9);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ReportViewModel>(viewResult.Model);
            Assert.True(model.Scenarios.Count() == 4);
        }
    }
}
