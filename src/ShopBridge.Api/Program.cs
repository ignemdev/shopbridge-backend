namespace ShopBridge.Api;
public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        /*se instancia la clase y se le pasa la propiedad
        del builder que implementa IConfiguration*/
        var startup = new Startup(builder.Configuration);
        /*Se configuran los servicios de Startup con los
        servicios del builder*/
        startup.ConfigureServices(builder.Services);
        /*Se genera la app*/
        var app = builder.Build();
        /*Se pasa la aplicacion y el enviroment de la misma*/
        startup.Configure(app, app.Environment);
        /*Se corre la aplicacion*/
        app.Run();
    }
}