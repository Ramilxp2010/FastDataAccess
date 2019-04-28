using System;
using FastDataAccess.Engine;

namespace FastDataAccess.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            DataAccess data = new DataAccess();
            data.IndexingAllFiles("C:\\Windows\\");

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms, {data.list.Count}");
            

            /*
            var newWatch = new System.Diagnostics.Stopwatch();
            newWatch.Start();

            var newData = new DataAccess();
            newData.TraverseTree("C:\\");

            newWatch.Stop();
            Console.WriteLine($"Execution Time: {newWatch.ElapsedMilliseconds} ms, {newData.list.Count}");
*/

            Console.ReadKey();
        }
    }
}
