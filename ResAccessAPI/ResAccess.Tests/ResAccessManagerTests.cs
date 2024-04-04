using Autofac;
using ResAccess.Interfaces;

namespace ResAccess.Tests
{
    public class ResAccessManagerTests
    {
        [Fact]
        public void When_GetAccessStatus_is_invoked_with_resource_equal_whitespace_should_throw()
        {
            // Arrange 
            var sut = IoCContainer.CompositionRoot().Resolve<IResAccessManager>();
            var resourceName = "  ";

            // Act Assert
            Assert.Throws<ArgumentException>(() => sut.GetAccessStatus(resourceName));
        }

        [Fact]
        public void When_GetAccessStatus_is_invoked_with_resource_equal_empty_string_should_throw()
        {
            // Arrange 
            var sut = IoCContainer.CompositionRoot().Resolve<IResAccessManager>();
            var resourceName = string.Empty;

            // Act Assert
            Assert.Throws<ArgumentException>(() => sut.GetAccessStatus(resourceName));
        }

        [Fact]
        public void When_GetAccessStatus_is_invoked_with_resource_equal_null_should_throw()
        {
            // Arrange 
            var sut = IoCContainer.CompositionRoot().Resolve<IResAccessManager>();
            string resourceName = null;

            // Act Assert
            Assert.Throws<ArgumentException>(() => sut.GetAccessStatus(resourceName));
        }
    }
}