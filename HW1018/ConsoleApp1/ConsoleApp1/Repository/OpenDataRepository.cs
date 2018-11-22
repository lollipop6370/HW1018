using OpenDataImport.Models;
using System.IO;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace OpenDataImport.Repository
{
    public class OpenDataRepository
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yuli\Desktop\11\HW1018\ConsoleApp1\ConsoleApp1\App_Data\Database.mdf;Integrated Security=True";
                //return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\App_Data\nodeDB.mdf;Integrated Security=True";
            }

        }
        public void Insert(OpenData item)
        {
            var newItem = item;
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            connection.Open();


            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT INTO OpenData(資料年度, 統計項目, 稅目別, 資料單位, 值) 
VALUES              (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')
            ", newItem.資料年度, newItem.統計項目, newItem.稅目別, newItem.資料單位, newItem.值);

            command.ExecuteNonQuery();


            connection.Close();
        }



        //        public object Update(object item)
        //        {
        //            var updateItem = item as YC.Models.OpenData;
        //            var connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
        //            connection.Open();


        //            var command = new System.Data.SqlClient.SqlCommand("", connection);
        //            command.CommandText = string.Format(@"
        //UPDATE [OpenData]
        //   SET 
        //      [資料集名稱] = N'{0}'
        //      ,[服務分類] = N'{1}'
        //      ,[資料集描述] = N'{2}'
        //      ,[DisplaySqe] = N'{3}'
        // WHERE ID=N'{4}'
        //            ", updateItem.服務分類, updateItem.資料集名稱, updateItem.資料集描述, updateItem.DisplaySqe, updateItem.ID);

        //            command.ExecuteNonQuery();


        //            connection.Close();
        //            return item;
        //        }

        //        public void Delete(string ID)
        //        {
        //            var connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
        //            connection.Open();


        //            var command = new System.Data.SqlClient.SqlCommand("", connection);
        //            command.CommandText = string.Format(@"
        //DELETE FROM [OpenData]
        // WHERE ID=N'{0}'
        //            ", ID);

        //            command.ExecuteNonQuery();


        //            connection.Close();
        //        }
    }
}