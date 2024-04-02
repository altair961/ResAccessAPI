using ResAccess.Interfaces;

namespace ResAccess.DTO
{
    public class GetAccessStatusResponse
    {
        public string? Resource { get; set; }
        public AccessDecision AccessDecision { get; set; }
        public string? Reason { get; set; }
    }
}
