using System;
using System.Collections.Generic;
using System.IO;

namespace HTML_Documents_Search_Engine
{
    class DataCollection
    {
        Dictionary<String, SearchDictionary> dict;
        Dictionary<int, Docs_Info> docs;
        Dictionary<int, Posting> post;
        int collectionSize;
        
        public DataCollection()
        {
            dict = new Dictionary<string, SearchDictionary>();
            docs = new Dictionary<int, Docs_Info>();
            post = new Dictionary<int, Posting>();
            collectionSize = 0;
        }

        public void IOFile_Process(String filename)
        {
            bool isDict = false;
            bool isPosting = false;
            bool isDocsTable = false;
            bool isTotal = false;

            if (filename.Equals("..\\..\\SEDocumentExtraction\\dictionary.csv"))
            {
                isDict = true;
            }
            else if (filename.Equals("..\\..\\SEDocumentExtraction\\postings.csv"))
            {
                isPosting = true;
            }
            else if (filename.Equals("..\\..\\SEDocumentExtraction\\docsTable.csv"))
            {
                isDocsTable = true;
            }
            else if (filename.Equals("..\\..\\SEDocumentExtraction\\Total.csv"))
            {
                isTotal = true;
            }

            try
            {
                int count = 0;
                StreamReader scanner = File.OpenText(filename);
                string s = String.Empty;
                while ((s = scanner.ReadLine()) != null)
                {
                    string[] separate = s.Split(',');

                    if(isDict && separate.Length == 4 && count > 0)
                    {
                        dict[separate[0]] = new SearchDictionary(int.Parse(separate[1].Trim()), int.Parse(separate[2].Trim()), int.Parse(separate[3].Trim()));
                    }
                    else if(isPosting && separate.Length == 2 && count > 0)
                    {
                        post[count - 1] = new Posting(int.Parse(separate[0].Trim()), int.Parse(separate[1].Trim()));
                    }
                    else if (isDocsTable && separate.Length == 5 && count > 0)
                    {
                        docs[int.Parse(separate[0].Trim())] = new Docs_Info(separate[1].Trim(), int.Parse(separate[2].Trim()), separate[3].Trim(), separate[4].Trim());
                    }
                    else if (isTotal && count > 0)
                    {
                        collectionSize = int.Parse(s.Trim());
                    }

                    count = count + 1;
                }

                scanner.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File Not Found !!Please Enter Proper FileName !!");
                return;
            }
        }

        public Dictionary<String, SearchDictionary> get_SearchDict()
        {
            return dict;
        }

        public Dictionary<int, Posting> get_Post()
        {
            return post;
        }

        public Dictionary<int, Docs_Info> get_Docs()
        {
            return docs;
        }

        public int get_CollSize()
        {
            return collectionSize;
        }
    }
}
