using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSpoj
{
    class DistinctStudents2 : HashSet<string>
    {
        
        public string Print
        {
            get
            {
                return string.Join(Environment.NewLine, this.OrderBy(s => s).Select(s => s));
            }
        }

    }
}
