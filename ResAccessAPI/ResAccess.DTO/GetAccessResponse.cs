using ResAccess.Interfaces;

namespace ResAccess.DTO
{
    public class GetAccessResponse
    {
        public string? Resource { get; set; }
        public AccessDecision AccessDecision { get; set; }
        public string? Reason { get; set; }
    }
}
