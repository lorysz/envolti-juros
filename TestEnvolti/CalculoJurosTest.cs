using Application.Applications;
using Application.Interface;
using envolti.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestEnvolti
{
    public class CalculoJurosTest
    {

        [Fact]
        public async Task GetCalculoJuros()
        {
            Moq.Mock<IJurosApplication> mock = new Moq.Mock<IJurosApplication>();

            mock.Setup(x => x.GetJuros(100, 5)).Returns(105.10m);

            JurosController jurosApplication = new JurosController(mock.Object);
            var result = jurosApplication.GetJuros(100, 5);

            var okResult = result as OkObjectResult;
           
            okResult.Value.Should().Be(105.10);
        }

    }
}
