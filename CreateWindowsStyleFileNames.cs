using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var filenames = new List<string>();
            filenames.Add("doc");
            filenames.Add("doc");
            filenames.Add("doc");


            /*  ['doc(1)', 'doc(2)', 'doc(1)', 'doc(1)(1)']
            // => ['doc(1)', 'doc(2)', 'doc(1)(1)', 'doc(1)(1)(1)']

            filenames.Add("doc(1)");
            filenames.Add("doc(2)");
            filenames.Add("doc(1)");
            filenames.Add("doc(1)(1)");
            */


            /*
            // ['doc(1)', 'doc(2)', 'doc(1)', 'doc(1)(1)', 'doc(1)(1)'] => ['doc(1)', 'doc(2)', 'doc(1)(1)', 'doc(1)(1)(1)', 'doc(1)(1)(2)']
            filenames.Add("doc(1)");
            filenames.Add("doc(2)");
            filenames.Add("doc(1)");
            filenames.Add("doc(1)(1)");
            filenames.Add("doc(1)(1)");
            */

            /* 
            // ['doc(5)', 'doc(2)', 'doc', 'doc', 'doc', 'doc','doc', 'doc'] => ['doc(5)', 'doc(2)', 'doc', 'doc(1)', 'doc(3)', 'doc(4)','doc(6)', 'doc(7)']
            filenames.Add("doc(5)");
            filenames.Add("doc(2)");
            filenames.Add("doc");
            filenames.Add("doc");
            filenames.Add("doc");
            filenames.Add("doc");
            filenames.Add("doc");
            filenames.Add("doc");
            */

            var result = Program.FileNamesList(filenames);

            for (int ii = 0; ii < result.Count; ii++)
            {
                Console.WriteLine(result[ii]);
            }

        }

        public static List<string> FileNamesList(List<string> filenames)
        {
            var files = new List<string>();

            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int ii = 0; ii < filenames.Count; ii++)
            {
                var file = filenames[ii];

                if (dict.ContainsKey(file))
                {
                    var modFile = file + "(" + dict[file] + ")";
                    int count = dict[file];
                    while (dict.ContainsKey(modFile))
                    {    
                        count++;
                        modFile = file + "(" + count + ")";
                    }
                    dict[file] = dict[file] + 1;
                    dict[modFile] = 1;
                    files.Add(modFile);
                }
                else
                {
                    dict.Add(file, 1);
                    files.Add(file);
                }
            }

            return files;
        }

    }
}
