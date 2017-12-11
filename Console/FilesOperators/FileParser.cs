using System;
using System.Collections.Generic;
using System.IO;
using PL.Models;

namespace Console.FilesOperators
{
    public class FileParser
    {
        private SaleModel ParseLine(string line)
        {
            var temp = line.Split(';');
            return new SaleModel(DateTime.Parse(temp[0]), temp[1], temp[2], Double.Parse(temp[3]));
        }

        public IList<SaleModel> ParseCsv(string path)
        {
            IList<SaleModel> resultList = new List<SaleModel>();
            using (StreamReader sr = new StreamReader(path))
            {
                try
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        resultList.Add(ParseLine(line));
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
            }
            return resultList;
        }
    }
}