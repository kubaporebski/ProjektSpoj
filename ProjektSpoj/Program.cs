using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSpoj
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "";
            var ds = new DistinctStudents();
            while ((str = Console.ReadLine().Trim()) != "")
            {
                ds.Add(str);
            }

            Console.WriteLine(ds.Count);
            Console.WriteLine(ds.Print);

        }

        class DistinctStudents : HashSet<string>
        {
            public string Print
            {
                get
                {
                    var i = 0;
                    return string.Join(Environment.NewLine, this.OrderBy(s => s).Select(s => $"{++i}. {s}"));
                }
            }

        }
    }
}