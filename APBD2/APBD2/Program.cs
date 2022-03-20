using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace APBD2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var path = args[0];

            //var fi = new FileInfo(path);
            FileInfo fi = new(path);

            var fileContent = new List<string>();

            using (StreamReader stream = new(fi.OpenRead()))
            {
                // Analogicznie co ""
                //string line = string.Empty;

                string line = null;

                while ((line = await stream.ReadLineAsync()) != null)
                {
                    fileContent.Add(line);
                }
                //stream.Dispose();
            }

            foreach (var item in fileContent)
            {
                Console.WriteLine(item);
            }

            //foreach (var item in File.ReadLines(path)){}

            // DateTime - typ dla daty 
            // DateTime.Parse("2022-03-20")

            // string.IsNullOrWhiteSpace(str)

            // StreamWriter stream... stream.WriteLine(line)

            //var json = JsonSerializer.Serialize(set)


        }
    }
}
