using Autofac;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ResAccess.API;
using ResAccess.API.Controllers;
using ResAccess.Interfaces;

namespace ResAccess.Tests
{
    public class ResAccessTests
    {
        [Fact]
        public void Given_that_ResAccessController_ctor_ResAccessManager_param_is_null_should_throw()
        {
            // Arrange
            var loggerMock = Substitute.For<ILogger<ResAccessController>>();
            IResAccessManager resAccessManager = null;

            // Act Assert
            Assert.Throws<ArgumentNullException>(() => new ResAccessController(loggerMock, resAccessManager));
        }

        [Fact]
        public void Given_that_ResAccessController_ctor_Logger_param_is_null_should_throw()
        {
            // Arrange
            var resAccessManagerMock = Substitute.For<IResAccessManager>();
            ILogger<ResAccessController> logger = null;

            // Act Assert
            Assert.Throws<ArgumentNullException>(() => new ResAccessController(logger, resAccessManagerMock));
        }

        [Fact]
        public void When_GetAccess_is_invoked_with_resource_equal_whitespace_should_throw()
        {
            // Arrange
            var resAccessManagerMock = Substitute.For<IResAccessManager>();
            var loggerMock = Substitute.For<ILogger<ResAccessController>>();
            var sut = new ResAccessController(loggerMock, resAccessManagerMock);

            // Act Assert
            Assert.Throws<ArgumentException>(() => sut.GetAccess("  "));
        }

        [Fact]
        public void When_GetAccess_is_invoked_with_resource_equal_empty_string_should_throw()
        {
            // Arrange
            var resAccessManagerMock = Substitute.For<IResAccessManager>();
            var loggerMock = Substitute.For<ILogger<ResAccessController>>();
            var sut = new ResAccessController(loggerMock, resAccessManagerMock);

            // Act Assert
            Assert.Throws<ArgumentException>(() => sut.GetAccess(string.Empty));
        }

        [Fact]
        public void When_GetAccess_is_invoked_with_resource_equal_null_should_throw()
        {    
            // Arrange
            var resAccessManagerMock = Substitute.For<IResAccessManager>();
            var loggerMock = Substitute.For<ILogger<ResAccessController>>();
            var sut = new ResAccessController(loggerMock, resAccessManagerMock);

            // Act Assert
            Assert.Throws<ArgumentException>(() => sut.GetAccess(null));
        }
    }
}