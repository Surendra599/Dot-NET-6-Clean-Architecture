namespace Infrastructure.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSetting";
        public string? Audience { get; init; }
        public int ExpiryMinutes { get; init; }
        public string? Issueser { get; init; }
        public string? Secret { get; init; }
    }
}