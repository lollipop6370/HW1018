using OpenDataImport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace OpenDataImport.SQL
{
    class SQL
    {
        public List<OpenData> findOpenData()
        {
            List<OpenData> result = new List<OpenData>();
            string baseDir = Directory.GetCurrentDirectory();


            var xml = XElement.Load(@"https://data.kcg.gov.tw/dataset/a1f496df-8fc1-424f-83c3-6c76b0c14496/resource/e4c6fda4-b261-4d70-af9f-f92c9390e75c/download/xml75.xml");


            //XNamespace gml = @"http://www.opengis.net/gml/3.2";
            //XNamespace twed = @"http://twed.wra.gov.tw/twedml/opendata";
            var nodes = xml.Descendants("各項稅捐徵課費用").ToList();
            /*
            for (var i = 0; i < nodes.Count; i++)
            {
                 var node = nodes[i];
                 OpenData item = new OpenData();

                 item.資料年度 = getValue(node, "資料年度");
                 item.統計項目 = getValue(node, "統計項目");
                 item.稅目別 = getValue(node, "稅目別");
                 item.資料單位 = getValue(node, "資料單位");
                 item.值 = getValue(node, "值");
                 result.Add(item);
            }*/

            nodes.ToList()
             .ForEach(node =>
             {
                 OpenData item = new OpenData();

                 item.資料年度 = getValue(node, "資料年度");
                 item.統計項目 = getValue(node, "統計項目");
                 item.稅目別 = getValue(node, "稅目別");
                 item.資料單位 = getValue(node, "資料單位");
                 item.值 = getValue(node, "值");
                 result.Add(item);

             });
            return result;

        }
        public void ImportToDb(List<OpenData> openDatas)
        {
            Repository.OpenDataRepository Repository = new Repository.OpenDataRepository();
            openDatas.ForEach(item =>
            {
                Repository.Insert(item);
            });

        }
        private static string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();

        }


    }
}