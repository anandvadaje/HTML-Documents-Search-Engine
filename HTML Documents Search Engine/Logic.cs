using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTML_Documents_Search_Engine
{
    class Logic
    {
        Dictionary<String, SearchDictionary> dict;
        Dictionary<int, Docs_Info> docs;
        Dictionary<int, Posting> post;
        Dictionary<int, double> scores_m;
        DataCollection dataCollector;
        int collectionSize;

        public Logic()
        {
            dataCollector = new DataCollection();
            
            dataCollector.IOFile_Process("..\\..\\SEDocumentExtraction\\dictionary.csv");
            dict = dataCollector.get_SearchDict();

            dataCollector.IOFile_Process("..\\..\\SEDocumentExtraction\\postings.csv");
            post = dataCollector.get_Post();

            dataCollector.IOFile_Process("..\\..\\SEDocumentExtraction\\docsTable.csv");
            docs = dataCollector.get_Docs();

            dataCollector.IOFile_Process("..\\..\\SEDocumentExtraction\\Total.csv");
            collectionSize = dataCollector.get_CollSize();

           
            scores_m = new Dictionary<int, double>();
        }

        public string start_search(string query_input)
        {
            StringBuilder to_output = new StringBuilder();

            String query = query_input;
            String[] query_list;

            double[] scores = new double[docs.Count + 1];
            List<string> query_tok = new List<string>();
            
            query = query.Replace("<.*?>", " ");
            query = query.Replace("-", " ");
            query = query.Replace(", ", " ");
            query = query.Replace("; ", " ");
            query = query.Replace("\\? ", " ");
            query = query.Replace(": ", " ");
            query = query.Replace("! ", " ");
            query = query.Replace("\\. ", " ");
            query = query.Replace("\\.\"|\\.'", " ");
            query = query.Replace(" +", " ");

            query = query.Replace(" [a-z] | [A-Z] ", " ");

            query_list = null;
            query_tok.Clear();
            query_list = query.Split(' ');

            //tokenize the input query
            for (int i = 0; i < query_list.Length; i++)
            {
                query_list[i] = query_list[i].ToLower();

                query_list[i] = query_list[i].ToLower();
                query_list[i] = query_list[i].Replace("^\\[|\\]$", "");
                query_list[i] = query_list[i].Replace("^\\(|\\)$", "");
                query_list[i] = query_list[i].Replace("^'|'$", "");
                query_list[i] = query_list[i].Replace("'", "");
                query_list[i] = query_list[i].Replace("^\"|\"$", "");
                query_list[i] = query_list[i].Replace(",", "");

                query_list[i] = query_list[i].Trim();

                if (query_list[i].EndsWith("ies"))
                {
                    if (!(query_list[i].EndsWith("aies")) && !(query_list[i].EndsWith("eies")))
                        query_list[i] = query_list[i].Replace("ies$", "y");
                }

                if (query_list[i].EndsWith("es"))
                {
                    if (!(query_list[i].EndsWith("aes")) && !(query_list[i].EndsWith("ees")) && !(query_list[i].EndsWith("oes")))
                        query_list[i] = query_list[i].Replace("es$", "e");
                }

                if (query_list[i].EndsWith("s"))
                {
                    if (!(query_list[i].EndsWith("us")) && !(query_list[i].EndsWith("ss")))
                        query_list[i] = query_list[i].Replace("s$", "");
                }

                if ((!(query_list[i].Length == 1)) && (!query_list[i].Equals("")) && (!query_list[i].Equals("and")) && (!query_list[i].Equals("an")) && (!query_list[i].Equals("by")) && (!query_list[i].Equals("from")) && (!query_list[i].Equals("of")) && (!query_list[i].Equals("the")) && (!query_list[i].Equals("with")) && (!query_list[i].Equals("a")) && (!query_list[i].Equals("in")))
                {
                    query_list[i] = query_list[i].Replace("[^A-Za-z0-9]", "");

                    if ((!(query_list[i].Length == 1)) && (!query_list[i].Equals("")))
                    {
                        query_tok.Add(query_list[i]);
                    }
                }
            }

            List<int> docs_res = new List<int>();

            foreach(string tok in query_tok)
            {
                if (dict.ContainsKey(tok))
                {
                    SearchDictionary d = dict[tok];
                    int[] tf = new int[docs.Count + 1];

                    for (int x = 0; x < d.df; x++)
                    {
                        Posting p = post[d.offset + x];
                        tf[p.docid] = p.tf;

                        if (!docs_res.Contains(p.docid))
                            docs_res.Add(p.docid);
                    }

                    for (int y = 1; y < tf.Length; y++)
                    {
                        Docs_Info doc = docs[y];

                        scores[y] += Math.Log10((0.9 * ((double)tf[y] / (double)doc.doclength) + (0.1 * (double)d.cf / (double)collectionSize))) / (double)Math.Log10(2);
                        if (docs_res.Contains(y))
                        {
                            scores_m[y] = scores[y];
                        }
                    }
                }
            }

            var top5 = scores_m.OrderByDescending(pair => pair.Value).Take(5).ToDictionary(pair => pair.Key, pair => pair.Value);

            int count = 0;
            var newline = Environment.NewLine;
            foreach(var x in top5)
            {
                int id = x.Key;
                Docs_Info doc_r = docs[id];

                to_output.Append(docs[id].headline + newline + doc_r.docpath + Environment.NewLine + "Computed probability: " + x.Value + newline);
                to_output.Append(doc_r.snippet + newline + newline);

                count = count + 1;

                if (count == 5)
                {
                    break;
                }
            }

            if(scores_m.Count == 0)
            {
                to_output.Append("NO RESULTs" + newline);
            }

            scores_m.Clear();
            return to_output.ToString();
        }
    }

}
