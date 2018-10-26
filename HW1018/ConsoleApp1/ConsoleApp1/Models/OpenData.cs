using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace OpenDataImport.Models
{
    public class OpenData
    {
        public string 資料年度 { get; set; }
        public string 統計項目 { get; set; }
        public string 稅目別 { get; set; }
        public string 資料單位 { get; set; }
        public string 值 { get; set; }
    }
}
