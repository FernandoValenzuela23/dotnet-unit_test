/*
 * 
 * https://csandunblogs.com/byte-sized-01-console-app-with-dependency-injection/
 * 
 */


using BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Starting app...");

Console.WriteLine("Creating host...");
using IHost host = CreateHostBuilder(args).Build();

Console.WriteLine("Creating scope...");
using var scope = host.Services.CreateScope();

Console.WriteLine("Getting services...");
var services = scope.ServiceProvider;

try
{

    Console.WriteLine("Getting app class...");
    App app = services.GetRequiredService<App>();
    Console.WriteLine("Running app...");
    app.Run(args);

}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}



IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddTransient<IMathCalculation, MathCalculation>()
                .AddTransient<ICollectionSample, CollectionSample>()
                .AddTransient<App>();
        });
}

/// <summary>
/// Main class to execute injected logic of the business library
/// </summary>
public class App
{
    private readonly IMathCalculation _mathCalculation;
    private readonly ICollectionSample _collectionSample;

    public App(
        IMathCalculation mathCalculation,
        ICollectionSample collectionSample
    )
    {
        _mathCalculation = mathCalculation;
        _collectionSample = collectionSample;
    }

    public void Run(string[] args)
    {
        Console.WriteLine("Calculation Interface...");
        Console.WriteLine($"Math Result: {_mathCalculation.Sum(2, 5)}");

        Console.WriteLine("CollectionSample Interface...");
        List<Customer> list = new List<Customer>();
        list.Add(new Customer(1,"Tobias","Malaquias"));
        list.Add(new Customer(2, "Luna", "De Las Mercedes"));
        list.Add(new Customer(3, "Spock", "Bartolomeo"));
        var result = _collectionSample.GetCustomerById(list, 12);
        string text = result == null ? "Not found" : result.FirstName + " " + result.LastName;
        Console.WriteLine($"Collection Result: {text}");
    }

}