using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterpolatedStrings
{
    class Program
    {
        public static void Main()
        {
            GetPageSizeAsync("http://docs.microsoft.com").Wait();
            Console.ReadKey();
        }

        private static async Task GetPageSizeAsync(string url)
        {
            var client = new HttpClient();
            var uri = new Uri(Uri.EscapeUriString(url));
            byte[] urlContents = await client.GetByteArrayAsync(uri);
            Console.WriteLine($"{url}: {urlContents.Length / 2:N0} characters");
            Console.WriteLine("more info about strings formats refer to :");
            Console.WriteLine("https://docs.microsoft.com/en-us/dotnet/standard/base-types/formatting-types");
        }
    }
}
