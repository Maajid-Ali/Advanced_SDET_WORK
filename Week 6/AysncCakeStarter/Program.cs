using System;
using System.Threading;
using System.Threading.Tasks;

namespace AysncCake
{
    class Program
    {
        public async static Task Main(string[] args)
        {
            Console.WriteLine("Welcome to my birthday party");
            await HaveAParty();
            Console.WriteLine("Thanks for a lovely party");
            Console.ReadLine();
        }

        private static async Task HaveAParty()
        {
            var name = "Cathy";
            var cakeTask = BakeCakeAsync();
            PlayPartyGames();
            OpenPresents();
            Cake cake = await cakeTask;
            Console.WriteLine($"Happy birthday, {name}, {cake}!!");
        }

        private async static Task <Cake> BakeCakeAsync()
        {
            Console.WriteLine("Cake is in the oven");
            await Task.Delay(TimeSpan.FromSeconds(5));  // delays the baking time by 5 seconds
            Console.WriteLine("Cake is done");
            return new Cake();
        }

        private static void PlayPartyGames()
        {
            Console.WriteLine("Starting games");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Finishing Games");
        }

        private static void OpenPresents()
        {
            Console.WriteLine("Opening Presents");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("Finished Opening Presents");
        }
    }

    public class Cake
    {
        public override string ToString()
        {
            return "Here's a cake";
        }
    }
}
