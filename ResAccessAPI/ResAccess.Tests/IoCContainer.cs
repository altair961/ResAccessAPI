using Autofac;
using ResAccess.Implementations;
using ResAccess.Interfaces;

namespace ResAccess.Tests
{
    public static class IoCContainer
    {
        internal static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ResAccessManager>().As<IResAccessManager>();
            return builder.Build();
        }
    }
}
