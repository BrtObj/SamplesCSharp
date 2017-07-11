using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAllFilesWithoutRecursion
{
    class Program
    {
        static List<string> targetFiles = new List<string>();

        static void Main()
        {
            Console.Write("please input the directory:");
            string path = Console.ReadLine();

            if (Directory.Exists(path))
            {
                foreach (string file in GetAllFiles(path))
                {
                    targetFiles.Add(file);
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("Please spicify a valid directory path.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static IEnumerable<string> GetAllFiles(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                yield return path;
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
        }
    }
}
