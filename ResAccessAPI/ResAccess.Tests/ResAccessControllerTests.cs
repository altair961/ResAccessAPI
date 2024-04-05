using Microsoft.Extensions.Logging;
using NSubstitute;
using ResAccess.API.Controllers;
using ResAccess.DTO;
using ResAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Autofac;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        
        [Fact]
        public void When_GetAccessStatus_is_invoked_with_GetAccessStatusRequest_equal_null_should_not_throw_and_return_bad_request()
        {
            // Arrange
            var resAccessManagerMock = Substitute.For<IResAccessManager>();
            var loggerMock = Substitute.For<ILogger<ResAccessController>>();
            var sut = new ResAccessController(loggerMock, resAccessManagerMock);
            GetAccessStatusRequest request = null;
            ActionResult<GetAccessStatusResponse> actionResult;

            // Act
            var exception = Record.Exception(() => 
            {
                actionResult = sut.GetAccessStatus(request);
            });

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void When_GetAccessStatus_is_invoked_with_resource_equal_null_should_not_throw_and_return_bad_request()
        {
            // Arrange
            var resAccessManagerMock = Substitute.For<IResAccessManager>();
            var loggerMock = Substitute.For<ILogger<ResAccessController>>();
            var sut = new ResAccessController(loggerMock, resAccessManagerMock);
            var request = new GetAccessStatusRequest();
            request.Resource = null;
            ActionResult<GetAccessStatusResponse> actionResult;
            var statusCode = 0;

            // Act
            var exception = Record.Exception(() =>
            {
                actionResult = sut.GetAccessStatus(request);
                statusCode = GetStatusCode(actionResult) ?? 0;
            });

            // Assert
            Assert.Null(exception);
            Assert.Equal(400, statusCode);
        }

        [Fact]
        public void When_GetAccessStatus_is_invoked_with_resource_equal_white_space_should_not_throw_and_return_bad_request()
        {
            // Arrange 
            var resAccessManagerMock = Substitute.For<IResAccessManager>();
            var loggerMock = Substitute.For<ILogger<ResAccessController>>();
            var sut = new ResAccessController(loggerMock, resAccessManagerMock);
            var request = new GetAccessStatusRequest();
            request.Resource = "  ";
            ActionResult<GetAccessStatusResponse> actionResult;
            var statusCode = 0;

            // Act
            var exception = Record.Exception(() =>
            {
                actionResult = sut.GetAccessStatus(request);
                statusCode = GetStatusCode(actionResult) ?? 0;
            });

            // Assert
            Assert.Null(exception);
            Assert.Equal(400, statusCode);
        }

        [Fact]
        public void When_GetAccessStatus_is_invoked_with_resource_equal_empty_string_should_not_throw_and_return_bad_request()
        {
            // Arrange 
            var resAccessManagerMock = Substitute.For<IResAccessManager>();
            var loggerMock = Substitute.For<ILogger<ResAccessController>>();
            var sut = new ResAccessController(loggerMock, resAccessManagerMock);
            var request = new GetAccessStatusRequest();
            request.Resource = string.Empty;
            ActionResult<GetAccessStatusResponse> actionResult;
            var statusCode = 0;

            // Act
            var exception = Record.Exception(() =>
            {
                actionResult = sut.GetAccessStatus(request);
                statusCode = GetStatusCode(actionResult) ?? 0;
            });

            // Assert
            Assert.Null(exception);
            Assert.Equal(400, statusCode);
        }

        private static int? GetStatusCode<T>(ActionResult<T?> actionResult)
        {
            IConvertToActionResult convertToActionResult = actionResult;
            var actionResultWithStatusCode = convertToActionResult.Convert() as IStatusCodeActionResult;
            return actionResultWithStatusCode?.StatusCode;
        }
    }
}