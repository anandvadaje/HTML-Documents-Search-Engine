using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML_Documents_Search_Engine
{
    public class Docs_Info
    {
        public String headline = " ";
        public int doclength = 0;
        public String snippet = " ";
        public String docpath = " ";

        public Docs_Info(String a, int b, String c, String d)
        {
            headline = a;
            doclength = b;
            snippet = c;
            docpath = d;
        }
    }
}
