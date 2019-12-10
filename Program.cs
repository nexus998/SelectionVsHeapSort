using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pasirinkti, kas kiek dides musu duomenu kiekis
            Console.WriteLine("Select increment size");
            var input = Console.ReadLine();
            int size = int.Parse(input);
            // Irasyti i output faila headerius
            File.AppendAllText(Directory.GetCurrentDirectory() + "\\" + "test_results.csv", "Count,Selection,Heap\n");

            
            for(int i = 0; i <= 100000; i += size)
            {
                if (i != 0)
                {
                    // Inicializuoti klase, kuri skaiciuos algoritmu vykdymu laikus
                    var t = new Stopwatch();

                    // Sugeneruoti duomenis
                    // GenerateSortedData(i) - best-case scenario (bus sugeneruoti jau surikiuoti duomenys)
                    // GenerateData(i) - bus sugeneruoti bet kokie int skaiciai
                    int[] data = GenerateSortedData(i);

                    // Inicializuoti SelectionSort klase ir rikiuoti duomenis
                    var s = new SelectionSort();
                    t.Start();
                    int[] selectSort = s.Sort(data);
                    t.Stop();
                    var selectTime = t.ElapsedMilliseconds;

                    //Atstatyti timeri
                    t.Reset();

                    //Inicializuoti HeapSort klase ir rikiuoti duomenis
                    var h = new HeapSort();
                    t.Start();
                    int[] heap = h.Sort(data);
                    t.Stop();
                    var heapTime = t.ElapsedMilliseconds;

                    // Isvesti i konsole, kiek procentu uzduoties atlikta
                    Console.WriteLine("Progress: " + (float)i / 100000 * 100 + "%");

                    // Isvesti rezultutatus i output faila
                    File.AppendAllText(Directory.GetCurrentDirectory() + "\\" + "test_results.csv", i + "," + selectTime + "," + heapTime + "\n");
                }
            }
        }

        // Sugeneruoja pasirinkta kieki duomenu nuo 69 iki 420
        public static int[] GenerateData(int count)
        {
            var r = new Random();
            int[] ans = new int[count];
            for(int i = 0; i < count; i++)
            {
                int a = r.Next(69, 420);
                ans[i] = a;
            }
            return ans;
        }
        // Sugeneruoja pasirinkta kieki duomenu nuo 0 iki count
        public static int[] GenerateSortedData(int count)
        {
            int[] ans = new int[count];
            for (int i = 0; i < count; i++)
            {
                ans[i] = i;
            }
            return ans;
        }
    }
}
