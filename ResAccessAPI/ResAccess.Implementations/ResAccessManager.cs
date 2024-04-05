using ResAccess.Interfaces;

namespace ResAccess.Implementations
{
    public class ResAccessManager : IResAccessManager
    {
        //public IDictionary<string, AccessDecision> ResAccessStatuses => throw new NotImplementedException();
        public AccessStatus GetAccessStatus(string resourceName)
        {
            if (string.IsNullOrWhiteSpace(resourceName))
                throw new ArgumentException(nameof(resourceName),
                    "Pleace provide resource string parameter which " +
                    "is not null, empty string and not whitespace.");

            return new AccessStatus { };
            // throw new NotImplementedException();
        }
    }
}
