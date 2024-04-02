using ResAccess.Interfaces;

namespace ResAccess.Implementations
{
    public class ResAccessManager : IResAccessManager
    {
        public IDictionary<string, AccessDecision> ResAccessStatuses => throw new NotImplementedException();
    }
}
