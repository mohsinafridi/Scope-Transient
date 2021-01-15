using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace Scope_Transient
{

    public class Scoped
    {
    }
    public class Transient
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();
            collection.AddScoped<Scoped>();
            collection.AddTransient<Transient>();

            var builder = collection.BuildServiceProvider();

            Console.Clear();
            Parallel.For(1, 5, i =>
            {
                Console.WriteLine($"Scope ID =  { builder.GetService<Scoped>().GetHashCode().ToString()}");
                Console.WriteLine($"Transient ID =  { builder.GetService<Transient>().GetHashCode().ToString()}");
            });

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
