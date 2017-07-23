using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML_Documents_Search_Engine
{
    public class Posting
    {
        public int docid = 0;
        public int tf = 0;

        public Posting(int a, int b)
        {
            docid = a;
            tf = b;
        }
    }
}
