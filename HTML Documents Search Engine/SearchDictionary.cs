using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML_Documents_Search_Engine
{
    class SearchDictionary
    {
        public int cf = 0;
        public int df = 0;
        public int offset = 0;

        public SearchDictionary(int a, int b, int c)
        {
            cf = a;
            df = b;
            offset = c;
        }
    }
}
