using OpenDataImport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace OpenDataImport
{
    class Program
    {
        static void Main()
        {
            SQL.SQL SQL = new SQL.SQL();
            var nodes = SQL.findOpenData();
            showOpenData(nodes);
            SQL.ImportToDb(nodes);
            Console.ReadKey();

        }
        


        private static void showOpenData(List<OpenData> nodes)
        {

            Console.WriteLine(string.Format("共收到{0}筆的資料", nodes.Count));
            nodes.GroupBy(node => node.稅目別).ToList()
                .ForEach(group =>
                {

                    var key = group.Key;
                    var groupDatas = group.ToList();
                    var message = $"稅目別:{key},共有{groupDatas.Count()}筆資料";
                    Console.WriteLine(message);
                });


        }
    }

}
