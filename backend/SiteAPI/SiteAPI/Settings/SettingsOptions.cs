namespace SiteAPI.Settings
{
    public class SettingsOptions
    {
        public const string Settings = nameof(Settings);
        
        public required string ConnectionString { get; init; }


    }
}
