namespace LanchesMac;

public class Program
{
    public static void Main(string[] args)
    {
        CreatedHostBuilder(args)
            .Build()
            .Run();
    }

    public static IHostBuilder CreatedHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });
}