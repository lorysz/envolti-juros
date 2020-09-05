using Application.Interface;
using FluentAssertions;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace TestEnvolti
{
    public class TaxaJurosTest
    {
        private readonly TestContext _testContext;
        public TaxaJurosTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task VerifyReturnOk()
        {
            var response = await _testContext.Client.GetAsync("/taxaJuros");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
