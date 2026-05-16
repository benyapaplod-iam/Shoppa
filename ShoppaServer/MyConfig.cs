using Microsoft.Extensions.Configuration;

public static class MyConfig
{
    public static string ConnStr => Read("Connection");
    public static string BaseUri => Read("BaseUri");

    public static string Read(string key)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var conn = config[key];
        return conn!;
    }
}