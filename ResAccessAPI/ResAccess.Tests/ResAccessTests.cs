using Microsoft.Extensions.Logging;
using NSubstitute;
using ResAccess.API;
using ResAccess.API.Controllers;
using ResAccess.Interfaces;

namespace ResAccess.Tests
{
    public class ResAccessTests
    {
        [Fact]
        public void Given_ResAccessController_ctor_ResAccessManager_param_is_null_should_throw()
        {
            // Arrange
            var loggerMock = Substitute.For<ILogger<ResAccessController>>();
            IResAccessManager resAccessManager = null;

            // Act Assert
            Assert.Throws<ArgumentNullException>(() => new ResAccessController(loggerMock, resAccessManager));
        }

    }
}