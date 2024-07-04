namespace MTGTraderMarket.Components;

public class Configuration
{
    private static Configuration _this = new Configuration();
    private IConfiguration? _configuration;


    public static void SetConfiguration(IConfiguration configuration)
    {
        _this._configuration = configuration;
    }

    public static Configuration GetConfiguration()
    {
        return _this;
    }

    public string? GetDbConnectionString()
    {
        return _configuration.GetValue<string?>("DBConnectionString");
    }
}