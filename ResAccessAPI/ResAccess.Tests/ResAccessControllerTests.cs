using Microsoft.Extensions.Logging;
using NSubstitute;
using ResAccess.Interfaces;

namespace ResAccess.Tests
{
    public class ResAccessControllerTests
    {
        [Fact]
        public void Given_that_ResAccessController_ctor_ResAccessManager_param_is_null_should_throw()
        {
            // Arrange
            var loggerMock = Substitute.For<ILogger<API.Controllers.ResAccessController>>();
            IResAccessManager resAccessManager = null;

            // Act Assert
            Assert.Throws<ArgumentNullException>(() => new API.Controllers.ResAccessController(loggerMock, resAccessManager));
        }

        [Fact]
        public void Given_that_ResAccessController_ctor_Logger_param_is_null_should_throw()
        {
            // Arrange
            var resAccessManagerMock = Substitute.For<IResAccessManager>();
            ILogger<API.Controllers.ResAccessController> logger = null;

            // Act Assert
            Assert.Throws<ArgumentNullException>(() => new API.Controllers.ResAccessController(logger, resAccessManagerMock));
        }
    }
}